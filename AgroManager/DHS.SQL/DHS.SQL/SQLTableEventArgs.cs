using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHS.SQL
{
    public class SQLTableEventArgs : EventArgs
    {
        public string Table { get; set; }
        public int Id { get; set; }
    }
}
