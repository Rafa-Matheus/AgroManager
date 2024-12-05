using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.SQL
{
    public class SQLHelper
    {

        public static void ConvertToTable(string user, SQLStruct structure, SQLAdapter sql)
        {
            string name = structure.Name;

            List<string> fields = new List<string>();

            //Identificação
            fields.Add(sql.GetIdSyntax());

            //Item que agrupa
            fields.Add(string.Format("{0} INTEGER", sql.OnFormatField("parent_id")));

            for (int i = 0; i < structure.Fields.Count; i++)
            {
                SQLStruct f = structure.Fields[i];

                //Separador
                if (f.Type.Equals("sep")) continue;

                fields.Add(string.Format("{0} {1}", sql.OnFormatField(f.Name), "TEXT")); //Antigo GetFieldValueType(SQLStruct structure)
            }

            //Chave primária (Ela que faz com que cada id seja único)
            fields.Add(string.Format("PRIMARY KEY({0})", sql.OnFormatField("id")));

            sql.CreateTable(user, name, string.Join(", ", fields.ToArray()));
        }

        //private static string GetFieldValueType(SQLStruct structure)
        //{
        //    switch (structure.Type)
        //    {
        //        //case "text":
        //        //case "mtext":
        //        //case "decimal":
        //        //    return "TEXT";
        //        //case "chitem":
        //        //    return "INTEGER";
        //    }

        //    //Nenhum tipo encontrado
        //    return "TEXT";
        //}

        public static void AddListViewItems(ListView view, SQLStruct structure, SQLAdapter sql)
        {
            //Limpar tudo
            view.Clear();

            //Adicionar colunas
            for (int i = 0; i < structure.Fields.Count; i++)
            {
                SQLStruct field = structure.Fields[i];

                //Se não estiver visível
                if (!field.IsVisible) continue;

                int width = 0;
                switch (field.Type)
                {
                    case "sep":
                        continue; //Separador
                    case "text":
                    case "ptext":
                    case "mtext":
                    case "enum":
                    case "mask":
                    case "date":
                    case "decimal":
                        width = 300;
                        break;
                    case "chitem":
                        width = 100;
                        break;
                    case "chitems":
                        width = 500;
                        break;
                }

                view.Columns.Add(field.Title, width);
            }

            //Adicionar valores
            DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), structure.Name), "");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(FormatValueForListView(structure.Fields[0], table.Rows[i][2].ToString()));
                int offset = 0;
                for (int j = 3; j < table.Columns.Count; j++)
                {
                    //Se é um separador
                    if (structure.Fields[j - 2].Type.Equals("sep"))
                    {
                        offset++;
                        continue;
                    }

                    //Não é visível
                    if (structure.Fields[j - 2].ContainsProperty("visible"))
                        if(!bool.Parse(structure.Fields[j - 2].GetPropertyValue("visible")))
                        {
                            offset++;
                            continue;
                        }

                    item.SubItems.Add(FormatValueForListView(structure.Fields[j - 2], table.Rows[i][j - offset].ToString()));
                }

                item.Tag = table.Rows[i][0].ToString(); //Id

                view.Items.Add(item);
            }

            //Definir parâmetros
            view.GridLines = true;
            view.FullRowSelect = true;
            view.View = View.Details;
            view.Scrollable = true;
        }

        private static string FormatValueForListView(SQLStruct structure, string value)
        {
            switch (structure.Type)
            {
                //case "text":
                //case "ptext":
                //case "mtext":
                //case "enum":
                //    return value;
                case "date":
                    long date = 0;
                    try
                    {
                        date = long.Parse(value);
                    }
                    catch { }

                    return DateTime.FromBinary(date).ToShortDateString();
                case "decimal":
                    decimal d_value = 0;
                    try
                    {
                        d_value = decimal.Parse(value);
                    }
                    catch { }

                    return string.Format("{0:N2}", d_value);
                case "chitem":
                    bool result = false;
                    try
                    {
                        result = bool.Parse(value);
                    }
                    catch { }

                    return result ? "Sim" : "Não";
                case "chitems":
                    List<string> values = new List<string>();
                    string[] args = value.Split(';');
                    for (int i = 0; i < args.Length; i++)
                        if (args[i].Equals("1"))
                            values.Add(structure.Fields[i].Title);

                    return string.Join(", ", values.ToArray());
            }

            return value;
        }

    }
}
