using DHS.SQL;
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
    public partial class InputPassword : Form
    {

        private SQLAdapter sql;
        public InputPassword(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            infoLbl.Text = string.Format("Por favor {0}, insiria a sua senha para continuar.", UserManager.CurrentUser);
        }

        public string Password { get { return passwordTbx.Text; } }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (UserManager.CheckPassword(passwordTbx.Text, sql))
                DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("Senha inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                passwordTbx.Text = "";
                passwordTbx.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                okBtn.PerformClick();

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
