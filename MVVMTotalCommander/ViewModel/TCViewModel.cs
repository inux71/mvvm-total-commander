using System.Windows.Input;
using System.ComponentModel;
using System.IO;

namespace MVVMTotalCommander.ViewModel
{
    internal sealed class TCViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PanelTCViewModel source;
        public PanelTCViewModel Source
        {
            get => source;
            set 
            {
                source = value;
                OnPropertyChanged(nameof(Source));
            }
        }
        private  PanelTCViewModel destination;
        public PanelTCViewModel Destination
        {
            get => destination;
            set
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        private ICommand copyCommand;
        public ICommand CopyCommand => copyCommand ?? (copyCommand = new RelayCommand(
                o =>
                {
                    if (source.SelectedType.DType == Model.Type.FILE && destination.CurrentPath != null)
                    {
                        File.Copy(source.SelectedType.Path, Path.Combine(destination.CurrentPath, source.SelectedType.Name));
                        Destination.CurrentPath = Destination.CurrentPath;
                    }
                },
                o => source.SelectedType != null
            ));

        public TCViewModel()
        {
            source = new PanelTCViewModel();
            destination = new PanelTCViewModel();
        }

        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}