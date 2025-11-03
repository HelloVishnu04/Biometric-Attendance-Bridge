using BiometricAttendanceBridge.Models;
using BiometricAttendanceBridge.Services;
using Microsoft.Win32;
using sbxpc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiometricAttendanceBridge
{
    public partial class MainForm : Form
    {
        // UI controls
        private ListView lvDevices, lvUsers;
        private RichTextBox rtbLog;
        private Button btnAdd, btnEdit, btnRemove, btnSyncAll, btnViewCommLog, btnViewQueue, btnDeviceConnect, btnApiConnect, btnRefreshUsers;
        private Label lblDeviceStatus, lblApiStatusText, lblSelectedDevice;
        private Panel pnlDeviceStatus, pnlApiStatus;
        private MenuStrip menu;
        private TabControl tabControl;
        private TabPage tabDashboard, tabUserMgmt, tabSettings;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblApiStatus, lblLastSync, lblFooter;
        private Timer syncTimer;
        private TextBox txtApiUrl, txtAccessToken;
        private CheckBox chkAutoStart;

        // Services & State
        private DeviceManager deviceManager;
        private ApiService apiService;
        private LocalStorageService localStorage;
        private ConfigurationManager configManager;
        private int selectedMachineNumber = -1;
        private bool isSyncing = false, isDeviceConnected = false, isApiConnected = false;
        private List<AttendanceLog> logHistory = new List<AttendanceLog>();
        
        // Track communication events (both fetches and pushes)
        private List<string> communicationHistory = new List<string>();
        
        // Pagination state for User Management
        private List<BiometricUser> allUsers = new List<BiometricUser>();
        private int currentUserPage = 1;
        private const int USERS_PER_PAGE = 25;

        public MainForm()
        {
            configManager = new ConfigurationManager();
            InitializeComponent();
            InitializeServices();
            LoadSettings();
            InitializeSyncTimer();
            PopulateDeviceLists();
            Log("SYSTEM", "Application started. Ready to connect to devices and server.");
            try { SBXPCDLL.DotNET(); } catch { }
        }
        private void InitializeServices()
        {
            configManager = new ConfigurationManager();  // Create ONCE
            deviceManager = new DeviceManager();
            apiService = new ApiService(configManager);  // Pass it to ApiService
            localStorage = new LocalStorageService();
        }

        private void InitializeComponent()
        {
            this.Text = "Biometric Data Manager";
            this.Width = 950;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Menu and Tabs
            menu = new MenuStrip();
            var dashboardMenu = new ToolStripMenuItem("Dashboard");
            dashboardMenu.Click += (s, e) => tabControl.SelectedIndex = 0;
            var userMgmtMenu = new ToolStripMenuItem("User Management");
            userMgmtMenu.Click += (s, e) => tabControl.SelectedIndex = 1;
            var settingsMenu = new ToolStripMenuItem("Settings");
            settingsMenu.Click += (s, e) => tabControl.SelectedIndex = 2;
            menu.Items.AddRange(new[] { dashboardMenu, userMgmtMenu, settingsMenu });
            this.Controls.Add(menu);

            tabControl = new TabControl()
            {
                Location = new Point(0, menu.Height),
                Size = new Size(this.Width, this.Height - menu.Height - 40),
                Dock = DockStyle.Fill
            };
            this.Controls.Add(tabControl);

            // Dashboard Tab
            tabDashboard = new TabPage("Dashboard") { Padding = new Padding(5) };
            tabControl.TabPages.Add(tabDashboard);
            CreateDashboardTab();

            // User Management Tab
            tabUserMgmt = new TabPage("User Management") { Padding = new Padding(20) };
            tabControl.TabPages.Add(tabUserMgmt);
            CreateUserManagementTab();

            // Settings Tab
            tabSettings = new TabPage("Settings") { Padding = new Padding(20) };
            tabControl.TabPages.Add(tabSettings);
            CreateSettingsTab();

            // Status Strip
            statusStrip = new StatusStrip();
            lblApiStatus = new ToolStripStatusLabel("API: Not Authenticated");
            lblLastSync = new ToolStripStatusLabel("Last Sync: Never");
            lblFooter = new ToolStripStatusLabel("Developed by Krishna Kumar.");
            var springLabel = new ToolStripStatusLabel { Spring = true };
            statusStrip.Items.AddRange(new ToolStripItem[] { lblApiStatus, new ToolStripSeparator(), lblLastSync, springLabel, lblFooter });
            this.Controls.Add(statusStrip);
        }

        private void CreateDashboardTab()
        {
            GroupBox gbDeviceMgmt = new GroupBox() { Text = "Device Management", Location = new Point(10, 10), Size = new Size(380, 320) };
            tabDashboard.Controls.Add(gbDeviceMgmt);

            lvDevices = new ListView()
            {
                Location = new Point(12, 24),
                Size = new Size(356, 230),
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            lvDevices.Columns.Add("Device Name", 220);
            lvDevices.Columns.Add("IP / Type", 120);
            lvDevices.SelectedIndexChanged += (s, e) => UpdateDeviceStatusUI();
            gbDeviceMgmt.Controls.Add(lvDevices);

            btnAdd = new Button() { Text = "Add", Location = new Point(12, 270), Size = new Size(100, 32) };
            btnAdd.Click += BtnAddDevice_Click;
            gbDeviceMgmt.Controls.Add(btnAdd);
            btnEdit = new Button() { Text = "Edit", Location = new Point(135, 270), Size = new Size(100, 32) };
            btnEdit.Click += BtnEditDevice_Click;
            gbDeviceMgmt.Controls.Add(btnEdit);
            btnRemove = new Button() { Text = "Remove", Location = new Point(258, 270), Size = new Size(110, 32) };
            btnRemove.Click += BtnRemoveDevice_Click;
            gbDeviceMgmt.Controls.Add(btnRemove);

            btnSyncAll = new Button()
            {
                Text = "Sync All Now",
                Location = new Point(10, 350),
                Size = new Size(380, 40),
                Font = new Font(this.Font, FontStyle.Bold),
                BackColor = Color.LimeGreen,
                ForeColor = Color.White
            };
            btnSyncAll.Click += async (s, e) => await PerformFullSyncAsync();
            tabDashboard.Controls.Add(btnSyncAll);

            btnViewCommLog = new Button()
            {
                Text = "View Communication Log",
                Location = new Point(10, 400),
                Size = new Size(380, 35),
                Font = new Font(this.Font, FontStyle.Regular)
            };
            btnViewCommLog.Click += (s, e) => ShowCommunicationLog();
            tabDashboard.Controls.Add(btnViewCommLog);

            btnViewQueue = new Button()
            {
                Text = "View Pending Queue",
                Location = new Point(10, 445),
                Size = new Size(380, 35),
                Font = new Font(this.Font, FontStyle.Regular)
            };
            btnViewQueue.Click += (s, e) => ShowPendingQueue();
            tabDashboard.Controls.Add(btnViewQueue);

            GroupBox gbStatus = new GroupBox() { Text = "Connection Status", Location = new Point(400, 10), Size = new Size(520, 150) };
            tabDashboard.Controls.Add(gbStatus);

            lblSelectedDevice = new Label() { Text = "DEVICE: Not Selected", Font = new Font(this.Font, FontStyle.Bold), Location = new Point(15, 28), AutoSize = true };
            gbStatus.Controls.Add(lblSelectedDevice);

            pnlDeviceStatus = new Panel() { Location = new Point(20, 52), Size = new Size(20, 20), BackColor = Color.Gray, BorderStyle = BorderStyle.FixedSingle };
            gbStatus.Controls.Add(pnlDeviceStatus);

            lblDeviceStatus = new Label() { Text = "Status: Unknown", Location = new Point(50, 52), AutoSize = true };
            gbStatus.Controls.Add(lblDeviceStatus);

            btnDeviceConnect = new Button() { Text = "Connect", Location = new Point(420, 48), Size = new Size(90, 28) };
            btnDeviceConnect.Click += BtnDeviceConnect_Click;
            gbStatus.Controls.Add(btnDeviceConnect);

            Label lblApiTitle = new Label() { Text = "WEB API", Font = new Font(this.Font, FontStyle.Bold), Location = new Point(15, 85), AutoSize = true, ForeColor = Color.Red };
            gbStatus.Controls.Add(lblApiTitle);

            pnlApiStatus = new Panel() { Location = new Point(20, 109), Size = new Size(20, 20), BackColor = Color.Red, BorderStyle = BorderStyle.FixedSingle };
            gbStatus.Controls.Add(pnlApiStatus);

            lblApiStatusText = new Label() { Text = "Status: Disconnected", Location = new Point(50, 109), AutoSize = true };
            gbStatus.Controls.Add(lblApiStatusText);

            btnApiConnect = new Button() { Text = "Connect", Location = new Point(420, 105), Size = new Size(90, 28) };
            btnApiConnect.Click += BtnApiConnect_Click;
            gbStatus.Controls.Add(btnApiConnect);

            GroupBox gbLog = new GroupBox() { Text = "Activity Log", Location = new Point(400, 180), Size = new Size(520, 300) };
            tabDashboard.Controls.Add(gbLog);

            rtbLog = new RichTextBox()
            {
                Location = new Point(12, 24),
                Size = new Size(496, 265),
                ReadOnly = true,
                Font = new Font("Consolas", 9),
                ScrollBars = RichTextBoxScrollBars.Vertical,
                BackColor = Color.White,
                ForeColor = Color.Black
            };
            gbLog.Controls.Add(rtbLog);
        }

        private void CreateUserManagementTab()
        {
            Label lblTitle = new Label()
            {
                Text = "Biometric Device User List",
                Font = new Font(this.Font.FontFamily, 16, FontStyle.Bold),
                Location = new Point(0, 0),
                AutoSize = true
            };
            tabUserMgmt.Controls.Add(lblTitle);

            // Info label showing current page and total users
            Label lblPageInfo = new Label()
            {
                Text = "Page 1 | Total Users: 0",
                Location = new Point(0, 35),
                AutoSize = true,
                Font = new Font(this.Font, FontStyle.Regular),
                ForeColor = Color.Blue,
                Name = "lblPageInfo"
            };
            tabUserMgmt.Controls.Add(lblPageInfo);

            lvUsers = new ListView()
            {
                Location = new Point(0, 60),
                Size = new Size(570, 280),
                View = View.Details,
                FullRowSelect = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            lvUsers.Columns.Add("Enroll No", 100);
            lvUsers.Columns.Add("Name", 180);
            lvUsers.Columns.Add("Privilege", 100);
            lvUsers.Columns.Add("Status", 90);
            tabUserMgmt.Controls.Add(lvUsers);

            // Pagination buttons panel
            Panel pnlPagination = new Panel()
            {
                Location = new Point(0, 350),
                Size = new Size(570, 40),
                BorderStyle = BorderStyle.FixedSingle
            };
            tabUserMgmt.Controls.Add(pnlPagination);

            Button btnPrevPage = new Button()
            {
                Text = "< Previous",
                Location = new Point(5, 5),
                Size = new Size(80, 30)
            };
            btnPrevPage.Click += (s, e) =>
            {
                if (currentUserPage > 1)
                {
                    currentUserPage--;
                    DisplayUserPage();
                }
            };
            pnlPagination.Controls.Add(btnPrevPage);

            Label lblPageNav = new Label()
            {
                Text = $"Page {currentUserPage}",
                Location = new Point(200, 10),
                AutoSize = true,
                Font = new Font(this.Font, FontStyle.Bold),
                Name = "lblPageNav"
            };
            pnlPagination.Controls.Add(lblPageNav);

            Button btnNextPage = new Button()
            {
                Text = "Next >",
                Location = new Point(485, 5),
                Size = new Size(80, 30)
            };
            btnNextPage.Click += (s, e) =>
            {
                int totalPages = (int)Math.Ceiling((double)allUsers.Count / USERS_PER_PAGE);
                if (currentUserPage < totalPages)
                {
                    currentUserPage++;
                    DisplayUserPage();
                }
            };
            pnlPagination.Controls.Add(btnNextPage);

            btnRefreshUsers = new Button()
            {
                Text = "Refresh Users",
                Location = new Point(0, 395),
                Size = new Size(125, 32)
            };
            btnRefreshUsers.Click += (s, e) =>
            {
                currentUserPage = 1; // Reset to page 1
                RefreshUserListFromDevice(selectedMachineNumber, lvUsers);
            };
            tabUserMgmt.Controls.Add(btnRefreshUsers);
        }

        // Display current page of users
        private void DisplayUserPage()
        {
            lvUsers.Items.Clear();

            if (allUsers.Count == 0)
            {
                lvUsers.Items.Add(new ListViewItem(new[] { "No users found", "", "", "" }));
                return;
            }

            int totalPages = (int)Math.Ceiling((double)allUsers.Count / USERS_PER_PAGE);
            int startIndex = (currentUserPage - 1) * USERS_PER_PAGE;
            int endIndex = Math.Min(startIndex + USERS_PER_PAGE, allUsers.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                var user = allUsers[i];
                lvUsers.Items.Add(new ListViewItem(new[]
                {
                    user.EnrollNo,
                    user.Name,
                    user.Privilege.ToString(),
                    user.EnabledStatus == 1 ? "Enabled" : "Disabled"
                }));
            }

            // Update page info
            var lblPageInfo = tabUserMgmt.Controls["lblPageInfo"] as Label;
            if (lblPageInfo != null)
            {
                lblPageInfo.Text = $"Page {currentUserPage} of {totalPages} | Total Users: {allUsers.Count} | Showing {endIndex - startIndex} users";
            }

            // Update page navigation
            foreach (Control ctrl in tabUserMgmt.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    foreach (Control c in pnl.Controls)
                    {
                        if (c is Label && c.Name == "lblPageNav")
                        {
                            c.Text = $"Page {currentUserPage} / {totalPages}";
                        }
                    }
                }
            }

            Log("SYSTEM", $"Displaying users: Page {currentUserPage} of {totalPages} ({endIndex - startIndex} users shown)");
        }

        private void RefreshUserListFromDevice(int machineNumber, ListView lvUsers)
        {
            allUsers.Clear();
            currentUserPage = 1;

            if (machineNumber <= 0)
            {
                MessageBox.Show("Please select a device first.");
                return;
            }

            try
            {
                Log("DEVICE", "Fetching user list from device...");

                if (SBXPCDLL.ReadAllUserID(machineNumber))
                {
                    string enrollNo, name;
                    int dwEnrollNumber, dwEMachineNumber, dwBackupNumber, dwMachinePrivilege, dwEnable;

                    while (SBXPCDLL.GetAllUserID(
                        machineNumber,
                        out enrollNo,
                        out name,
                        out dwEnrollNumber,
                        out dwEMachineNumber,
                        out dwBackupNumber,
                        out dwMachinePrivilege,
                        out dwEnable))
                    {
                        allUsers.Add(new BiometricUser
                        {
                            EnrollNo = enrollNo,
                            Name = name,
                            Privilege = dwMachinePrivilege,
                            EnabledStatus = dwEnable
                        });
                    }

                    Log("DEVICE", $"Successfully fetched {allUsers.Count} users from device.", false, Color.Green);
                    DisplayUserPage();
                }
                else
                {
                    Log("DEVICE", "Failed to read user list from device.", true, Color.Red);
                    MessageBox.Show("Unable to fetch user list from device.");
                }
            }
            catch (Exception ex)
            {
                Log("ERROR", $"Unable to fetch users: {ex.Message}", true, Color.Red);
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void CreateSettingsTab()
        {
            Label lblTitle = new Label()
            {
                Text = "Application Settings",
                Font = new Font(this.Font.FontFamily, 16, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            tabSettings.Controls.Add(lblTitle);

            Label lblApiUrl = new Label() { Text = "API URL:", Location = new Point(10, 50), AutoSize = true };
            tabSettings.Controls.Add(lblApiUrl);

            txtApiUrl = new TextBox()
            {
                Text = configManager.Config.ApiBaseUrl ?? "https://domain.in/admin/attendance/webhook",
                Location = new Point(170, 50),
                Width = 600,
                AutoSize = true,
            };
            tabSettings.Controls.Add(txtApiUrl);

            Label lblAccessToken = new Label()
            {
                Text = "Permanent Access Token:",
                Location = new Point(10, 80),
                AutoSize = true
            };
            tabSettings.Controls.Add(lblAccessToken);

            txtAccessToken = new TextBox()
            {
                Text = configManager.Config.AccessToken ?? "",
                Location = new Point(170, 80),
                Width = 600,
                AutoSize = true,
            };
            tabSettings.Controls.Add(txtAccessToken);

            chkAutoStart = new CheckBox()
            {
                Text = "Start application at login",
                Location = new Point(10, 120),
                Checked = configManager.Config.AutoStart
            };
            tabSettings.Controls.Add(chkAutoStart);

            Button btnSaveSettings = new Button()
            {
                Text = "Save Settings",
                Location = new Point(10, 170),
                Size = new Size(120, 40),
                Font = new Font(this.Font, FontStyle.Bold)
            };
            btnSaveSettings.Click += (s, e) =>
            {
                configManager.Config.ApiBaseUrl = txtApiUrl.Text.Trim();
                configManager.Config.AccessToken = txtAccessToken.Text.Trim();
                configManager.Config.AutoStart = chkAutoStart.Checked;
                configManager.SaveConfig();

                // Force ApiService to reload config
                apiService = new ApiService(configManager);

                SetAutoStart(chkAutoStart.Checked);
                Log("SETTINGS", $"Settings saved. Token: {(string.IsNullOrWhiteSpace(txtAccessToken.Text) ? "NOT SET" : "SET")}", false, Color.Green);
                MessageBox.Show("Settings saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            tabSettings.Controls.Add(btnSaveSettings);
        }

        private void SetAutoStart(bool enable)
        {
            string appName = "BiometricAttendanceBridge";
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (enable)
                rk.SetValue(appName, exePath);
            else
                rk.DeleteValue(appName, false);
        }

        // ... device management, sync, API connect/disconnect, log logic etc unchanged from previous version
        // Just ensure that all service references (ApiService, ConfigurationManager, etc) always use up-to-date config values.

        // Usage for handling a pending command and posting completion:
        private async Task HandlePendingCommandAndPush(List<AttendanceLog> logs, PendingCommand cmd)
        {
            await apiService.PushLogsWithCommandAsync(logs, cmd.CommandReference);
            Log("API", $"Posted logs with command reference {cmd.CommandReference}, server will mark as completed.");
        }
        // Loads settings from JSON/config file via ConfigurationManager
        private void LoadSettings()
        {
            deviceManager.LoadDevices();
        }

        // Re-populates the device list UI from stored devices
        private void PopulateDeviceLists()
        {
            lvDevices.Items.Clear();
            foreach (var device in deviceManager.Devices)
            {
                var item = new ListViewItem(device.Name) { Tag = device.Id };
                item.SubItems.Add($"{device.IPAddress} ({device.ConnectionType})");
                lvDevices.Items.Add(item);
            }
        }

        // Initializes and starts the sync timer
        private void InitializeSyncTimer()
        {
            syncTimer = new Timer { Interval = configManager.Config.SyncIntervalMs };
            syncTimer.Tick += async (s, e) => await PerformFullSyncAsync();
            syncTimer.Start();
        }

        // Standard log method for colored output
        private void Log(string source, string message, bool isError = false, Color? color = null)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => Log(source, message, isError, color)));
                return;
            }
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionColor = color ?? (isError ? Color.Red : Color.Black);
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] [{source}] {message}{Environment.NewLine}");
            rtbLog.ScrollToCaret();
        }

        // Device list row selection change
        private void UpdateDeviceStatusUI()
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                lblSelectedDevice.Text = "DEVICE: Not Selected";
                selectedMachineNumber = -1;
                return;
            }
            var selectedId = (Guid)lvDevices.SelectedItems[0].Tag;
            var device = deviceManager.Devices.FirstOrDefault(d => d.Id == selectedId);
            if (device != null)
            {
                selectedMachineNumber = device.MachineNumber;
                lblSelectedDevice.Text = $"DEVICE: {device.Name}";
            }
        }

        private async void BtnAddDevice_Click(object sender, EventArgs e)
        {
            var form = new Form()
            {
                Text = "Add Device",
                Width = 450,
                Height = 350,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblName = new Label() { Text = "Device Name:", Location = new Point(20, 20), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            TextBox txtName = new TextBox() { Location = new Point(20, 45), Width = 390, Height = 28 };

            Label lblIP = new Label() { Text = "IP Address:", Location = new Point(20, 85), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            TextBox txtIP = new TextBox() { Text = "192.168.1.55", Location = new Point(20, 110), Width = 390, Height = 28 };

            Label lblPort = new Label() { Text = "Port:", Location = new Point(20, 150), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            TextBox txtPort = new TextBox() { Text = "5005", Location = new Point(20, 175), Width = 390, Height = 28 };

            Label lblType = new Label() { Text = "Connection Type:", Location = new Point(20, 215), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            ComboBox cmbType = new ComboBox() { Items = { "LAN", "USB" }, Text = "LAN", Location = new Point(20, 240), Width = 390, Height = 28 };

            Button btnOk = new Button() { Text = "Add", Location = new Point(250, 290), Size = new Size(80, 35), DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Location = new Point(340, 290), Size = new Size(80, 35), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblName, txtName, lblIP, txtIP, lblPort, txtPort, lblType, cmbType, btnOk, btnCancel });
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txtName.Text))
            {
                deviceManager.Devices.Add(new DeviceConfig
                {
                    Id = Guid.NewGuid(),
                    Name = txtName.Text.Trim(),
                    IPAddress = txtIP.Text.Trim(),
                    Port = int.TryParse(txtPort.Text, out int port) ? port : 5005,
                    MachineNumber = deviceManager.Devices.Count + 1,
                    ConnectionType = cmbType.Text
                });
                deviceManager.SaveDevices();
                PopulateDeviceLists();
                Log("DEVICE", $"Device '{txtName.Text}' added successfully.", false, Color.Green);
            }
        }

        private async void BtnEditDevice_Click(object sender, EventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a device to edit.");
                return;
            }

            var selectedId = (Guid)lvDevices.SelectedItems[0].Tag;
            var device = deviceManager.Devices.FirstOrDefault(d => d.Id == selectedId);
            if (device == null) return;

            var form = new Form()
            {
                Text = "Edit Device",
                Width = 450,
                Height = 350,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblName = new Label() { Text = "Device Name:", Location = new Point(20, 20), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            TextBox txtName = new TextBox() { Text = device.Name, Location = new Point(20, 45), Width = 390, Height = 28 };

            Label lblIP = new Label() { Text = "IP Address:", Location = new Point(20, 85), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            TextBox txtIP = new TextBox() { Text = device.IPAddress, Location = new Point(20, 110), Width = 390, Height = 28 };

            Label lblPort = new Label() { Text = "Port:", Location = new Point(20, 150), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            TextBox txtPort = new TextBox() { Text = device.Port.ToString(), Location = new Point(20, 175), Width = 390, Height = 28 };

            Label lblType = new Label() { Text = "Connection Type:", Location = new Point(20, 215), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            ComboBox cmbType = new ComboBox() { Items = { "LAN", "USB" }, Text = device.ConnectionType, Location = new Point(20, 240), Width = 390, Height = 28 };

            Button btnOk = new Button() { Text = "Update", Location = new Point(250, 290), Size = new Size(80, 35), DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Location = new Point(340, 290), Size = new Size(80, 35), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblName, txtName, lblIP, txtIP, lblPort, txtPort, lblType, cmbType, btnOk, btnCancel });
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            if (form.ShowDialog() == DialogResult.OK)
            {
                device.Name = txtName.Text.Trim();
                device.IPAddress = txtIP.Text.Trim();
                device.Port = int.TryParse(txtPort.Text, out int port) ? port : 5005;
                device.ConnectionType = cmbType.Text;
                deviceManager.SaveDevices();
                PopulateDeviceLists();
                Log("DEVICE", $"Device '{txtName.Text}' updated successfully.", false, Color.Green);
            }
        }

        private async void BtnRemoveDevice_Click(object sender, EventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a device to remove.");
                return;
            }

            var selectedId = (Guid)lvDevices.SelectedItems[0].Tag;
            var device = deviceManager.Devices.FirstOrDefault(d => d.Id == selectedId);
            if (device == null) return;

            if (MessageBox.Show($"Are you sure you want to remove '{device.Name}'?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deviceManager.Devices.Remove(device);
                deviceManager.SaveDevices();
                PopulateDeviceLists();
                Log("DEVICE", $"Device '{device.Name}' removed successfully.", false, Color.Orange);
            }
        }

        private async void BtnDeviceConnect_Click(object sender, EventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a device first.");
                return;
            }

            if (isDeviceConnected)
            {
                await deviceManager.DisconnectAsync(selectedMachineNumber);
                isDeviceConnected = false;
                pnlDeviceStatus.BackColor = Color.Red;
                lblDeviceStatus.Text = "Status: Disconnected";
                btnDeviceConnect.Text = "Connect";
                Log("DEVICE", "Disconnected from device.");
            }
            else
            {
                await ConnectToDeviceAsync();
            }
        }

        private async Task ConnectToDeviceAsync()
        {
            try
            {
                var selectedId = (Guid)lvDevices.SelectedItems[0].Tag;
                var device = deviceManager.Devices.FirstOrDefault(d => d.Id == selectedId);
                if (device == null) return;

                Log("DEVICE", $"Connecting to {device.Name}...");
                bool connected = await deviceManager.ConnectAsync(device);

                if (connected)
                {
                    isDeviceConnected = true;
                    pnlDeviceStatus.BackColor = Color.LimeGreen;
                    lblDeviceStatus.Text = "Status: Connected";
                    btnDeviceConnect.Text = "Disconnect";
                    Log("DEVICE", $"Connected to {device.Name} successfully.", false, Color.Green);
                    await FetchAttendanceLogsAsync(device);
                }
                else
                {
                    Log("DEVICE", $"Failed to connect to {device.Name}.", true, Color.Red);
                }
            }
            catch (Exception ex)
            {
                Log("ERROR", $"Connection error: {ex.Message}", true, Color.Red);
            }
        }

        // Log communication event
        private void LogCommunicationEvent(string eventType, string details)
        {
            communicationHistory.Add($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{eventType}] {details}");
        }

        // Updated FetchAttendanceLogsAsync to log communication
        private async Task FetchAttendanceLogsAsync(DeviceConfig device)
        {
            try
            {
                Log("DEVICE", "Fetching attendance logs...");
                var logs = await deviceManager.FetchLogsAsync(device.MachineNumber);
                logHistory.AddRange(logs);

                if (logs.Count > 0)
                {
                    LogCommunicationEvent("DEVICE_FETCH", $"Fetched {logs.Count} records from {device.Name}");
                }

                Log("DEVICE", $"Retrieved {logs.Count} attendance records.", false, Color.Green);

                if (isApiConnected && logs.Count > 0)
                {
                    bool pushed = await apiService.PushLogsAsync(logs);
                    if (pushed)
                    {
                        LogCommunicationEvent("SERVER_PUSH", $"Pushed {logs.Count} records to server");
                        Log("API", $"Successfully pushed {logs.Count} logs to server.", false, Color.Green);
                    }
                }
                else if (logs.Count > 0)
                {
                    localStorage.SaveLogs(logs);
                    LogCommunicationEvent("OFFLINE_QUEUE", $"Queued {logs.Count} records (server unreachable)");
                    Log("LOCAL", $"Saved {logs.Count} logs to offline queue.");
                }
            }
            catch (Exception ex)
            {
                Log("ERROR", $"Fetch logs error: {ex.Message}", true, Color.Red);
                LogCommunicationEvent("ERROR", $"Fetch error: {ex.Message}");
            }
        }

        private async void BtnApiConnect_Click(object sender, EventArgs e)
        {
            if (isApiConnected) await DisconnectApiAsync();
            else await ConnectApiAsync();
        }

        private async Task ConnectApiAsync()
        {
            try
            {
                // Validate token is set
                if (string.IsNullOrWhiteSpace(apiService.AccessToken))
                {
                    Log("API", "❌ No access token configured", true, Color.Red);
                    MessageBox.Show("Please configure your access token in Settings tab first.", "Token Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedIndex = 2; // Switch to Settings tab
                    return;
                }

                // Validate API URL is set
                if (string.IsNullOrWhiteSpace(apiService.ApiUrl))
                {
                    Log("API", "❌ No API URL configured", true, Color.Red);
                    MessageBox.Show("Please configure your API URL in Settings tab first.", "URL Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedIndex = 2;
                    return;
                }

                Log("API", "🔐 Validating access token with server...");

                // Call authenticate with logging callback
                bool authenticated = await apiService.AuthenticateAsync(
                    msg => Log("API", msg, msg.StartsWith("❌"),
                        msg.StartsWith("✅") ? Color.Green : (msg.StartsWith("❌") ? Color.Red : Color.Black))
                );

                if (authenticated)
                {
                    isApiConnected = true;
                    pnlApiStatus.BackColor = Color.LimeGreen;
                    lblApiStatusText.Text = "Status: Connected ✓";
                    btnApiConnect.Text = "Disconnect";
                    lblApiStatus.Text = "API: Authenticated ✓";
                    Log("API", "✅ Token validated successfully. API is ready for sync.", false, Color.Green);
                }
                else
                {
                    isApiConnected = false;
                    pnlApiStatus.BackColor = Color.Red;
                    lblApiStatusText.Text = "Status: Failed ✗";
                    btnApiConnect.Text = "Retry";
                    lblApiStatus.Text = "API: Failed ✗";
                    Log("API", "❌ Token validation failed. Check your token and API URL in Settings.", true, Color.Red);
                }
            }
            catch (System.Exception ex)
            {
                Log("ERROR", $"API connection error: {ex.Message}", true, Color.Red);
                isApiConnected = false;
                pnlApiStatus.BackColor = Color.Red;
                lblApiStatusText.Text = "Status: Error ✗";
            }
        }



        private async Task DisconnectApiAsync()
        {
            isApiConnected = false;
            pnlApiStatus.BackColor = Color.Red;
            lblApiStatusText.Text = "Status: Disconnected";
            btnApiConnect.Text = "Connect";
            lblApiStatus.Text = "API: Not Authenticated";
            Log("API", "Disconnected from server.");
        }

        private async Task PerformFullSyncAsync()
        {
            if (isSyncing)
            {
                Log("SYSTEM", "Sync already in progress. Please wait.");
                return;
            }
            isSyncing = true;
            try
            {
                Log("SYSTEM", "--- Sync cycle started ---");
                var pendingLogs = localStorage.LoadPendingLogs();

                if (isApiConnected)
                {
                    if (pendingLogs.Count > 0)
                    {
                        bool pushed = await apiService.PushLogsAsync(pendingLogs);
                        if (pushed)
                        {
                            localStorage.ClearLogs();
                            Log("API", $"Successfully synced {pendingLogs.Count} pending logs.", false, Color.Green);
                        }
                    }
                    else
                    {
                        Log("SYSTEM", "No pending logs to sync.");
                    }
                }
                else
                {
                    Log("API", "Not connected to server. Logs will be synced when connection is restored.");
                }

                lblLastSync.Text = $"Last Sync: {DateTime.Now:HH:mm:ss}";
                Log("SYSTEM", "--- Sync cycle completed ---");
            }
            finally
            {
                isSyncing = false;
            }
        }

        // Updated ShowCommunicationLog with device fetches AND server pushes
        private void ShowCommunicationLog()
        {
            var form = new Form()
            {
                Text = "Communication Log - Device & Server Activity",
                Width = 900,
                Height = 600,
                StartPosition = FormStartPosition.CenterParent
            };

            var rtb = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Consolas", 9),
                BackColor = Color.White
            };

            // Combine device logs AND communication events
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== DEVICE FETCHES ===");
            if (logHistory.Count > 0)
            {
                foreach (var log in logHistory)
                {
                    sb.AppendLine($"[{log.Timestamp:yyyy-MM-dd HH:mm:ss}] Device: {log.SerialNumber} | User: {log.UserId} | Type: {log.Type}");
                }
            }
            else
            {
                sb.AppendLine("No device records fetched yet.");
            }

            sb.AppendLine("\n=== SERVER COMMUNICATION ===");
            if (communicationHistory.Count > 0)
            {
                foreach (var evt in communicationHistory)
                {
                    sb.AppendLine(evt);
                }
            }
            else
            {
                sb.AppendLine("No server communication yet.");
            }

            rtb.Text = sb.ToString();
            form.Controls.Add(rtb);
            form.ShowDialog();
        }

        // Enhanced ShowPendingQueue with TWO sections
        private void ShowPendingQueue()
        {
            var form = new Form()
            {
                Text = "Pending Queue Management",
                Width = 900,
                Height = 600,
                StartPosition = FormStartPosition.CenterParent
            };

            // Create TabControl for two sections
            var tabQueue = new TabControl()
            {
                Dock = DockStyle.Fill
            };

            // TAB 1: PENDING LOGS (Awaiting Server Push)
            var tabPendingLogs = new TabPage("Pending Logs (Awaiting Server)")
            {
                Padding = new Padding(10)
            };

            var rtbPendingLogs = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Consolas", 9),
                BackColor = Color.White
            };

            var pendingLogs = localStorage.LoadPendingLogs();
            if (pendingLogs.Count > 0)
            {
                StringBuilder sbLogs = new StringBuilder();
                sbLogs.AppendLine($"Total Pending Records: {pendingLogs.Count}\n");
                sbLogs.AppendLine("═══════════════════════════════════════════════════════════════");

                foreach (var log in pendingLogs)
                {
                    sbLogs.AppendLine($"[{log.Timestamp:yyyy-MM-dd HH:mm:ss}]");
                    sbLogs.AppendLine($"  Device: {log.SerialNumber}");
                    sbLogs.AppendLine($"  User ID: {log.UserId}");
                    sbLogs.AppendLine($"  Type: {log.Type}");
                    sbLogs.AppendLine($"  Status: PENDING - Waiting for server connection");
                    sbLogs.AppendLine("───────────────────────────────────────────────────────────────");
                }
                rtbPendingLogs.Text = sbLogs.ToString();
            }
            else
            {
                rtbPendingLogs.Text = "✓ No pending logs. All records have been pushed to server.";
            }

            // Add button to retry push
            var btnRetryPush = new Button()
            {
                Text = "Retry Push Pending Logs",
                Location = new Point(10, 10),
                Size = new Size(200, 30),
                Dock = DockStyle.Top
            };
            btnRetryPush.Click += async (s, e) =>
            {
                if (isApiConnected && pendingLogs.Count > 0)
                {
                    bool pushed = await apiService.PushLogsAsync(pendingLogs);
                    if (pushed)
                    {
                        localStorage.ClearLogs();
                        MessageBox.Show($"✓ Successfully pushed {pendingLogs.Count} logs!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Log("API", $"Retried and successfully pushed {pendingLogs.Count} pending logs.", false, Color.Green);
                        rtbPendingLogs.Text = "✓ All logs pushed successfully!";
                    }
                    else
                    {
                        MessageBox.Show("✗ Push failed. Try again later.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (!isApiConnected)
                {
                    MessageBox.Show("✗ Server not connected. Connect to API first.", "Not Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            tabPendingLogs.Controls.Add(btnRetryPush);
            tabPendingLogs.Controls.Add(rtbPendingLogs);

            // TAB 2: PENDING COMMANDS (Awaiting Device Execution)
            var tabPendingCommands = new TabPage("Pending Commands (Awaiting Device)")
            {
                Padding = new Padding(10)
            };

            var rtbPendingCommands = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Consolas", 9),
                BackColor = Color.White
            };

            // Fetch pending commands from server
            Task.Run(async () =>
            {
                try
                {
                    var pendingCommands = await apiService.GetPendingCommandsAsync();

                    if (pendingCommands.Count > 0)
                    {
                        StringBuilder sbCommands = new StringBuilder();
                        sbCommands.AppendLine($"Total Pending Commands: {pendingCommands.Count}\n");
                        sbCommands.AppendLine("═══════════════════════════════════════════════════════════════");

                        foreach (var cmd in pendingCommands)
                        {
                            sbCommands.AppendLine($"[{cmd.CreatedAt:yyyy-MM-dd HH:mm:ss}]");
                            sbCommands.AppendLine($"  Device Serial: {cmd.SerialNumber}");
                            sbCommands.AppendLine($"  Command: {cmd.CommandText}");
                            sbCommands.AppendLine($"  Reference: {cmd.CommandReference}");
                            sbCommands.AppendLine($"  Status: PENDING - Waiting for device execution");
                            sbCommands.AppendLine("───────────────────────────────────────────────────────────────");
                        }
                        rtbPendingCommands.Invoke((MethodInvoker)delegate
                        {
                            rtbPendingCommands.Text = sbCommands.ToString();
                        });
                    }
                    else
                    {
                        rtbPendingCommands.Invoke((MethodInvoker)delegate
                        {
                            rtbPendingCommands.Text = "✓ No pending commands. All devices are up to date.";
                        });
                    }
                }
                catch (Exception ex)
                {
                    rtbPendingCommands.Invoke((MethodInvoker)delegate
                    {
                        rtbPendingCommands.Text = $"✗ Error fetching pending commands: {ex.Message}";
                    });
                }
            });

            // Add button to retry command fetch
            var btnRetryCommands = new Button()
            {
                Text = "Refresh Pending Commands",
                Location = new Point(10, 10),
                Size = new Size(200, 30),
                Dock = DockStyle.Top
            };
            btnRetryCommands.Click += async (s, e) =>
            {
                if (isApiConnected)
                {
                    try
                    {
                        var cmds = await apiService.GetPendingCommandsAsync();
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"Total Pending Commands: {cmds.Count}\n");
                        foreach (var cmd in cmds)
                        {
                            sb.AppendLine($"[{cmd.CreatedAt:yyyy-MM-dd HH:mm:ss}] {cmd.SerialNumber} | {cmd.CommandText} | Ref: {cmd.CommandReference}");
                        }
                        rtbPendingCommands.Text = cmds.Count > 0 ? sb.ToString() : "✓ No pending commands.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("✗ Server not connected.", "Not Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            tabPendingCommands.Controls.Add(btnRetryCommands);
            tabPendingCommands.Controls.Add(rtbPendingCommands);

            // Add tabs to control
            tabQueue.TabPages.Add(tabPendingLogs);
            tabQueue.TabPages.Add(tabPendingCommands);

            form.Controls.Add(tabQueue);
            form.ShowDialog();
        }


    }
}
