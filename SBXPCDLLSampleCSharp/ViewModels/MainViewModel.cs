using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiometricAttendanceBridge.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace BiometricAttendanceBridge.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DeviceConfig> Devices { get; set; } = new ObservableCollection<DeviceConfig>();

        public ObservableCollection<AttendanceLog> LogHistory { get; set; } = new ObservableCollection<AttendanceLog>();
        public ICommand SyncNowCommand { get; set; }
        public ICommand OpenConfigCommand { get; set; }

        // Implement PropertyChanged and other logic as needed.
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        

    }


    }
