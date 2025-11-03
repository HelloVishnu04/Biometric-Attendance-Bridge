using System;
using System.Windows.Forms;

namespace BiometricAttendanceBridge
{
    static class Program
    {
        public static int gMachineNumber;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
