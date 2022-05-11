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

        public Model.DataType SelectedType
        {
            get => panelTCModel.SelectedType;
            set
            {
                panelTCModel.SelectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
        public List<Model.DataType> Types
        {
            get => panelTCModel.Types;
            set
            {
                panelTCModel.Types = panelTCModel.LoadData();
                OnPropertyChanged(nameof(Types));
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

        private ICommand loadDataCommand;
        public ICommand LoadDataCommand => loadDataCommand ?? (loadDataCommand = new RelayCommand(
                o => Types = panelTCModel.LoadData(),
                o => true
            ));

        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public PanelTCViewModel() => panelTCModel = new Model.PanelTCModel();
    }
}
