using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHS.SQL
{
    public class SQLEnumItem
    {

        public SQLEnumItem(string title, string value)
        {
            Title = title;
            Value = value;
        }

        public string Title { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Title;
        }

    }
}
