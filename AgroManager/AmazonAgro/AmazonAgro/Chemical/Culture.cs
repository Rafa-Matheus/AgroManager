using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    [Serializable]
    public class Culture
    {

        public Culture(string name)
        {
            Name = name;
            Contents = new BlockElement[0];
        }

        public string Name { get; set; }

        public int Period { get; set; }

        public float ConversionFactor { get; set; }

        //Líquidos
        public DataTable Table1 { get; set; }

        //Granulados
        public DataTable Table2 { get; set; }

        //Garantias
        public BlockElement[] Contents { get; set; }

        public void Save(string path)
        {
            Binary.WriteToBinary(this, path);
        }

        public static Culture Load(string path)
        {
            return Binary.ReadFromBinary<Culture>(path);
        }

    }
}
