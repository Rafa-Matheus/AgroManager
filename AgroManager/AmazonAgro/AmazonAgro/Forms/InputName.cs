using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class InputName : Form
    {

        public InputName()
        {
            InitializeComponent();
        }

        public string Value
        {
            get { return valueTbx.Text; }
            set { valueTbx.Text = value; }
        }

        public new string Text
        {
            get { return base.Text; }
            set { nameLbl.Text = string.Format("{0}:", value); base.Text = value; }
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
