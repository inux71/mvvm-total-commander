using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MVVMTotalCommander.Model
{
    internal sealed class PanelTCModel
    {
        public string CurrentPath { get; set; }

        public string SelectedDrive { get; set; }
        private List<string> drives { get; set; }
        public List<string> Drives
        {
            get => drives;
            set => drives = value;
        }

        public List<string> LoadDrives() => Directory.GetLogicalDrives().ToList();
    }
}
