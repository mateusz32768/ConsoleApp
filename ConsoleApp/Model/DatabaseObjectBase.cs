using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public abstract class DatabaseObjectBase
    {
        public string Name { get; set; }
        public string Schema { get; set; }
    }
}
