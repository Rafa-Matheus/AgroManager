using DHS.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DHS.SQL
{
    public class SQLXmlHelper
    {

        public static SQLStruct ReadFields(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root_node = doc.SelectSingleNode("/fields");
            SQLStruct root = new SQLStruct(root_node.Attributes["name"].Value, root_node.Attributes["title"].Value, "");

            if (root_node.Attributes["visible"] != null)
                root.IsVisible = bool.Parse(root_node.Attributes["visible"].Value);

            if (root_node.Attributes["primary"] != null)
                root.IsPrimary = bool.Parse(root_node.Attributes["primary"].Value);

            ////Tabela que agrupa (NÃO PODE EXISTIR)
            //if (root_node.Attributes["parent_table"] != null)
            //    root.ParentTable = root_node.Attributes["parent_table"].Value;

            //Tabela filha
            if (root_node.Attributes["child_table"] != null)
                root.ChildTable = root_node.Attributes["child_table"].Value;

            //Loop
            XmlNodeList list = doc.SelectNodes("/fields/*");
            Cascade(list, root);

            return root;
        }

        private static void Cascade(XmlNodeList list, SQLStruct root)
        {
            for (int i = 0; i < list.Count; i++)
            {
                XmlNode node = list[i];

                int spc_att_count = 1;

                string name = "";
                if (node.Attributes["name"] != null)
                {
                    name = node.Attributes["name"].Value;
                    spc_att_count++;
                }

                SQLStruct f = new SQLStruct(name, node.Attributes["title"].Value, node.Name);

                int count = node.Attributes.Count;

                f.Properties = new SQLProperty[count - spc_att_count]; //Menos nome e título
                int k = 0;
                for (int j = 0; j < count; j++)
                    if (!node.Attributes[j].Name.Equals("name") && !node.Attributes[j].Name.Equals("title")) //Não é o nome nem o título
                    {
                        XmlAttribute att = node.Attributes[j];
                        f.Properties[k] = new SQLProperty(att.Name, att.Value);
                        k++;
                    }

                //Possui afiliações
                if (node.HasChildNodes)
                    Cascade(node.ChildNodes, f);

                root.Fields.Add(f);
            }
        }

        public static XmlAttribute CreateAttribute(XmlDocument doc, string name, string value)
        {
            XmlAttribute att = doc.CreateAttribute(name);
            att.Value = value;
            return att;
        }

    }
}
