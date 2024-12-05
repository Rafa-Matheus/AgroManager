using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    public class Element
    {

        public Element(string name, int tag)
        {
            Name = name;
            Tag = tag;
        }

        public string Name { get; set; }

        public float Percent { get; set; }

        public int Tag { get; set; }

    }
}
