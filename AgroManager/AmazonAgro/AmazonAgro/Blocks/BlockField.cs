using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    [Serializable]
    public class BlockField
    {

        public BlockField(string title, string name)
        {
            Title = title;
            Name = name;
        }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
