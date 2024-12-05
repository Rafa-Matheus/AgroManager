using DHS.SQL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class Costing : Form
    {

        private SQLAdapter sql;
        public Costing(SQLAdapter sql)
        {
            InitializeComponent();

            //Mudar o formato
            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            this.sql = sql;

            string[] costs_columns = { "Matéria Prima", "%", "Kilogramas", "Custo por Kilo ($)", "TOTAL ($)" };

            for (int i = 0; i < costs_columns.Length; i++)
                costsLvw.Columns.Add(costs_columns[i], 100);

            string[] packs_columns = { "Nome", "Distribuidor", "Embalagem ($)", "Litros", "Rótulo ($)", "Caixa ($)", "Rótulo da Caixa ($)", "Capacidade da Caixa", "TOTAL ($)" };

            for (int i = 0; i < packs_columns.Length; i++)
                packsLvw.Columns.Add(packs_columns[i], 120);

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
                    costsLvw.Items.Clear();

                    Product product = Product.Load(op.FileName);

                    density = product.Density;
                    kg_count = product.Liters * density;

                    productTbx.Text = product.Name;
                    clientTbx.Text = product.Client;

                    for (int i = 0; i < product.Blocks.Length; i++)
                    {
                        BlockElement element = product.Blocks[i];

                        ListViewItem item = new ListViewItem(element.Title);
                        item.SubItems.Add(element.GetFieldValueByName("percent"));
                        item.SubItems.Add(element.GetFieldValueByName("kg"));
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");

                        costsLvw.Items.Add(item);
                    }

                    ListViewItem total_item = new ListViewItem("TOTAL");
                    total_item.SubItems.Add("-");
                    total_item.SubItems.Add("-");
                    total_item.SubItems.Add("-");
                    total_item.SubItems.Add("-");

                    //Linha do TOTAL
                    costsLvw.Items.Add(total_item);

                    RefreshCosts();
                }
            });
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
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            Search search = new Search(sql);
            search.TableFilter = "clientes";
            if (search.ShowDialog() == DialogResult.OK)
                clientTbx.Text = search.SelectedValue;
        }

        private float density;
        private float kg_count;
        private void RefreshCosts()
        {
            DataTable prices = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "base_precos"), "");

            //Custo de produção
            float prod_cost_kg = 0;
            try
            {
                prod_cost_kg = float.Parse(prodCostTbx.Text);
            }
            catch { }

            float total_kg = 0;
            float total_percent = 0;
            float total_kg_price = 0;
            float total_final_price = 0;
            for (int i = 0; i < costsLvw.Items.Count - 1; i++)
            {
                ListViewItem cost_item = costsLvw.Items[i];

                //Somar porcentagem total
                total_percent += float.Parse(cost_item.SubItems[1].Text);

                //Adquirir custo do kg
                float price = GetPrice(prices, cost_item.Text);

                total_kg_price += price;

                float kg = float.Parse(cost_item.SubItems[2].Text);

                cost_item.SubItems[3].Text = string.Format("{0:N2}", price);

                float final_price = (price + prod_cost_kg) * kg;
                total_final_price += final_price;

                cost_item.SubItems[4].Text = string.Format("{0:N2}", final_price);
                //cost_item.SubItems[4].Text = string.Format("{0:N2}", price * kg);

                total_kg += kg;
            }

            //Linha dos totais (Última linha)
            ListViewItem total_item = costsLvw.Items[costsLvw.Items.Count - 1];

            total_item.SubItems[1].Text = string.Format("{0:N2}", total_percent);
            total_item.SubItems[2].Text = string.Format("{0:N2}", total_kg);
            total_item.SubItems[3].Text = string.Format("{0:N2}", total_kg_price);
            total_item.SubItems[4].Text = string.Format("{0:N2}", total_final_price);

            //Preço com embalagens
            DataTable packs = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "embalagens"), "");

            packsLvw.Items.Clear();

            //O valor que totaliza já está por 1 kilo
            float total_lt_price = total_kg_price * density;

            for (int i = 0; i < packs.Rows.Count; i++)
            {
                string pack_name = packs.Rows[i][2].ToString();
                string dispenser_name = packs.Rows[i][4].ToString();

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

                ListViewItem pack_item = new ListViewItem(pack_name);
                pack_item.SubItems.Add(dispenser_name);
                pack_item.SubItems.Add(string.Format("{0:N2}", pack_cost));
                pack_item.SubItems.Add(pack_liters.ToString());
                pack_item.SubItems.Add(string.Format("{0:N2}", label_cost));

                pack_item.SubItems.Add(use_box ? string.Format("{0:N2}", box_cost) : "Não usa caixa");
                pack_item.SubItems.Add(use_box ? string.Format("{0:N2}", box_label_cost) : "Não usa caixa");
                pack_item.SubItems.Add(use_box ? box_count.ToString() : "Não usa caixa");

                float total = 0;

                //Se usa caixa
                //(Preço por litro * Capacidade em litros) + Custo da embalagem + Custo do rótulo da embalagem + ((Custo da caixa + Custo do rótulo da caixa) / Capacidade da caixa))
                if (use_box)
                    total = (total_lt_price * pack_liters) + pack_cost + label_cost + ((box_cost + box_label_cost) / box_count);
                else
                    total = (total_lt_price * pack_liters) + pack_cost + label_cost;

                total += (prod_cost_kg * density) * pack_liters;

                //TOTAL
                pack_item.SubItems.Add(string.Format("{0:N2}", total));

                packsLvw.Items.Add(pack_item);
            }

            float one_kg = total_final_price / 1000;
            float one_lt = one_kg / density;

            costsMsgLbl.Text = string.Format("Custos:\n1 Kg: {0:N2}\n1 L: {1:N2}  Densidade: {2}\nA fórmula está com {3}% e um total de {4} kilos.", one_kg, one_lt, density, total_percent, total_kg);
        }

        public static float GetPrice(DataTable table, string name)
        {
            for (int i = 0; i < table.Rows.Count; i++)
                if (table.Rows[i][2].ToString().Equals(name))
                    return float.Parse(table.Rows[i][6].ToString());

            return 0;
        }

        private void prod_cost_changed(object sender, EventArgs e)
        {
            RefreshCosts();
        }

    }
}
