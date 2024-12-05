using DHS.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class Search : Form
    {

        public Search()
        {
            InitializeComponent();
        }

        public string TableFilter { get; set; }

        private BackgroundWorker bk;
        private Font font;
        public Search(SQLAdapter sql)
        {
            InitializeComponent();

            font = new Font("Segoe UI", 20, FontStyle.Bold);

            inputTbx.TextChanged += delegate
            {
                if (!string.IsNullOrWhiteSpace(inputTbx.Text))
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
                        DataSet table_names = sql.GetDataSet(sql.GetTableNamesSyntax());

                        if (table_names.Tables.Count == 0) return;

                        items.Add(new string[] { "Resultado", "Tabela", "ID"  });

                        for (int i = 0; i < table_names.Tables[0].Rows.Count; i++)
                        {
                            string table_name = table_names.Tables[0].Rows[i][0].ToString();

                            if (TableFilter != null)
                                if (!table_name.Equals(TableFilter)) continue;

                            DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), table_name), "");

                            for (int j = 0; j < table.Rows.Count; j++)
                                for (int k = 0; k < table.Columns.Count; k++)
                                    if (table.Rows[j][k].ToString().ToLower().Contains(inputTbx.Text.ToLower()))
                                    {
                                        string wn = table_name;
                                        //string wn = Char.ToUpper(tn[0]) + tn.Substring(1);


                                        items.Add(new string[] { "\"" + table.Rows[j][k].ToString() + "\" na coluna \"" + table.Columns[k].ToString() + "\"", wn, table.Rows[j][0].ToString(), table.Rows[j][k].ToString() });
                                    }
                        }

                        founded = items.Count != 0;
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

                            for (int j = 1; j < items[i].Length - 1; j++)
                                item.SubItems.Add(items[i][j]);

                            //Valor encontrado
                            item.Tag = items[i][3];

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
                    SelectedValue = (string)list.SelectedItems[0].Tag;
            };
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public string SelectedValue { get; set; }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText("Pesquisar", font, panel2.ClientRectangle, new PointF(.5f, .5f), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

    }
}
