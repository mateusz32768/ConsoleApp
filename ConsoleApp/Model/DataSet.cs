using ConsoleApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public class DataSet
    {
        public List<Database> Databases {get;private set;}= new List<Database>();

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach (var db in Databases)
                stringBuilder.AppendLine(db.ToString());
            return stringBuilder.ToString();
        }

    }
}
