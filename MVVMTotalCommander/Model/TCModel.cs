using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MVVMTotalCommander.Model
{
    internal sealed class TCModel
    {
        public void Copy(string sourceFilePath, string fileName, string destinationFolder) => File.Copy(sourceFilePath, Path.Combine(destinationFolder, fileName));
    }
}
