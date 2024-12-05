using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    [Serializable]
    public class BlockElement
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public BlockStyles Style { get; set; }

        public BlockField[] Fields { get; set; }

        public Color StripeColor { get; set; }

        public Point Location { get; set; }

        public string GetFieldValueByName(string name)
        {
            for (int i = 0; i < Fields.Length; i++)
                if (Fields[i].Name.Equals(name)) return Fields[i].Value;

            return "";
        }

    }
}
