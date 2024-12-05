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
    public partial class EditarElementos : Form
    {

        public EditarElementos()
        {
            InitializeComponent();
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

        private void addElementBtn_Click(object sender, EventArgs e)
        {
            double porcentagem;
            if (!double.TryParse(porcentagemTbx.Text, out porcentagem))
                return; //Não deixa continuar

            Elemento elemento = new Elemento();
            elemento.Simbolo = simboloTbx.Text;
            elemento.Porcentagem = porcentagem;

            if (is_editing)
            {
                elementosLbx.Items[selected_index] = elemento;

                addElementBtn.Text = "Adicionar";
                elementosLbx.Enabled = true;
                is_editing = false;
            }
            else
                elementosLbx.Items.Add(elemento);

            simboloTbx.Text = "";
            porcentagemTbx.Text = "";
        }

        public Elemento[] Elementos
        {
            get { return ConvertToArray(); }
            set
            {
                elementosLbx.Items.Clear();
                elementosLbx.Items.AddRange(value);
            }
        }

        private Elemento[] ConvertToArray()
        {
            int count = elementosLbx.Items.Count;

            Elemento[] elementos = new Elemento[elementosLbx.Items.Count];
            for (int i = 0; i < count; i++)
                elementos[i] = elementosLbx.Items[i] as Elemento;

            return elementos;
        }

        private bool is_editing;
        private int selected_index;
        private void double_click(object sender, EventArgs e)
        {
            if (elementosLbx.SelectedIndex != -1)
            {
                selected_index = elementosLbx.SelectedIndex;

                Elemento elemento = elementosLbx.Items[selected_index] as Elemento;

                simboloTbx.Text = elemento.Simbolo;
                porcentagemTbx.Text = elemento.Porcentagem.ToString();

                is_editing = true;

                elementosLbx.Enabled = false;

                addElementBtn.Text = "Editar";
            }
        }

    }
}
