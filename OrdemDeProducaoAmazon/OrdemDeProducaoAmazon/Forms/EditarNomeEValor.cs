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
    public partial class EditarNomeEValor : Form
    {

        public EditarNomeEValor()
        {
            InitializeComponent();
        }

        public string Nome
        {
            get { return nomeTbx.Text; }
            set { nomeTbx.Text = value; }
        }

        public string Valor
        {
            get { return valorTbx.Text; }
            set { valorTbx.Text = value; }
        }

        public int Tipo
        {
            get { return tipoCbx.SelectedIndex; }
            set { tipoCbx.SelectedIndex = value; }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                okBtn.PerformClick();
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
