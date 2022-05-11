using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTotalCommander.Model
{
    enum Type
    {
        FILE,
        DIRECTORY
    }

    internal sealed class DataType
    {
        public Type DType { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        public override string ToString() => DType == Type.DIRECTORY ? $"<D> {Name}" : Name;
    }
}
