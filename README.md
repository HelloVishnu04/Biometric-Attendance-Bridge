# Biometric Attendance Bridge

A production-ready C# Windows application that bridges biometric devices with a web-based attendance management system. Real-time synchronization of attendance logs, user management, and command execution with offline queue support.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [System Requirements](#system-requirements)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage Guide](#usage-guide)
- [Architecture](#architecture)
- [API Integration](#api-integration)
- [Database Schema](#database-schema)
- [Troubleshooting](#troubleshooting)
- [Development](#development)

---

## 🎯 Overview

**Biometric Attendance Bridge** connects biometric devices (fingerprint scanners) to a centralized attendance management system via a web API. It:

- **Fetches** attendance logs from biometric devices in real-time
- **Syncs** logs to a remote server with permanent access token authentication
- **Manages** users enrolled on biometric devices
- **Executes** server-side commands on devices
- **Queues** data when server is unreachable (offline support)
- **Tracks** pending commands and their completion status

**Use Cases:**
- Multi-location attendance management
- Real-time log synchronization
- Device command execution and monitoring
- Offline data persistence with auto-sync

---

## ✨ Features

### Dashboard
- **Device Management**: Add, edit, remove biometric devices
- **Connection Status**: Real-time device and server connection indicators
- **One-Click Sync**: Manual synchronization of attendance logs
- **Activity Log**: Live streaming of all operations and errors
- **Communication Log**: View all device fetches and server pushes
- **Pending Queue**: Monitor logs awaiting server push and commands awaiting device execution

### User Management
- **Paginated List**: Browse enrolled users on selected device (25 per page)
- **User Details**: Enrollment ID, name, privilege level, status
- **One-Click Refresh**: Fetch latest user list from device

### Settings
- **API Configuration**: URL and permanent access token
- **Connection Testing**: Validate credentials before saving
- **Auto-Start**: Launch application at Windows login (background mode)
- **Activity Log Management**: Clear logs with confirmation
- **Real-time Log Size**: Monitor log storage usage

### Sync Management
- **Automatic Sync**: Configurable interval (default: 5 minutes)
- **Offline Queue**: Store logs locally when server unavailable
- **Command Tracking**: Monitor server commands with completion status
- **Batch Processing**: Send multiple logs in single request

---

## 🖥️ System Requirements

### Windows
- **OS**: Windows 7 or higher (32-bit or 64-bit)
- **.NET Framework**: 4.6.1 or higher
- **RAM**: Minimum 512 MB, recommended 2 GB
- **Storage**: 100 MB for application + logs

### Biometric Device
- **SDK**: SBXPC DLL (device-specific)
- **Connection**: USB or LAN (TCP/IP)
- **Supported Devices**: ZKTeco, Matrix, and compatible devices using SBXPC protocol

### Server
- **PHP**: 7.4 or higher
- **MySQL**: 5.7 or higher
- **HTTPS**: SSL certificate recommended
- **Bandwidth**: Minimum 2 Mbps for real-time sync

---

## 📦 Installation

### Prerequisites
1. Install .NET Framework 4.6.1+
2. Download the biometric device SDK (SBXPC DLL)
3. Have access to your biometric device IP address and port

### Step 1: Clone Repository

```bash
git clone https://github.com/HelloVishnu04/Biometric-Attendance-Bridge.git
cd BiometricAttendanceBridge
```

### Step 2: Install Dependencies

```
Package Manager Console:
Install-Package Newtonsoft.Json -Version 12.0.3
```

### Step 3: Place Device SDK

```
Copy SBXPC DLL files to:
├── bin/
│   ├── SBXPCDLL.dll (32-bit)
│   └── SBXPCDLL64.dll (64-bit)
```

### Step 4: Build Solution

```bash
# Visual Studio
Open BiometricAttendanceBridge.sln and Build > Build Solution (Ctrl+Shift+B)

# Or Command Line
dotnet build BiometricAttendanceBridge.csproj
```

### Step 5: Server Setup (PHP Webhook)

1. **Upload to Server**
   ```
   Upload AttendanceWebhook.php to: /admin/attendance/
   ```

2. **Create Database**
   ```bash
   mysql -u root -p < database_schema.sql
   ```

3. **Configure PHP**
   ```php
   // In AttendanceWebhook.php
   private $validTokens = array(
       'your-permanent-access-token-here',
       'test-token-12345'
   );
   ```

4. **Test Connection**
   ```bash
   curl -X POST https://domain.in/admin/attendance/webhook.php \
     -H "Content-Type: application/json" \
     -d '{"access_token":"test-token-12345","test_connection":true}'
   ```

---

## ⚙️ Configuration

### Initial Setup

1. **Launch Application**
   - First run creates `config.json` in application directory

2. **Open Settings Tab**
   - Enter API URL: `https://domain.in/admin/attendance/webhook.php`
   - Enter Access Token: (from server configuration)
   - Enable "Start at login" if needed
   - Click "Test Connection"

3. **Add Device**
   - Go to Dashboard → Device Management
   - Click "Add"
   - Enter device details:
     - **Name**: Device identifier (e.g., "Office-Scanner-1")
     - **IP Address**: Device IP (e.g., 192.168.1.55)
     - **Port**: Default 5005 for ZKTeco
     - **Connection Type**: LAN or USB
   - Click "Add"

### config.json Structure

```json
{
  "ApiBaseUrl": "https://domain.in/admin/attendance/webhook.php",
  "AccessToken": "your-token-here",
  "AutoStart": true,
  "SyncIntervalMs": 300000,
  "Devices": [
    {
      "Id": "uuid",
      "Name": "Office-Scanner",
      "IPAddress": "192.168.1.55",
      "Port": 5005,
      "MachineNumber": 1,
      "ConnectionType": "LAN"
    }
  ]
}
```

---

## 🚀 Usage Guide

### First-Time Connection

1. **Add Biometric Device**
   - Go to Dashboard
   - Click "Add" device
   - Enter device IP and port
   - Click "Connect" to test connection

2. **Configure API**
   - Go to Settings
   - Enter API URL and token
   - Click "Test Connection"
   - If successful, click "Save Settings"

3. **Start Syncing**
   - Select device from list
   - Click "Sync All Now" button
   - Monitor Activity Log for progress

### Daily Operations

**Dashboard Workflow:**
```
1. Check Connection Status
   - Device indicator should be green
   - API indicator should be green

2. Monitor Activity Log
   - Watch for sync operations
   - Note any errors (red text)

3. Manual Sync (if needed)
   - Select device
   - Click "Sync All Now"

4. View Logs
   - "View Communication Log" → Device fetches & server pushes
   - "View Pending Queue" → Offline logs & pending commands
```

**User Management:**
```
1. Select device from list
2. Click "Refresh Users" in User Management tab
3. Browse through paginated user list (25 per page)
4. View user details: ID, name, privilege level, status
```

**Settings Management:**
```
1. Update API URL or token if needed
2. Click "Test Connection" before saving
3. Enable/disable "Start at login"
4. Clear activity log when needed
5. Monitor log size in real-time
```

---

## 🏗️ Architecture

### Components

```
BiometricAttendanceBridge/
├── Models/
│   ├── DeviceConfig.cs          # Device configuration
│   ├── AttendanceLog.cs         # Attendance record
│   ├── PendingCommand.cs        # Server commands
│   └── Configuration.cs         # App settings
├── Services/
│   ├── DeviceManager.cs         # Device operations
│   ├── ApiService.cs            # Server communication
│   ├── LocalStorageService.cs   # Offline queue
│   └── ConfigurationManager.cs  # Settings persistence
├── MainForm.cs                  # UI and main logic
├── Program.cs                   # Entry point
└── sbxpc/
    └── SBXPCDLL.cs              # Device SDK wrapper
```

### Data Flow

```
Biometric Device
    ↓ (SBXPC DLL)
DeviceManager
    ↓ (Fetch logs)
AttendanceLog Collection
    ↓ (POST)
ApiService
    ↓ (Network check)
    ├→ Server Reachable? YES
    │   ├→ Insert in DB
    │   └→ Log: "Pushed to server"
    └→ Server Unreachable? NO
        ├→ LocalStorageService
        └→ Log: "Queued for later"

Periodic Sync Timer (every 5 min)
    ↓
PerformFullSyncAsync()
    ├→ Fetch pending offline logs
    ├→ Check API connection
    ├→ Push to server
    └→ Update pending queue display
```

### Threading Model

- **Main Thread**: UI operations, user interactions
- **Sync Timer**: Background periodic sync (5-minute interval)
- **Async Tasks**: Network operations (non-blocking)
- **Background Thread**: Log size calculation

---

## 🔌 API Integration

### Webhook Endpoints

All requests use **POST** method to: `https://domain.in/admin/attendance/webhook.php`

#### 1. Connection Test

**Request:**
```json
{
    "access_token": "test-token-12345",
    "test_connection": true
}
```

**Response (Success 200):**
```json
{
    "success": true,
    "message": "✓ Connection successful - token is valid",
    "timestamp": "2025-11-04 12:00:00",
    "data": {
        "server_time": "2025-11-04 12:00:00",
        "server_status": "operational",
        "php_version": "8.0.0",
        "database_status": "connected"
    }
}
```

#### 2. Push Attendance Logs

**Request:**
```json
{
    "access_token": "test-token-12345",
    "data": [
        {
            "SerialNumber": "Device_1",
            "UserId": 101,
            "Timestamp": "2025-11-04 12:00:00",
            "Type": "IN"
        }
    ]
}
```

**Response (Success 200):**
```json
{
    "success": true,
    "message": "1 attendance logs processed",
    "timestamp": "2025-11-04 12:00:00",
    "data": {
        "inserted": 1,
        "total_received": 1,
        "errors": [],
        "command_reference": "none"
    }
}
```

#### 3. Push Logs with Command Reference

**Request:**
```json
{
    "access_token": "test-token-12345",
    "command_reference": "cmd-2025-001",
    "data": [...]
}
```

**Response:**
```json
{
    "success": true,
    "message": "1 attendance logs processed",
    "data": {
        "inserted": 1,
        "command_reference": "processed"
    }
}
```

#### 4. Fetch Pending Commands

**Request:** GET `https://domain.in/admin/attendance/webhook.php?access-token=test-token-12345`

**Response (Success 200):**
```json
{
    "success": true,
    "message": "Pending commands retrieved successfully",
    "timestamp": "2025-11-04 12:00:00",
    "data": [
        {
            "SerialNumber": "Device_1",
            "CommandText": "Clear attendance logs",
            "CommandReference": "cmd-2025-001",
            "CreatedAt": "2025-11-04 12:00:00"
        }
    ]
}
```

### Error Responses

**401 Unauthorized (Invalid Token):**
```json
{
    "success": false,
    "message": "Invalid or expired access token",
    "timestamp": "2025-11-04 12:00:00"
}
```

**400 Bad Request (Invalid Payload):**
```json
{
    "success": false,
    "message": "Request must include either 'data' array or 'test_connection: true'",
    "timestamp": "2025-11-04 12:00:00"
}
```

---

## 💾 Database Schema

### attendance_logs Table

```sql
CREATE TABLE attendance_logs (
    id INT PRIMARY KEY AUTO_INCREMENT,
    serial_number VARCHAR(50) NOT NULL,
    user_id INT NOT NULL,
    log_timestamp DATETIME NOT NULL,
    log_type ENUM('IN', 'OUT') DEFAULT 'IN',
    received_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    command_reference VARCHAR(100),
    INDEX idx_serial (serial_number),
    INDEX idx_timestamp (log_timestamp),
    INDEX idx_received (received_at)
);
```

### pending_commands Table

```sql
CREATE TABLE pending_commands (
    id INT PRIMARY KEY AUTO_INCREMENT,
    serial_number VARCHAR(50) NOT NULL,
    command_text TEXT NOT NULL,
    command_reference VARCHAR(100) UNIQUE NOT NULL,
    status ENUM('pending', 'completed', 'failed') DEFAULT 'pending',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    completed_at DATETIME,
    INDEX idx_status (status),
    INDEX idx_reference (command_reference)
);
```

---

## 🐛 Troubleshooting

### Connection Issues

**Problem:** "Unable to connect to device"
```
Solution:
1. Verify device IP address (ping 192.168.1.55)
2. Check device is powered on
3. Confirm port number (default 5005 for ZKTeco)
4. Check firewall rules on network
5. Try USB connection if LAN fails
```

**Problem:** "API connection timeout"
```
Solution:
1. Verify API URL is correct (https://domain.in/admin/attendance/webhook.php)
2. Check internet connectivity
3. Verify token is valid in Settings
4. Check server firewall allows connections
5. Verify SSL certificate (if using HTTPS)
```

### Authentication Issues

**Problem:** "Invalid access token (401)"
```
Solution:
1. Copy token exactly from server config
2. No spaces before/after token
3. Token is case-sensitive
4. Verify token hasn't expired on server
5. Click "Test Connection" in Settings
```

**Problem:** "Token is empty"
```
Solution:
1. Go to Settings tab
2. Enter access token in the field
3. Click "Test Connection"
4. Click "Save Settings"
```

### Data Issues

**Problem:** "No pending logs in queue"
```
Solution:
This is normal when:
- All logs have been synced to server
- Server is currently reachable
- No pending commands from server
Check "View Pending Queue" to confirm
```

**Problem:** "Communication log shows errors"
```
Solution:
1. Check device is still connected (green indicator)
2. Check API is still connected (green indicator)
3. Review error message in Activity Log
4. Check device has recent attendance data
5. Try manual sync from Dashboard
```

### Performance Issues

**Problem:** "Application runs slow"
```
Solution:
1. Clear Activity Log (Settings tab)
2. Check RAM usage (Task Manager)
3. Reduce sync interval if too frequent
4. Check network bandwidth
5. Restart application
```

**Problem:** "High CPU usage"
```
Solution:
1. Reduce sync interval (longer interval = less CPU)
2. Clear old communication logs
3. Check for device connection loop
4. Restart application
5. Update .NET Framework
```

---

## 👨‍💻 Development

### Project Structure

```
BiometricAttendanceBridge/
├── App.config                   # Application configuration
├── BiometricAttendanceBridge.csproj
├── Program.cs                   # Entry point
├── MainForm.cs                  # Main UI (1200+ lines)
├── Models/
│   ├── DeviceConfig.cs
│   ├── AttendanceLog.cs
│   └── PendingCommand.cs
├── Services/
│   ├── DeviceManager.cs
│   ├── ApiService.cs
│   ├── LocalStorageService.cs
│   └── ConfigurationManager.cs
└── sbxpc/
    └── SBXPCDLL.cs              # SBXPC wrapper
```

### Adding New Features

**Example: Add Device Status Monitoring**

```csharp
// In DeviceManager.cs
public async Task<DeviceStatus> GetDeviceStatusAsync(DeviceConfig device)
{
    try
    {
        // Connect to device
        // Query device status
        // Return status object
        return deviceStatus;
    }
    catch (Exception ex)
    {
        // Handle error
        return null;
    }
}

// In MainForm.cs - Add to Dashboard
private async void BtnCheckStatus_Click(object sender, EventArgs e)
{
    var status = await deviceManager.GetDeviceStatusAsync(selectedDevice);
    Log("DEVICE", $"Status: {status.Description}");
}
```

### Building Release Package

```bash
# Build Release
dotnet build -c Release

# Create Installer (using NSIS or Wix)
"C:\Program Files (x86)\NSIS\makensis.exe" installer.nsi

# Output
bin/Release/BiometricAttendanceBridge.exe
```

### Testing

```csharp
// Unit Test Example
[TestClass]
public class ApiServiceTests
{
    [TestMethod]
    public async Task AuthenticateAsync_ValidToken_ReturnsTrue()
    {
        var apiService = new ApiService(configManager);
        bool result = await apiService.AuthenticateAsync();
        Assert.IsTrue(result);
    }
}
```

---

## 📝 License

This project is licensed under the MIT License - see LICENSE file for details.

---

## 👤 Author

**Krishna Kumar**  
Developed with assistance from Gemini Pro AI

---

## 📧 Support

For issues, feature requests, or contributions:

1. **Check Troubleshooting** section above
2. **Review Activity Log** in application
3. **Check Pending Queue** for stuck operations
4. **Test Connection** in Settings
5. **Contact Server Administrator** if API issues persist

---

## 🔄 Changelog

### Version 1.0.0 (2025-11-04)
- Initial release
- Device management (Add/Edit/Remove)
- Real-time attendance log sync
- User management with pagination
- Settings and configuration
- Offline queue support
- Command execution and tracking
- Communication logging
- Auto-start functionality
- Activity log management

---

## 🎯 Roadmap

- [ ] Multi-language support
- [ ] Advanced reporting and analytics
- [ ] Mobile app for remote management
- [ ] Cloud backup and disaster recovery
- [ ] Biometric template management
- [ ] Advanced scheduling and automation
- [ ] Integration with HRMS systems

---

**Last Updated:** November 4, 2025  
**Version:** 1.0.0  
**Status:** Production Ready ✓
