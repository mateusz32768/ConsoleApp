using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class Database
    {
        public const string objectName = "DATABASE";
        public string Name { get; set; }
        public List<DataTable> Tables { get; set; } = new List<DataTable>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Database '{this.Name}' ({this.Tables.Count} tables)");
            foreach (var tab in Tables)
                stringBuilder.AppendLine(tab.ToString());
            return stringBuilder.ToString();
        }
    }
}
