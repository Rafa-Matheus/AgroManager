using DHS.Printing;
using DHS.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class Goals : Form
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
        private Font font;
        private float product_kg;
        private bool block_values_changed;
        public Goals(SQLAdapter sql)
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            this.sql = sql;

            font = new Font("Segoe UI", 12, FontStyle.Bold);

            RefreshItems();

            DragAndDropSupport dnd = new DragAndDropSupport(materialsPnl, itemsPnl);
            dnd.Dropped += (o, args) =>
            {
                BlockElementView clone = ((BlockElementView)args.Control).Clone(true);
                clone.Style = BlockStyles.Input;

                clone.AddFields(new BlockField("%", "percent"), new BlockField("Kg", "kg"), new BlockField("Meta", "goal"));
                clone.ValueChanged += view_ValueChanged;

                Cursor = Cursors.Default;

                itemsPnl.Controls.Add(clone);
            };

            contentPnl.MouseEnter += delegate
            {
                RefreshContent();
            };

            message = "";

            //Barra de botões
            topToolsBar.AddPage("Arquivo");
            topToolsBar.AddButton("Abrir Produto", Properties.Resources.open, 0, TopToolsBarButtonSides.Left, delegate
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = Util.GetProductsPath();
                op.DefaultExt = "amf";
                op.Filter = "Produto Amazon Fertilizantes (*.amf)|*.amf";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    itemsPnl.Controls.Clear();

                    Product product = Product.Load(op.FileName);
                    productTbx.Text = product.Name;
                    clientTbx.Text = product.Client;
                    litersTbx.Text = product.Liters.ToString();
                    densityTbx.Text = product.Density.ToString();

                    BlockElementView.LoadBlocks(itemsPnl, product.Blocks);

                    //Defnir eventos
                    for (int i = 0; i < itemsPnl.Controls.Count; i++)
                        if (itemsPnl.Controls[i] is BlockElementView)
                        {
                            BlockElementView view = (BlockElementView)itemsPnl.Controls[i];
                            view.ValueChanged += view_ValueChanged;
                        }

                    //Atualizar valores
                    block_values_changed = true;

                    RefreshValues();

                    RefreshContent();
                }
            });
            topToolsBar.AddButton("Salvar Produto", Properties.Resources.save, 0, TopToolsBarButtonSides.Left, delegate
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.InitialDirectory = Util.GetProductsPath();
                sv.FileName = productTbx.Text;
                sv.DefaultExt = "amf";
                sv.Filter = "Produto Amazon Fertilizantes (*.amf)|*.amf";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    Product product = new Product(productTbx.Text);
                    product.Client = clientTbx.Text;

                    try
                    {
                        product.Liters = float.Parse(litersTbx.Text);
                        product.Density = float.Parse(densityTbx.Text);
                    }
                    catch { }

                    product.Save(itemsPnl, sv.FileName);
                }
            });
            topToolsBar.AddButton("Matérias Primas", Properties.Resources.elements, 0, TopToolsBarButtonSides.Left, delegate
            {
                new Materials(sql).ShowDialog();

                RefreshItems();
            });
            topToolsBar.AddButton("Imprimir", Properties.Resources.print, 0, TopToolsBarButtonSides.Left, delegate
            {
                ReportPage report = new ReportPage();
                report.Title = string.Format("{0}\nCliente: {1}\n{2}", productTbx.Text, clientTbx.Text, DateTime.Now.ToShortDateString());

                ReportItem materias_primas = new ReportItem("Matérias Primas:");

                //Nomes das mátérias primas
                ReportItem nome = new ReportItem("Nome");
                ReportItem percents = new ReportItem("%");
                ReportItem kgs = new ReportItem("Kg");
                ReportItem goals = new ReportItem("Meta");

                float total_percent = 0;
                float total_kg = 0;
                for (int i = 0; i < itemsPnl.Controls.Count; i++)
                {
                    if (itemsPnl.Controls[i] is BlockElementView)
                    {
                        BlockElementView view = (BlockElementView)itemsPnl.Controls[i];

                        nome.SubItems.Add(new ReportItem(view.Title));

                        float percent = 0;
                        if (float.TryParse(view.Element.GetFieldValueByName("percent"), out percent))
                            total_percent += percent;

                        percents.SubItems.Add(new ReportItem(percent.ToString()));

                        float kg = 0;
                        if (float.TryParse(view.Element.GetFieldValueByName("kg"), out kg))
                            total_kg += kg;

                        kgs.SubItems.Add(new ReportItem(view.Element.GetFieldValueByName("kg")));
                        goals.SubItems.Add(new ReportItem(view.Element.GetFieldValueByName("goal")));
                    }
                }

                materias_primas.SubItems.Add(nome);
                materias_primas.SubItems.Add(percents);
                materias_primas.SubItems.Add(kgs);
                materias_primas.SubItems.Add(goals);

                //Totais
                ReportItem totals = new ReportItem("");
                totals.SubItems.Add(new ReportItem("TOTAL"));
                totals.SubItems.Add(new ReportItem(total_percent.ToString()));
                totals.SubItems.Add(new ReportItem(total_kg.ToString()));
                totals.SubItems.Add(new ReportItem(""));

                report.Tables.Add(materias_primas);

                report.Tables.Add(totals);

                //Outras informações
                ReportItem teores = new ReportItem("Outros Valores:");

                //Nomes das mátérias primas
                ReportItem element = new ReportItem("Nutriente");
                ReportItem content = new ReportItem("Teor");

                for (int i = 0; i < contentPnl.Controls.Count; i++)
                {
                    if (contentPnl.Controls[i] is BlockElementView)
                    {
                        BlockElementView view = (BlockElementView)contentPnl.Controls[i];

                        element.SubItems.Add(new ReportItem(view.Title));
                        content.SubItems.Add(new ReportItem(view.Description));
                    }
                }

                teores.SubItems.Add(element);
                teores.SubItems.Add(content);

                report.Tables.Add(teores);

                //Densidade, Kilos e Litros
                ReportItem lab_values = new ReportItem("");

                float density = 1;
                if (float.TryParse(densityTbx.Text, out density))
                {
                    ReportItem density_value = new ReportItem("Densidade");
                    density_value.SubItems.Add(new ReportItem(density.ToString()));
                    lab_values.SubItems.Add(density_value);
                }

                ReportItem kg_value = new ReportItem("Kilos");
                kg_value.SubItems.Add(new ReportItem(product_kg.ToString()));
                lab_values.SubItems.Add(kg_value);

                float liter_count;
                if (float.TryParse(litersTbx.Text, out liter_count))
                {
                    ReportItem liter_value = new ReportItem("Litros");
                    liter_value.SubItems.Add(new ReportItem(liter_count.ToString()));
                    lab_values.SubItems.Add(liter_value);
                }

                report.Tables.Add(lab_values);

                report.Print();
            });

            topToolsBar.AddButton("Limpar Valores", Properties.Resources.clean, 0, TopToolsBarButtonSides.Right, delegate
            {
                if (itemsPnl.Controls.Count > 0)
                    if (MessageBox.Show("Deseja mesmo limpar os valores?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < itemsPnl.Controls.Count; i++)
                            if (itemsPnl.Controls[i] is BlockElementView)
                            {
                                BlockElementView view = (BlockElementView)itemsPnl.Controls[i];

                                view.SetFieldValueByName(0, "percent");
                            }

                        //Atualizar valores
                        block_values_changed = true;

                        RefreshValues();

                        RefreshContent();
                    }
            });
            topToolsBar.AddButton("Apagar Tudo", Properties.Resources.remove_all, 0, TopToolsBarButtonSides.Right, delegate
            {
                if (itemsPnl.Controls.Count > 0)
                    if (MessageBox.Show("Deseja mesmo apagar todos os itens?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        itemsPnl.Controls.Clear();

                        contentPnl.Controls.Clear();
                        contentPnl.Refresh();
                    }
            });

            //Já definir valores
            RefreshCounts();
        }

        void view_ValueChanged()
        {
            RefreshValues();

            block_values_changed = true;
        }

        public void RefreshItems()
        {
            materialsPnl.Controls.Clear();

            //Adicionar itens
            DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "materia_prima"), "");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i][2].ToString();

                BlockElementView block = new BlockElementView(false);
                block.Element = new BlockElement() { Title = name };
                block.Style = BlockStyles.List;

                materialsPnl.Controls.Add(block);

                block.BringToFront();
            }
        }

        private void items_paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();

            //Exibir mensagem para arrastar e soltar
            if (itemsPnl.Controls.Count == 0)
                DrawUtil.DrawText("Arraste e solte as matérias primas aqui", font, itemsPnl.ClientRectangle, new PointF(.5f, .5f), new PointF(.5f, .5f), e.Graphics, path);
            else
                DrawUtil.DrawText(message, font, itemsPnl.ClientRectangle, new PointF(.5f, .95f), new PointF(.5f, .5f), e.Graphics, path);

            e.Graphics.FillPath(Brushes.Silver, path);
        }

        private bool is_processing;
        private void content_paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();

            //Exibir mensagem para passar o mouse
            if (itemsPnl.Controls.Count == 0)
                DrawUtil.DrawText("Passe o mouse aqui para atualizar os valores", font, contentPnl.ClientRectangle, new PointF(.5f, .5f), new PointF(.5f, .5f), e.Graphics, path);
            else
                DrawUtil.DrawText(is_processing ? "Calculando..." : "Garantias", font, contentPnl.ClientRectangle, new PointF(.5f, .95f), new PointF(.5f, .5f), e.Graphics, path);

            e.Graphics.FillPath(Brushes.Silver, path);
        }

        private void added(object sender, ControlEventArgs e)
        {
            RefreshContent();

            RefreshValues();

            itemsPnl.Refresh();
        }

        private void removed(object sender, ControlEventArgs e)
        {
            RefreshContent();

            RefreshValues();
        }

        private void RefreshCounts()
        {
            try
            {
                float liters = float.Parse(litersTbx.Text);
                float density = float.Parse(densityTbx.Text);

                product_kg = liters * density;
                kgLbl.Text = string.Format("Kilos:    {0}", product_kg);
            }
            catch { }
        }

        private string message;
        private bool is_refreshing;
        private void RefreshValues()
        {
            if (!is_refreshing)
            {
                is_refreshing = true;

                float liters = 0;
                float density = 1;
                float kg = 0;

                try
                {
                    liters = float.Parse(litersTbx.Text);
                    density = float.Parse(densityTbx.Text);

                    kg = liters * density;
                }
                catch { }

                float total_percent = 0;

                for (int i = 0; i < itemsPnl.Controls.Count; i++)
                {
                    if (itemsPnl.Controls[i] is BlockElementView)
                    {
                        BlockElementView view = (BlockElementView)itemsPnl.Controls[i];

                        float percent;
                        if (float.TryParse(view.Element.GetFieldValueByName("percent"), out percent))
                        {
                            total_percent += percent;

                            //Atribuir escala
                            percent /= 100;

                            view.SetFieldValueByName((decimal)(kg * percent), "kg");

                            DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectWhereSyntax(), "nutrientes", "materia_prima", string.Format("{0} = '{1}'", sql.OnFormatField("nome"), view.Title)), "");

                            //Calcular com todos os elementos
                            float content = 0;
                            for (int k = 0; k < table.Rows.Count; k++)
                            {
                                Element[] elements = JsonConvert.DeserializeObject<Element[]>(table.Rows[k][0].ToString());

                                //Elementos da solução
                                for (int l = 0; l < elements.Length; l++)
                                {
                                    Element element = elements[l];

                                    content += element.Percent;
                                }
                            }
                        }
                    }
                }

                if (total_percent > 100)
                    message = string.Format("A porcentagem total está com {0:N2}% a mais", total_percent - 100);
                else if (total_percent < 100)
                    message = string.Format("A porcentagem total ainda falta {0:N2}%", 100 - total_percent);
                else
                    message = "Tudo OK";

                itemsPnl.Refresh();

                is_refreshing = false;
            }
        }

        private void RefreshContent()
        {
            if (!block_values_changed) return;

            Cursor = Cursors.WaitCursor;
            is_processing = true;
            contentPnl.Refresh();

            //Limpar teores
            contentPnl.Controls.Clear();

            //Pesquisar todos os elementos incluindo os compostos
            Element[] all_elements = PeriodicTable.GetAllElements(sql);

            //Somar todas as porcentagens e exibir
            for (int i = 0; i < all_elements.Length; i++)
            {
                Element periodic_element = all_elements[i];

                string name = periodic_element.Name;

                //Teor
                float content = -1;

                //Verificar todos os blocos
                for (int j = 0; j < itemsPnl.Controls.Count; j++)
                {
                    if (itemsPnl.Controls[j] is BlockElementView)
                    {
                        BlockElementView block_item = (BlockElementView)itemsPnl.Controls[j];

                        DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectWhereSyntax(), "nutrientes", "materia_prima", string.Format("{0} = '{1}'", sql.OnFormatField("nome"), block_item.Title)), "");

                        List<string> results = new List<string>();

                        for (int k = 0; k < table.Rows.Count; k++)
                        {
                            Element[] elements = JsonConvert.DeserializeObject<Element[]>(table.Rows[k][0].ToString());

                            //Elementos da solução
                            for (int l = 0; l < elements.Length; l++)
                            {
                                Element element = elements[l];

                                if (element.Name.Equals(name))
                                {
                                    //Somar teor e garantias
                                    float percent;
                                    if (float.TryParse(block_item.Element.GetFieldValueByName("percent"), out percent))
                                        content += element.Percent * percent;
                                }
                            }
                        }
                    }
                }

                //Mostrar valor do teor
                if (content > 0)
                {
                    BlockElement content_element = new BlockElement();
                    content_element.Title = name;
                    content_element.Description = string.Format("{0:N3}", content / 100);
                    content_element.StripeColor = PeriodicTable.GetElementGroupColor(periodic_element.Tag);

                    contentPnl.Controls.Add(new BlockElementView(false) { Element = content_element, Width = 110 });
                }
            }

            Cursor = Cursors.Default;
            is_processing = false;
            contentPnl.Refresh();

            block_values_changed = false;
        }

        private void values_changed(object sender, EventArgs e)
        {
            RefreshCounts();

            RefreshValues();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            Search search = new Search(sql);
            search.TableFilter = "clientes";
            if (search.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                clientTbx.Text = search.SelectedValue;
        }

    }
}
