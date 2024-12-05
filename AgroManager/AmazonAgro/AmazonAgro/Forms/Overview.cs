using DHS.SQL;
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
    public partial class Overview : Form
    {

        private SQLAdapter sql;
        public Overview(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            topToolsBar.AddPage("Gerenciar");
            topToolsBar.AddButton("Editar Embalagens", Properties.Resources.packs, 0, TopToolsBarButtonSides.Left, delegate
            {
                new SQLForm(sql, @".\tables\embalagens.xml").ShowDialog();

                RefreshCosts();
            });
            topToolsBar.AddButton("Base de Preços", Properties.Resources.pricing, 0, TopToolsBarButtonSides.Left, delegate
            {
                new SQLForm(sql, @".\tables\base_precos.xml").ShowDialog();

                RefreshCosts();
            });
            topToolsBar.AddButton("Imprimir", Properties.Resources.print, 0, TopToolsBarButtonSides.Left, delegate
            {
                ReportPage page = ReportPage.GenerateFromListView(productsLvw, string.Format("{0}\n{1}", this.Text, DateTime.Now.ToShortDateString()));

                ReportItem other_values = new ReportItem("");

                float prod_cost = 0;
                if (float.TryParse(prodCostTbx.Text, out prod_cost))
                {
                    ReportItem prod_value = new ReportItem("Custo de Produção/Kg");
                    prod_value.SubItems.Add(new ReportItem(prod_cost.ToString()));
                    other_values.SubItems.Add(prod_value);
                }

                page.Tables.Add(other_values);

                page.Print();
            });

            Util.OpenAndSaveProductsPath(folderPathTbx, this);

            RefreshCosts();
        }

        private void RefreshCosts()
        {
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

            //Limpar tudo
            productsLvw.Clear();

            string[] columns = { "Produto", "Densidade" };

            for (int i = 0; i < columns.Length; i++)
                productsLvw.Columns.Add(columns[i], 120);

            //Preço com embalagens
            DataTable packs = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "embalagens"), "");

            float prod_cost_kg = 0;
            try
            {
                prod_cost_kg = float.Parse(prodCostTbx.Text);
            }
            catch { }

            string[] products = Directory.GetFiles(folderPathTbx.Text);

            for (int i = 0; i < packs.Rows.Count; i++)
            {
                string pack_name = packs.Rows[i][2].ToString();

                //Nome da embalagem
                productsLvw.Columns.Add(pack_name, 100);
            }

            //Produto
            for (int j = 0; j < products.Length; j++)
            {
                string file_name = products[j];

                if (file_name.ToLower().EndsWith(".amf"))
                {
                    Product product = Product.Load(file_name);

                    float density = product.Density;

                    ListViewItem item = new ListViewItem(product.Name);
                    item.SubItems.Add(string.Format("{0:N2}", density));

                    DataTable prices = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "base_precos"), "");

                    //Para cada embalagem
                    for (int i = 0; i < packs.Rows.Count; i++)
                    {
                        float pack_liters = float.Parse(packs.Rows[i][6].ToString());
                        float pack_cost = float.Parse(packs.Rows[i][7].ToString());

                        float label_cost = float.Parse(packs.Rows[i][8].ToString());

                        bool use_box = bool.Parse(packs.Rows[i][9].ToString());

                        float box_count = 0;
                        float box_cost = 0;
                        float box_label_cost = 0;

                        if (use_box)
                        {
                            box_count = float.Parse(packs.Rows[i][10].ToString());
                            box_cost = float.Parse(packs.Rows[i][11].ToString());
                            box_label_cost = float.Parse(packs.Rows[i][12].ToString());
                        }

                        //O valor que totaliza já está por 1 kilo
                        float total_kg_price = 0;
                        for (int k = 0; k < product.Blocks.Length; k++)
                        {
                            //Adquirir custo do kg
                            float price = Costing.GetPrice(prices, product.Blocks[k].Title);

                            total_kg_price += price;
                        }

                        //O valor que totaliza já está por 1 kilo
                        float total_lt_price = total_kg_price * density;

                        //Se usar caixa
                        //(Preço por litro * Capacidade em litros) + Custo da embalagem + Custo do rótulo da embalagem + ((Custo da caixa + Custo do rótulo da caixa) / Capacidade da caixa))
                        float total = 0;
                        if (use_box)
                            total = (total_lt_price * pack_liters) + pack_cost + label_cost + ((box_cost + box_label_cost) / box_count);
                        else
                            total = (total_lt_price * pack_liters) + pack_cost + label_cost;

                        //Custo de produção
                        total += (prod_cost_kg * density) * pack_liters;

                        total = Util.ReplaceNaN(total);

                        //TOTAL
                        item.SubItems.Add(string.Format("{0:N2}", total));
                    }

                    productsLvw.Items.Add(item);
                }
            }
        }

        private void findFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_browser = new FolderBrowserDialog();
            folder_browser.Description = "Seleciona a pasta onde estão os arquivos de produto.";
            if (folder_browser.ShowDialog() == DialogResult.OK)
            {
                folderPathTbx.Text = folder_browser.SelectedPath;

                RefreshCosts();
            }
        }

        private void prod_cost_changed(object sender, EventArgs e)
        {
            RefreshCosts();
        }

    }
}
