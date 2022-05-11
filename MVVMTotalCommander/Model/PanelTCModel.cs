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

        public DataType SelectedType { get; set; }
        private List<DataType> types { get; set; }
        public List<DataType> Types
        {
            get => types;
            set => types = value;
        }

        public List<string> LoadDrives() => Directory.GetLogicalDrives().ToList();
        public List<DataType> LoadData()
        {
            List<string> directories = new List<string>();
            directories.AddRange(Directory.GetDirectories(CurrentPath).ToList());

            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(CurrentPath).ToList());

            List<DataType> data = new List<DataType>();
            DirectoryInfo directoryInfo = new DirectoryInfo(CurrentPath);

            if (directoryInfo.Parent != null)
                data.Add(new DataType
                {
                    DType = Type.DIRECTORY,
                    Path = directoryInfo.Parent.FullName,
                    Name = "..."
                });

            directories.ForEach(d =>
            {
                data.Add(new DataType 
                {
                    DType = Type.DIRECTORY, 
                    Path = d, 
                    Name = Path.GetFileName(d) 
                });
            });

            files.ForEach(f =>
            {
                data.Add(new DataType
                {
                    DType = Type.FILE,
                    Path = f,
                    Name = Path.GetFileName(f)
                });
            });

            return data;
        }  
        
        public string ChangeDirectory()
        {
            if (SelectedType == null)
                return CurrentPath;

            if (SelectedType.DType == Type.DIRECTORY)
                return SelectedType.Path;

            return CurrentPath;
        }
    }
}
