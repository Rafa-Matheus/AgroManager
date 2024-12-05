using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemDeProducaoAmazon
{
    public partial class Pesquisar : Form
    {

        public Pesquisar()
        {
            InitializeComponent();
        }

        public string TableFilter
        {
            get;
            set;
        }

        private BackgroundWorker bk;
        public Pesquisar(SQLAdapter sql)
        {
            InitializeComponent();

            textBox1.TextChanged += delegate
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    //BackgroundWorker
                    if (bk != null)
                    {
                        bk.CancelAsync();
                        bk.Dispose();
                        bk = null;
                    }

                    Text = "Pesquisando...";
                    bk = new BackgroundWorker();
                    bk.WorkerSupportsCancellation = true;

                    List<string[]> items = new List<string[]>();

                    bool founded = false;
                    bk.DoWork += delegate
                    {
                        //Type formType = typeof(Form);
                        //foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                        //    if (formType.IsAssignableFrom(formType))
                        //    {
                        //        Form f = new Form();

                        //        f.Tag = formType.GetProperty("Tag").GetValue(f);

                        //        MessageBox.Show((string)f.Tag);
                        //    }
                        //if (is_single_table)
                        //{
                        //    items.Add(new string[] { "ID", "Primeira Coluna", "Valor Encontrado" });

                        //    DataSet ds = MySQL.GetDataSet("SELECT * FROM " + table_name);

                        //    foreach (DataTable table in ds.Tables)
                        //    {
                        //        if (table.Columns.Count < 2) continue;

                        //        for (int i = 0; i < table.Rows.Count; i++)
                        //            for (int j = 0; j < table.Columns.Count; j++)
                        //                if (table.Rows[i][j].ToString().ToLower().Contains(t.Text.ToLower()))
                        //                    items.Add(new string[] { table.Rows[i][0].ToString(), table.Rows[i][1].ToString(), "\"" + table.Rows[i][j].ToString() + "\" na coluna \"" + table.Columns[j].ToString() + "\"" });
                        //    }

                        //    founded = items.Count != 0;
                        //}
                        //else
                        //{
                        DataSet table_names = sql.GetDataSet("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%';");

                        if (table_names.Tables.Count == 0) return;

                        items.Add(new string[] { "Tabela", "ID", "Coluna", "Valor Encontrado" });

                        for(int i = 0; i < table_names.Tables[0].Rows.Count; i++)
                        {
                            string tn = table_names.Tables[0].Rows[i][0].ToString();

                            if (TableFilter != null)
                                if (!tn.Equals(TableFilter)) continue;

                            DataTable table = sql.GetDataTable("", "SELECT * FROM " + tn, "");

                            //foreach (DataTable table in table.Tables)
                            //{
                            //if (table.Columns.Count < 1) continue;

                            for (int j = 0; j < table.Rows.Count; j++)
                                for (int k = 0; k < table.Columns.Count; k++)
                                    if (table.Rows[j][k].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        string wn = tn;
                                        //string wn = Char.ToUpper(tn[0]) + tn.Substring(1);
                                        
                                        items.Add(new string[] { wn, table.Rows[j][0].ToString(), table.Rows[j][1].ToString(), "\"" + table.Rows[j][k].ToString() + "\" na coluna \"" + table.Columns[k].ToString() + "\"" });
                                    }
                            //}
                        }

                        founded = items.Count != 0;
                        //}
                    };
                    bk.RunWorkerCompleted += delegate
                    {
                        Text = "";

                        list.Columns.Clear();
                        list.Items.Clear();

                        list.Enabled = founded;

                        if (!founded) return;

                        foreach (string cn in items[0])
                        {
                            ColumnHeader ch = new ColumnHeader();
                            ch.Width = 200;
                            ch.Text = cn;

                            list.Columns.Add(ch);
                        }

                        for (int i = 1; i < items.Count; i++)
                        {
                            ListViewItem item = new ListViewItem(items[i][0]);

                            for (int j = 1; j < items[i].Length; j++)
                                item.SubItems.Add(items[i][j]);

                            list.Items.Add(item);
                        }
                    };
                    bk.RunWorkerAsync();
                }
                else
                {
                    list.Columns.Clear();
                    list.Items.Clear();

                    Text = "";
                }
            };
            list.Click += delegate
            {
                if (list.SelectedItems.Count > 0)
                    SelectedValue = list.SelectedItems[0].SubItems[2].Text;
            };
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public string SelectedValue { get; set; }

    }
}
