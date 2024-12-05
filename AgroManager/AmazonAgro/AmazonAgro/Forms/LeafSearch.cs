using DHS.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class LeafSearch : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private SQLAdapter sql;
        private Font font_1;
        private Font font_2;
        public LeafSearch(SQLAdapter sql)
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            this.sql = sql;

            font_1 = new Font("Segoe UI", 20, FontStyle.Regular);
            font_2 = new Font("Segoe UI", 12, FontStyle.Bold);

            DragAndDropSupport dnd = new DragAndDropSupport(periodicPnl, itemsPnl);
            dnd.Dropped += (o, args) =>
            {
                BlockElementView clone = ((BlockElementView)args.Control).Clone(true);
                clone.Style = BlockStyles.Input;

                clone.AddFields(new BlockField("%", "percent"), new BlockField("Tol.", "tolerance"));
                clone.SetFieldValueByName(5, "tolerance"); //Valor padrão
                clone.ValueChanged += delegate
                {
                    FindValues();
                };

                itemsPnl.Controls.Add(clone);
            };

            PeriodicTable.Generate(periodicPnl);

            //Adicionar elementos compostos
            DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "elemento_composto"), "");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i][2].ToString();

                BlockElementView block = new BlockElementView(false);
                block.Element = new BlockElement() { Title = name };
                block.Width = 110;

                composePnl.Controls.Add(block);
            }

            DragAndDropSupport dnd2 = new DragAndDropSupport(composePnl, itemsPnl);
            dnd2.Dropped += (o, args) =>
            {
                BlockElementView clone = ((BlockElementView)args.Control).Clone(true);
                clone.Style = BlockStyles.Input;
                clone.StripeColor = Color.White; //Branco para padronizar

                clone.AddFields(new BlockField("%", "percent"), new BlockField("Tol.", "tolerance"));
                clone.SetFieldValueByName(5, "tolerance"); //Valor padrão
                clone.ValueChanged += delegate
                {
                    FindValues();
                };

                itemsPnl.Controls.Add(clone);
            };

            //for (int i = 0; i < periodicPnl.Controls.Count; i++)
            //    if (periodicPnl.Controls[i] is BlockElementView)
            //    {
            //        BlockElementView view = (BlockElementView)periodicPnl.Controls[i];
            //        view.ValueChanged += delegate
            //        {
            //            FindValues();
            //        };
            //    }

            string[] columns = { "Produto", "Resultados" };

            for (int i = 0; i < columns.Length; i++)
                listLvw.Columns.Add(columns[i], 300);

            Util.OpenAndSaveProductsPath(folderPathTbx, this);
        }

        private void added(object sender, ControlEventArgs e)
        {
            itemsPnl.Refresh();
        }

        private void removed(object sender, ControlEventArgs e)
        {
            itemsPnl.Refresh();
        }

        public void FindValues()
        {
            listLvw.Items.Clear();

            if (string.IsNullOrWhiteSpace(folderPathTbx.Text))
            {
                MessageBox.Show("Nenhuma pasta de produtos selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(folderPathTbx.Text))
            {
                MessageBox.Show("A pasta selecionada é inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] products = Directory.GetFiles(folderPathTbx.Text);
            //Produto
            for (int i = 0; i < products.Length; i++)
            {
                string file_name = products[i];

                if (file_name.ToLower().EndsWith(".amf"))
                {
                    Product product = Product.Load(file_name);

                    //Por soluções usadas no prouto
                    for (int j = 0; j < product.Blocks.Length; j++)
                    {
                        BlockElement block = product.Blocks[j];

                        DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectWhereSyntax(), "nutrientes", "materia_prima", string.Format("{0} = '{1}'", sql.OnFormatField("nome"), block.Title)), "");

                        List<string> results = new List<string>();

                        for (int k = 0; k < table.Rows.Count; k++)
                        {
                            Element[] elements = JsonConvert.DeserializeObject<Element[]>(table.Rows[k][0].ToString());

                            //Elementos da solução
                            for (int l = 0; l < elements.Length; l++)
                            {
                                Element product_element = elements[l];

                                //Elementos selecionados da tabela periódica
                                for (int m = 0; m < itemsPnl.Controls.Count; m++)
                                {
                                    if (itemsPnl.Controls[m] is BlockElementView)
                                    {
                                        BlockElementView view = (BlockElementView)itemsPnl.Controls[m];

                                        //Se for o mesmo elemento
                                        if (view.Title.Equals(product_element.Name))
                                        {
                                            float percent;
                                            if (float.TryParse(view.Element.GetFieldValueByName("percent"), out percent))
                                            {
                                                float tolerance;
                                                if (float.TryParse(view.Element.GetFieldValueByName("tolerance"), out tolerance))
                                                {
                                                    //Tolerância
                                                    float diference = Math.Abs(percent - product_element.Percent);

                                                    float range = product_element.Percent * (tolerance / 100); //Diminuir escala

                                                    if (product_element.Percent == percent)
                                                        results.Add(string.Format("{0}: OK, {1:N3}[Exato]", product_element.Name, product_element.Percent));
                                                    else if (percent > product_element.Percent - range && percent < product_element.Percent + range)
                                                        results.Add(string.Format("{0}: OK, {1:N3}[Tolerância aceitável]", product_element.Name, product_element.Percent));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Mostrar resultados
                        if (results.Count > 0)
                            AddItem(product.Name, string.Join(", ", results.ToArray()));
                    }
                }
            }

            if (listLvw.Items.Count == 0)
                listLvw.Items.Add(new ListViewItem("Nenhum produto encontrado."));
        }

        private void AddItem(string name, string tolerance)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(tolerance);

            listLvw.Items.Add(item);
        }

        private void toleranceNud_ValueChanged(object sender, EventArgs e)
        {
            FindValues();
        }

        private void findFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_browser = new FolderBrowserDialog();
            folder_browser.Description = "Seleciona a pasta onde estão os arquivos de produto.";
            if (folder_browser.ShowDialog() == DialogResult.OK)
                folderPathTbx.Text = folder_browser.SelectedPath;
        }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(this.Text, font_1, ClientRectangle, new PointF(.5f, 15), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

        private void resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void items_paint(object sender, PaintEventArgs e)
        {
            if (itemsPnl.Controls.Count == 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                GraphicsPath path = new GraphicsPath();
                DrawUtil.DrawText("   Arraste e solte\nos elementos aqui", font_2, itemsPnl.ClientRectangle, new PointF(.5f, .5f), new PointF(.5f, .5f), e.Graphics, path);
                e.Graphics.FillPath(Brushes.Silver, path);
            }
        }

    }
}
