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
    public partial class Main : Form
    {

        //Nome
        //Simbolo
        //Porcentagens
        //Garantias
        //Preço FOB
        //Tipo de matéria (Sólido, Líquido)

        private SQLAdapter sql;
        public Main()
        {
            InitializeComponent();

            //Inicializar adaptador SQL
            sql = new SQLAdapter("");
        }

        private void produtosBtn_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto(sql);
            produto.ShowDialog();
        }

        private void ordemBtn_Click(object sender, EventArgs e)
        {
            Producao producao = new Producao(sql);
            producao.ShowDialog();
        }

        private void materiasBtn_Click(object sender, EventArgs e)
        {
            MateriaPrima materia = new MateriaPrima(sql);
            materia.ShowDialog();
        }

        private void clientesBtn_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(sql);
            cliente.ShowDialog();
        }

    }
}
