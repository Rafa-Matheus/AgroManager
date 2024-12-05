using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHS
{
    public class SQLParams
    {

        public SQLParams(string query, params object[] values)
        {
            Query = query;
            Values = values;
        }

        public string Query { get; set; }

        public object[] Values { get; set; }

        public override string ToString()
        {
            return Query;
        }

    }
}