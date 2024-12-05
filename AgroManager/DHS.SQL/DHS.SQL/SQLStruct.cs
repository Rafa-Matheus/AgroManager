using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHS.SQL
{
    public class SQLStruct
    {

        public SQLStruct(string name, string title, string type)
        {
            Name = name;
            Title = title;
            Type = type;
            Properties = new SQLProperty[0];
            Fields = new List<SQLStruct>();
            IsVisible = true;
            ChildTable = "";
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public SQLProperty[] Properties { get; set; }

        public string Type { get; set; }

        public List<SQLStruct> Fields { get; set; }

        //public string ParentTable { get; set; }

        public string ChildTable { get; set; }

        public bool IsVisible { get; set; }

        public bool IsPrimary { get; set; }

        //Está ocupada
        //public bool IsBusy { get; set; }

        public bool ContainsProperty(string name)
        {
            for (int i = 0; i < Properties.Length; i++)
                if (Properties[i].Name.Equals(name))
                    return true;

            return false;
        }

        public string GetPropertyValue(string name)
        {
            for (int i = 0; i < Properties.Length; i++)
            {
                SQLProperty p = Properties[i];
                if (p.Name.Equals(name))
                    return p.Value;
            }

            return "";
        }

        //public SQLStruct[] Items { get; set; }

    }
}
