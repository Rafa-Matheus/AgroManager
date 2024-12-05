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
    public partial class Produto : Form
    {

        public Produto()
        {
            InitializeComponent();
        }

        private SQLAdapter sql;
        public Produto(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            //sql.DropTable("", "produto");
            sql.CreateTable("", "produto", "`id` INTEGER PRIMARY KEY AUTOINCREMENT, `nome` TEXT, `cliente` TEXT, `data` TEXT, `cultura` TEXT, `produtos` TEXT");

            //Eventos ao remover ou para editar uma tabela
            produtosGrid.UserDeletingRow += (o, args) =>
            {
                if (MessageBox.Show("Deseja mesmo excluir esse produto?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    sql.DeleteFrom("", "produto", string.Format("`id` = {0}", args.Row.Cells[0].Value.ToString()));
                else
                    args.Cancel = true;
            };

            produtosGrid.DoubleClick += delegate
            {
                if (produtosGrid.SelectedRows.Count > 0)
                {
                    selected_row = produtosGrid.Rows[produtosGrid.SelectedRows[0].Index];

                    is_editing = true;

                    nomeTbx.Text = selected_row.Cells[1].Value.ToString();
                    clienteTbx.Text = selected_row.Cells[2].Value.ToString();
                    dataTbx.Text = selected_row.Cells[3].Value.ToString();
                    culturaTbx.Text = selected_row.Cells[4].Value.ToString();

                    produtosGrid.Enabled = false;
                    adicionarBtn.Text = "Editar";
                }
            };

            AtualizarLista();
        }

        private bool is_editing;
        private DataGridViewRow selected_row;
        private void AdicionarOuEditarProduto()
        {
            //Inserir item na tabela de matéria-prima
            if (is_editing)
                sql.UpdateTable("", "produto", string.Format("`nome` = '{0}', `cliente` = '{1}', `data` = '{2}', `cultura` = '{3}'", nomeTbx.Text, clienteTbx.Text, dataTbx.Text, culturaTbx.Text), string.Format("`id` = {0}", selected_row.Cells[0].Value.ToString()));
            else
                sql.InsertInTable("", "produto", "`nome`, `cliente`, `data`, `cultura`", string.Format("'{0}', '{1}', '{2}', '{3}'", nomeTbx.Text, clienteTbx.Text, dataTbx.Text, culturaTbx.Text));

            nomeTbx.Text = "";
            clienteTbx.Text = "";
            dataTbx.Text = "";
            culturaTbx.Text = "";

            produtosGrid.Enabled = true;
            adicionarBtn.Text = "Adicionar";

            AtualizarLista();
        }

        private void AtualizarLista()
        {
            //Visualizar itens
            produtosGrid.DataSource = sql.SelectAll("", "produto");
            produtosGrid.Update();
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {
            AdicionarOuEditarProduto();
        }

        private void pesquisarBtn_Click(object sender, EventArgs e)
        {
            Pesquisar pesquisar = new Pesquisar(sql);
            pesquisar.TableFilter = "clientes";
            if (pesquisar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                clienteTbx.Text = pesquisar.SelectedValue;
        }

    }
}
