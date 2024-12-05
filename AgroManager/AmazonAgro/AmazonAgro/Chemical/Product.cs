using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    [Serializable]
    public class Product
    {

        public Product(string name)
        {
            Name = name;
            Blocks = new BlockElement[0];
        }

        public string Name { get; set; }

        public string Client { get; set; }

        public float Density { get; set; }

        public float Liters { get; set; }

        public BlockElement[] Blocks { get; set; }

        public void Save(Control control, string path)
        {
            List<BlockElement> elements = new List<BlockElement>();
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control c = control.Controls[i];
                if (c is BlockElementView)
                    elements.Add(((BlockElementView)c).Element);
            }

            Blocks = elements.ToArray();

            Binary.WriteToBinary(this, path);
        }

        public static Product Load(string path)
        {
            return Binary.ReadFromBinary<Product>(path);
        }

    }
}
