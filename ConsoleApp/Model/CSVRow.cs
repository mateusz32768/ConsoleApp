using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp.Model
{
    internal class CSVRow
    {
        public string Type { get; private set; }
        public string Name { get; private set; }
        public string Schema { get; private set; }
        public string ParentName { get; private set; }
        public string ParentType { get; private set; }
        public string DataType { get; private set; }
        public bool IsNullable { get; private set; }

        public CSVRow(string line)
        {
            var rowFields = line.Split(';');

            this.Type = NormalizeData(rowFields[0], true);
            this.Name = NormalizeData(rowFields[1]);
            this.Schema = NormalizeData(rowFields[2]);
            if (rowFields.Length > 3)
                this.ParentName = NormalizeData(rowFields[3]);
            if (rowFields.Length > 4)
                this.ParentType = NormalizeData(rowFields[4],true);
            if (rowFields.Length > 5)
                this.DataType = NormalizeData(rowFields[5]);
            if (rowFields.Length > 6)
            {
                string isNullable = NormalizeData(rowFields[6],true);
                this.IsNullable = (isNullable == "1" || isNullable == "NULLABLE");
            }
        }

        private string NormalizeData(string val, bool toUpper=false)
        {
            val= val.Trim();
            if (toUpper) 
                val = val.ToUpper();
            return val;
        }
    }
}
