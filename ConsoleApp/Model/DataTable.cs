using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class DataTable:DatabaseObjectBase
    {
        public const string objectName = "TABLE";
        public List<DataColumn> Columns { get; set; } = new List<DataColumn>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"\tTable '{this.Schema}.{this.Name}' ({this.Columns.Count} columns)");
            foreach (var col in Columns)
                stringBuilder.AppendLine($"\t\tColumn '{col.Name}' with {col.DataType} data type {(col.Nullable ? "accepts nulls" : "with no nulls")}");
            return stringBuilder.ToString();
        }
    }
}
