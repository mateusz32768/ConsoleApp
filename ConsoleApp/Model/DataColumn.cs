using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class DataColumn:DatabaseObjectBase
    {
        public const string objectName = "COLUMN";
        public string DataType { get;  set; }
        public bool Nullable { get;  set; }
    }
}
