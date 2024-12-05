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
    public partial class LeafAnalysis : Form
    {

        private SQLAdapter sql;
        private Font font;
        public LeafAnalysis(SQLAdapter sql)
        {
            InitializeComponent();

            font = new Font("Segoe UI", 20, FontStyle.Regular);

            //Carregar colunas
            ///
            DataTable table1 = new DataTable();
            table1.Columns.Add(new DataColumn("Fertilizante", typeof(string)));
            table1.Columns.Add(new DataColumn("Litros", typeof(string)));
            table1.Columns.Add(new DataColumn("Recomendação L/Ha", typeof(string)));
            table1.Columns.Add(new DataColumn("Aplicações", typeof(string)));
            table1.Columns.Add(new DataColumn("Custo ($)", typeof(string)));

            data1.DataSource = table1;

            string[] columns1 = { "Fertilizante", "Litros", "Recomendação L/Ha", "Litros TOTAL", "Litros por Aplicação", "Custo ($)" };

            for (int i = 0; i < columns1.Length; i++)
                list1Lvw.Columns.Add(columns1[i], 120);
            ///
            DataTable table2 = new DataTable();

            string[] columns2 = { 
                                    "Produção Esperada",
                                    "N Folhas (g/Kg) 23-27",
                                    "28-30",
                                    "P Resina (mg/dm3) 6,0-12,0",
                                    "13,0-30,0",
                                    "K Trocável (mmol/dm3) 0,8-1,5",
                                    "1,6-3,0",
                                    ">3,0" };

            for (int i = 0; i < columns2.Length; i++)
            {
                table2.Columns.Add(new DataColumn(columns2[i], typeof(string)));
                list2Lvw.Columns.Add(columns2[i], 120);
            }

            data2.DataSource = table2;
            ///

            //Eventos para atualizar dados
            int last_count = 0;
            data1.CellEndEdit += (o, args) =>
            {
                if (data1.Rows.Count > last_count)
                {
                    AddContent(args.RowIndex);

                    last_count = data1.Rows.Count;
                }

                if (args.ColumnIndex == 0)
                {
                    if (args.RowIndex < contentPnl.Controls.Count)
                    {
                        string title = "";

                        try
                        {
                            title = (string)data1.Rows[args.RowIndex].Cells[0].Value;
                        }
                        catch { }

                        ((BlockElementView)contentPnl.Controls[args.RowIndex]).Title = title;
                    }
                }
            };
            data1.UserDeletingRow += (o, args) =>
            {
                //Remover fertilizante
                contentPnl.Controls[args.Row.Index].Dispose();

                RefreshValues();
            };
            data1.UserDeletedRow += delegate
            {
                last_count = data1.Rows.Count;
            };
            data1.CellValueChanged += delegate
            {
                RefreshValues();
            };
            data2.CellValueChanged += delegate
            {
                RefreshValues();
            };
            data2.UserDeletedRow += (o, args) =>
            {
                RefreshValues();
            };

            //Barra de botões
            topToolsBar.AddPage("Arquivo");
            topToolsBar.AddButton("Abrir Cultura", Properties.Resources.leaf, 0, TopToolsBarButtonSides.Left, delegate
            {
                OpenFileDialog op = new OpenFileDialog();
                op.DefaultExt = "amcf";
                op.Filter = "Cultura Amazon Fertilizantes (*.amcf)|*.amcf";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    Culture culture = Culture.Load(op.FileName);
                    nameTbx.Text = culture.Name;
                    periodCbx.SelectedIndex = culture.Period;
                    factorTbx.Text = culture.ConversionFactor.ToString();

                    //Tabelas
                    data1.DataSource = culture.Table1;
                    data2.DataSource = culture.Table2;

                    last_count = data1.Rows.Count;

                    //Garantias
                    for (int i = 0; i < culture.Contents.Length; i++)
                    {
                        BlockElementView view = new BlockElementView(false);
                        view.ValueChanged += delegate
                        {
                            RefreshValues();
                        };

                        view.Element = culture.Contents[i];

                        contentPnl.Controls.Add(view);
                    }

                    RefreshValues();
                }
            });
            topToolsBar.AddButton("Salvar Cultura", Properties.Resources.save, 0, TopToolsBarButtonSides.Left, delegate
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.FileName = nameTbx.Text;
                sv.DefaultExt = "amcf";
                sv.Filter = "Cultura Amazon Fertilizantes (*.amcf)|*.amcf";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    Culture culture = new Culture(nameTbx.Text);
                    culture.Period = periodCbx.SelectedIndex;

                    culture.Table1 = (DataTable)data1.DataSource;
                    culture.Table2 = (DataTable)data2.DataSource;

                    try
                    {
                        culture.ConversionFactor = float.Parse(factorTbx.Text);
                    }
                    catch { }

                    culture.Contents = new BlockElement[contentPnl.Controls.Count];
                    for (int i = 0; i < contentPnl.Controls.Count; i++)
                        if (contentPnl.Controls[i] is BlockElementView)
                            culture.Contents[i] = ((BlockElementView)contentPnl.Controls[i]).Element;

                    culture.Save(sv.FileName);
                }
            });
            topToolsBar.AddButton("Imprimir", Properties.Resources.print, 0, TopToolsBarButtonSides.Left, delegate
            {
                ReportPage report = new ReportPage();
                report.Title = string.Format("{0}\n{1}", nameTbx.Text, DateTime.Now.ToShortDateString());

                report.Tables.Add(ReportItem.GenerateFromListView(list1Lvw, ""));

                //Outras informações
                ReportItem teores = new ReportItem("Teores Fornecidos:");

                //Nomes das mátérias primas
                ReportItem element = new ReportItem("Nutriente");
                ReportItem content = new ReportItem("Teor");

                for (int i = 0; i < contentTotalPnl.Controls.Count; i++)
                {
                    if (contentTotalPnl.Controls[i] is BlockElementView)
                    {
                        BlockElementView view = (BlockElementView)contentTotalPnl.Controls[i];

                        element.SubItems.Add(new ReportItem(view.Title));
                        content.SubItems.Add(new ReportItem(view.Description));
                    }
                }

                teores.SubItems.Add(element);
                teores.SubItems.Add(content);

                report.Tables.Add(teores);

                //Período
                ReportItem lab_values = new ReportItem("");

                ReportItem times_value = new ReportItem("Período das Aplicações");
                times_value.SubItems.Add(new ReportItem(periodCbx.Text));
                lab_values.SubItems.Add(times_value);

                report.Tables.Add(lab_values);

                report.Print();
            });
        }

        public void AddContent(int row_index)
        {
            try
            {
                BlockElementView view = new BlockElementView(false);
                view.ValueChanged += delegate
                {
                    RefreshValues();
                };

                BlockElement element = new BlockElement();
                element.Title = (string)data1.Rows[row_index].Cells[0].Value;
                element.Fields = new[] {
                        new BlockField("N", "n"),
                        new BlockField("P2O5", "p2o5"),
                        new BlockField("K2O", "k2o"),
                        new BlockField("Ca", "ca"),
                        new BlockField("Mg", "mg"),
                        new BlockField("Carb. Org.", "co")
                    };
                element.StripeColor = Color.White; //Branco para padronizar
                element.Style = BlockStyles.Input;

                view.Element = element;

                contentPnl.Controls.Add(view);
            }
            catch { }
        }

        public void RefreshValues()
        {
            list1Lvw.Items.Clear();
            list2Lvw.Items.Clear();

            #region Tabela 1
            //Não conta a última
            for (int i = 0; i < data1.Rows.Count - 1; i++)
            {
                //Nome
                ListViewItem item = new ListViewItem();

                try
                {
                    item.Text = (string)data1.Rows[i].Cells[0].Value;
                }
                catch { }

                //Litros
                float liters = 0;
                //Há fertirrigar
                float total = 0;
                //Aplicações
                float times = 0;
                //Custo
                float cost = 0;

                try
                {
                    liters = float.Parse((string)data1.Rows[i].Cells[1].Value);
                    total = float.Parse((string)data1.Rows[i].Cells[2].Value);
                    times = float.Parse((string)data1.Rows[i].Cells[3].Value);
                    cost = float.Parse((string)data1.Rows[i].Cells[4].Value);
                }
                catch { }

                item.SubItems.Add(liters.ToString());
                item.SubItems.Add(total.ToString());

                //Litros * Há fertirrigar
                item.SubItems.Add(Util.ReplaceNaN(liters * total).ToString());

                //(Litros * Há fertirrigar) / Aplicações
                item.SubItems.Add(Util.ReplaceNaN((liters * total) / times).ToString());

                //Custo
                item.SubItems.Add(Util.ReplaceNaN(liters * cost).ToString());

                list1Lvw.Items.Add(item);
            }
            #endregion

            #region Tabela 2
            //Não conta a última
            for (int i = 0; i < data2.Rows.Count - 1; i++)
            {
                //Nome
                ListViewItem item = new ListViewItem();

                try
                {
                    item.Text = (string)data2.Rows[i].Cells[0].Value;
                }
                catch { }

                float factor = 1;
                try
                {
                    factor = float.Parse(factorTbx.Text);
                }
                catch { }

                //Colunas
                for (int j = 1; j <= 7; j++)
                {
                    float column = 0;

                    try
                    {
                        column = float.Parse((string)data2.Rows[i].Cells[j].Value);
                    }
                    catch { }

                    item.SubItems.Add(Util.ReplaceNaN(column * factor).ToString());
                }

                list2Lvw.Items.Add(item);
            }
            #endregion

            #region Garantias
            //Já adicionar todas as garantias
            if (contentPnl.Controls.Count > 0)
            {
                if (contentPnl.Controls[0] is BlockElementView)
                {
                    BlockElementView view = (BlockElementView)contentPnl.Controls[0];

                    contentTotalPnl.Controls.Clear();
                    for (int j = 0; j < view.Element.Fields.Length; j++)
                    {
                        BlockField field = view.Element.Fields[j];

                        BlockElement total_element = new BlockElement();
                        total_element.Title = field.Title;
                        total_element.Description = "0";
                        total_element.StripeColor = Color.White; //Branco para padronizar

                        contentTotalPnl.Controls.Add(new BlockElementView(false) { Element = total_element, Width = 110 });
                    }
                }
            }

            for (int i = 0; i < contentTotalPnl.Controls.Count; i++)
            {
                if (contentTotalPnl.Controls[i] is BlockElementView)
                {
                    BlockElementView total_view = (BlockElementView)contentTotalPnl.Controls[i];

                    float total = 0;
                    for (int j = 0; j < contentPnl.Controls.Count; j++)
                    {
                        if (contentPnl.Controls[j] is BlockElementView)
                        {
                            BlockElementView view = (BlockElementView)contentPnl.Controls[j];

                            float value = 0;

                            BlockField field = view.Element.Fields[i];

                            try
                            {
                                value = float.Parse(field.Value);
                            }
                            catch { }

                            float liters = 0;

                            try
                            {
                                liters = float.Parse((string)data1.Rows[j].Cells[1].Value);
                            }
                            catch { }

                            //(Valor * Litros) / 1000
                            total += Util.ReplaceNaN((value * liters) / 1000);
                        }
                    }

                    total_view.Description = total.ToString();
                }
            }
            #endregion
        }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(this.Text, font, ClientRectangle, new PointF(.5f, 150), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

        private void resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void factor_changed(object sender, EventArgs e)
        {
            RefreshValues();
        }

    }
}
