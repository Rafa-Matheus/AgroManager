using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.SQL
{
    public class SQLControlsHelper
    {

        public static void AddControls(Control control, SQLStruct structure, SQLAdapter sql)
        {
            control.Text = structure.Title;

            for (int i = 0; i < structure.Fields.Count; i++)
            {
                SQLStruct field = structure.Fields[i];

                //Não é visível
                if (field.ContainsProperty("visible"))
                    if (!bool.Parse(field.GetPropertyValue("visible")))
                        continue;

                SQLFieldBase base_ = new SQLFieldBase();
                base_.SQLName = field.Name;
                if (!string.IsNullOrWhiteSpace(field.Title))
                    base_.Title = string.Format("{0}:", field.Title);
                else
                    base_.Title = "";

                base_.Panel.Controls.Add(GetFieldControl("%system%", field, sql));

                base_.Dock = DockStyle.Top;

                control.Controls.Add(base_);

                base_.BringToFront();
            }

            //Botão principal para inserir
            Button okBtn = new Button();
            okBtn.Text = "OK";
            okBtn.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            okBtn.Location = new Point(control.Width - okBtn.Width - 10, control.Height - okBtn.Height - 10);

            okBtn.Click += delegate
            {
                List<string> fields = new List<string>();
                List<string> values = new List<string>();
                for (int i = control.Controls.Count - 1; i >= 0; i--)
                {
                    Control c = control.Controls[i];

                    if (c is SQLFieldBase)
                    {
                        SQLFieldBase base_ = c as SQLFieldBase;

                        fields.Add(base_.SQLName);
                        values.Add(GetFieldValue(base_));
                    }
                }

                sql.InsertInTable("", structure.Name, string.Join(", ", fields.ToArray()), string.Join(", ", values.ToArray()));

                MessageBox.Show("Itens inseridos com sucesso!");
            };

            control.Controls.Add(okBtn);

            okBtn.BringToFront();
        }

        private static Control GetFieldControl(string user, SQLStruct structure, SQLAdapter sql)
        {
            bool is_separator = structure.Type.Equals("sep");

            List<SQLEnumItem> enum_items = new List<SQLEnumItem>();

            //Separador
            if (!is_separator)
            {
                //Proprieades
                if (structure.Properties.Length > 0)
                    for (int j = 0; j < structure.Properties.Length; j++)
                    {
                        SQLProperty p = structure.Properties[j];

                        switch (p.Name)
                        {
                            case "get_from":
                                string get_from = structure.GetPropertyValue("get_from");

                                //Valores de uma tabela
                                if (get_from.Contains(":"))
                                {
                                    DataTable data = GetTableValues(user, get_from, sql);

                                    for (int k = 0; k < data.Rows.Count; k++)
                                    {
                                        string id = data.Rows[k][0].ToString();
                                        string data_item = data.Rows[k][1].ToString();

                                        enum_items.Add(new SQLEnumItem(data_item, id));
                                    }
                                }
                                else
                                    switch (get_from)
                                    {
                                        //Nomes de todas as tabelas
                                        case "%table_names%":
                                            //for (int k = 0; k < TableManager.Tables.Count; k++)
                                            //{
                                            //    string table_name = TableManager.Tables[k].Name;
                                            //    string table_title = TableManager.Tables[k].Title;

                                            //    enum_items.Add(new SQLEnumItem(table_title, table_name));
                                            //}
                                            break;
                                        //Dias da semana
                                        case "%days%":
                                            string[] days = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
                                            for (int k = 0; k < 7; k++)
                                                enum_items.Add(new SQLEnumItem(days[k], k.ToString()));
                                            break;
                                    }
                                break;
                        }
                    }

                //Outros sub-campos
                if (structure.Fields != null)
                    for (int i = 0; i < structure.Fields.Count; i++)
                    {
                        SQLStruct item = structure.Fields[i];
                        if (item.Type.Equals("item"))
                            enum_items.Add(new SQLEnumItem(item.Title, item.GetPropertyValue("value")));
                    }
            }

            switch (structure.Type)
            {
                //Separador
                //case "sep":
                //    return new Panel() { BackColor = Color.Red };
                case "text":
                    return new TextBox() { Dock = DockStyle.Fill };
                case "ptext":
                    return new TextBox() { Dock = DockStyle.Fill, PasswordChar = '*' };
                case "mtext":
                    return new TextBox() { Dock = DockStyle.Fill, Multiline = true };
                case "enum":
                    ComboBox cbx = new ComboBox();
                    cbx.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbx.Dock = DockStyle.Fill;

                    cbx.Items.AddRange(enum_items.ToArray());

                    return cbx;
                case "chitem":
                    return new CheckBox() { Dock = DockStyle.Fill };
                case "mask":
                    MaskedTextBox mask = new MaskedTextBox();
                    mask.Dock = DockStyle.Fill;
                    if(structure.ContainsProperty("mask"))
                        mask.Mask = structure.GetPropertyValue("mask");

                    return mask;
                case "chitems":
                    CheckedListBox chitem = new CheckedListBox();
                    chitem.Dock = DockStyle.Fill;

                    chitem.Items.AddRange(enum_items.ToArray());
                    return chitem;
            }

            //Nenhum tipo encontrado
            return new Panel();
        }

        #region Adquirir valores da tabela
        private static DataTable GetTableValues(string user, string get_from, SQLAdapter sql)
        {
            //Valores de uma tabela
            string[] args = get_from.Split(':');

            string arg_table = args[0];
            string arg_column = args[1];

            return sql.SelectField(user, string.Format("{0}, {1}",sql.OnFormatField("id"), arg_column), arg_table);
        }
        #endregion

        private static string GetFieldValue(SQLFieldBase base_)
        {
            Control control = base_.Panel.Controls[0];

            if (control is TextBox)
                return string.Format("'{0}'", (control as TextBox).Text);
            else if (control is ComboBox)
                return string.Format("'{0}'", ((control as ComboBox).SelectedItem as SQLEnumItem).Value);

            return "";
        }



    }
}
