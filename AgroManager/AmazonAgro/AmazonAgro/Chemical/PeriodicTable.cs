using DHS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class PeriodicTable
    {

        public static void Generate(Control control, params BlockField[] fields)
        {
            bool generate_fields = fields.Length > 0;

            int h = generate_fields ? (fields.Length * 23) + 60 : 60;
            int w = generate_fields ? 150 : 60;

            int margin = 5;
            int x = margin;
            int y = -h;
            for (int i = 0; i < Elements.Length; i++)
            {
                if (i % 18 == 0)
                {
                    x = margin;
                    y += h + margin;
                }
                else
                    x += w + margin;

                Element item = Elements[i];
                if (!string.IsNullOrWhiteSpace(item.Name))
                {
                    Color color = GetElementGroupColor(item.Tag);

                    BlockElementView block = new BlockElementView(false);

                    block.Style = generate_fields ? BlockStyles.Input : BlockStyles.Small;

                    if (generate_fields)
                        block.AddFields(fields);

                    block.Location = new Point(x, y);
                    block.Title = item.Name;
                    block.StripeColor = color;

                    control.Controls.Add(block);
                }
            }
        }

        public static Element[] GetAllElements(SQLAdapter sql)
        {
            List<Element> result = new List<Element>();

            for (int i = 0; i < Elements.Length; i++)
                result.Add(Elements[i]);

            //Adicionar elementos compostos
            DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "elemento_composto"), "");

            for (int i = 0; i < table.Rows.Count; i++)
                result.Add(new Element(table.Rows[i][2].ToString(), -1));

            return result.ToArray();
        }

        public static Color GetElementGroupColor(int tag)
        {
            switch (tag)
            {
                case 0:
                    return Color.Green;
                case 1:
                    return Color.Cyan;
                case 2:
                    return Color.Red;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Brown;
                case 5:
                    return Color.Orange;
                case 6:
                    return Color.Purple;
                case 7:
                    return Color.Blue;
                case 8:
                    return Color.Silver;
                case 9:
                    return Color.Magenta;
                case 10:
                    return Color.DarkMagenta;
            }

            return Color.White;
        }

        public static Element[] Elements = {
                                 new Element("H", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("He", 1),
                                 new Element("Li", 2),
                                 new Element("Be", 3),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("B", 4),
                                 new Element("C", 0),
                                 new Element("N", 0),
                                 new Element("O", 0),
                                 new Element("F", 5),
                                 new Element("Ne", 1),
                                 new Element("Na", 2),
                                 new Element("Mg", 3),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("Al", 6),
                                 new Element("Si", 4),
                                 new Element("P", 0),
                                 new Element("S", 0),
                                 new Element("Cl", 5),
                                 new Element("Ar", 1),
                                 new Element("K", 2),
                                 new Element("Ca", 3),
                                 new Element("Sc", 7),
                                 new Element("Ti", 7),
                                 new Element("V", 7),
                                 new Element("Cr", 7),
                                 new Element("Mn", 7),
                                 new Element("Fe", 7),
                                 new Element("Co", 7),
                                 new Element("Ni", 7),
                                 new Element("Cu", 7),
                                 new Element("Zn", 7),
                                 new Element("Ga", 6),
                                 new Element("Ge", 4),
                                 new Element("As", 4),
                                 new Element("Se", 0),
                                 new Element("Br", 5),
                                 new Element("Kr", 1),
                                 new Element("Rb", 2),
                                 new Element("Sr", 3),
                                 new Element("Y", 7),
                                 new Element("Zr", 7),
                                 new Element("Nb", 7),
                                 new Element("Mo", 7),
                                 new Element("Tc", 7),
                                 new Element("Ru", 7),
                                 new Element("Rh", 7),
                                 new Element("Pd", 7),
                                 new Element("Ag", 7),
                                 new Element("Cd", 7),
                                 new Element("In", 6),
                                 new Element("Sn", 6),
                                 new Element("Sb", 4),
                                 new Element("Te", 4),
                                 new Element("I", 5),
                                 new Element("Xe", 1),
                                 new Element("Cs", 2),
                                 new Element("Ba", 3),
                                 new Element("", 0),
                                 new Element("Hf", 7),
                                 new Element("Ta", 7),
                                 new Element("W", 7),
                                 new Element("Re", 7),
                                 new Element("Os", 7),
                                 new Element("Ir", 7),
                                 new Element("Pt", 7),
                                 new Element("Au", 7),
                                 new Element("Hg", 7),
                                 new Element("Tl", 6),
                                 new Element("Pb", 6),
                                 new Element("Bi", 6),
                                 new Element("Po", 6),
                                 new Element("At", 5),
                                 new Element("Rn", 1),
                                 new Element("Fr", 2),
                                 new Element("Ra", 3),
                                 new Element("", 0),
                                 new Element("Rf", 7),
                                 new Element("Db", 7),
                                 new Element("Sg", 7),
                                 new Element("Bh", 7),
                                 new Element("Hs", 7),
                                 new Element("Mt", 8),
                                 new Element("Ds", 8),
                                 new Element("Rg", 8),
                                 new Element("Cn", 7),
                                 new Element("Nh", 8),
                                 new Element("Fl", 8),
                                 new Element("Ms", 8),
                                 new Element("Lv", 8),
                                 new Element("Ts", 8),
                                 new Element("Og", 8),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("La", 9),
                                 new Element("Ce", 9),
                                 new Element("Pr", 9),
                                 new Element("Nd", 9),
                                 new Element("Pm", 9),
                                 new Element("Sm", 9),
                                 new Element("Eu", 9),
                                 new Element("Gd", 9),
                                 new Element("Tb", 9),
                                 new Element("Dy", 9),
                                 new Element("Ho", 9),
                                 new Element("Er", 9),
                                 new Element("Tm", 9),
                                 new Element("Yb", 9),
                                 new Element("Lu", 9),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("", 0),
                                 new Element("Ac", 10),
                                 new Element("Th", 10),
                                 new Element("Pa", 10),
                                 new Element("U", 10),
                                 new Element("Np", 10),
                                 new Element("Pu", 10),
                                 new Element("Am", 10),
                                 new Element("Cm", 10),
                                 new Element("Bk", 10),
                                 new Element("Cf", 10),
                                 new Element("Es", 10),
                                 new Element("Fm", 10),
                                 new Element("Md", 10),
                                 new Element("No", 10),
                                 new Element("Lr", 10)
            };

    }
}
