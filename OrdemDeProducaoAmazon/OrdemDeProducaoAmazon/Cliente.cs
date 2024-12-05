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
    public partial class Cliente : Form
    {

        public Cliente()
        {
            InitializeComponent();
        }

        private SQLAdapter sql;
        public Cliente(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            sql.DropTable("", "clientes");
            sql.CreateTable("", "clientes", "`id` INTEGER PRIMARY KEY AUTOINCREMENT, `nome` TEXT, `sobrenome` TEXT, `rg` TEXT, `cpf_cnpj` TEXT, `telefone` TEXT");

            //Eventos ao remover ou para editar uma tabela
            clientesGrid.UserDeletingRow += (o, args) =>
            {
                if (MessageBox.Show("Deseja mesmo excluir esse cliente?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    sql.DeleteFrom("", "clientes", string.Format("`id` = {0}", args.Row.Cells[0].Value.ToString()));
                else
                    args.Cancel = true;
            };

            clientesGrid.DoubleClick += delegate
            {
                if (clientesGrid.SelectedRows.Count > 0)
                {
                    selected_row = clientesGrid.Rows[clientesGrid.SelectedRows[0].Index];

                    is_editing = true;

                    nomeTbx.Text = selected_row.Cells[1].Value.ToString();
                    sobrenomeTbx.Text = selected_row.Cells[2].Value.ToString();
                    rgTbx.Text = selected_row.Cells[3].Value.ToString();
                    cpfTbx.Text = selected_row.Cells[4].Value.ToString();
                    telefoneTbx.Text = selected_row.Cells[5].Value.ToString();

                    clientesGrid.Enabled = false;
                    adicionarBtn.Text = "Editar";
                }
            };

            AtualizarLista();
        }

        private bool is_editing;
        private DataGridViewRow selected_row;
        private void AdicionarOuEditarCliente()
        {
            //Inserir item na tabela de matéria-prima
            if (is_editing)
                sql.UpdateTable("", "clientes", string.Format("`nome` = '{0}', `sobrenome` = '{1}', `rg` = '{2}', `cpf_cnpj` = '{3}', `telefone` = '{4}'", nomeTbx.Text, sobrenomeTbx.Text, rgTbx.Text, cpfTbx.Text, telefoneTbx.Text), string.Format("`id` = {0}", selected_row.Cells[0].Value.ToString()));
            else
                sql.InsertInTable("", "clientes", "`nome`, `sobrenome`, `rg`, `cpf_cnpj`, `telefone`", string.Format("'{0}', '{1}', '{2}', '{3}', '{4}'", nomeTbx.Text, sobrenomeTbx.Text, rgTbx.Text, cpfTbx.Text, telefoneTbx.Text));

            nomeTbx.Text = "";
            sobrenomeTbx.Text = "";
            rgTbx.Text = "";
            cpfTbx.Text = "";
            telefoneTbx.Text = "";

            clientesGrid.Enabled = true;
            adicionarBtn.Text = "Adicionar";

            AtualizarLista();
        }

        private void AtualizarLista()
        {
            //Visualizar itens
            clientesGrid.DataSource = sql.SelectAll("", "clientes");
            clientesGrid.Update();
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {
            AdicionarOuEditarCliente();
        }

    }
}
