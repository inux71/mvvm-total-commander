using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMTotalCommander.ViewModel
{
    internal sealed class PanelTCViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.PanelTCModel panelTCModel;

        public string CurrentPath
        {
            get => panelTCModel.CurrentPath;
            set
            {
                panelTCModel.CurrentPath = value;
                OnPropertyChanged(nameof(CurrentPath));
            }
        }

        public string SelectedDrive
        {
            get => panelTCModel.SelectedDrive;
            set
            {
                panelTCModel.SelectedDrive = value;
                OnPropertyChanged(nameof(SelectedDrive));
            }
        }
        public List<string> Drives
        {
            get => panelTCModel.Drives;
            set
            {
                panelTCModel.Drives = panelTCModel.LoadDrives();
                OnPropertyChanged(nameof(Drives));
            }
        }

        private ICommand loadDrivesCommand;
        public ICommand LoadDrivesCommand => loadDrivesCommand ?? (loadDrivesCommand = new RelayCommand(
                o => Drives = panelTCModel.LoadDrives(),
                o => true
            ));

        private ICommand driveSelectedCommand;
        public ICommand DriveSelectedCommand => driveSelectedCommand ?? (driveSelectedCommand = new RelayCommand(
                o => CurrentPath = SelectedDrive,
                o => true
            ));

        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public PanelTCViewModel() => panelTCModel = new Model.PanelTCModel();
    }
}
