using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.SQL.Forms
{
    public partial class SetPasswordForm : Form
    {

        private SQLAdapter sql;
        private bool is_asking_password;
        public SetPasswordForm(SQLAdapter sql, bool is_asking_password)
        {
            InitializeComponent();

            this.sql = sql;
            this.is_asking_password = is_asking_password;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (is_asking_password)
            {
                OpenAskDialog();
            }
            else
                DialogResult = DialogResult.OK;
        }

        private void OpenAskDialog()
        {
            SetPasswordForm askPassword = new SetPasswordForm(sql, false);
            askPassword.label1.Text = "Digite a senha atual:";
            if (askPassword.ShowDialog() == DialogResult.OK)
            {
                if (askPassword.Password.Equals(sql))
                {
                    sql.ChangePassword(Password);
                    MessageBox.Show("Senha definida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Senha incorreta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OpenAskDialog();
                }
            }
        }

        public string Password { get { return passwordTbx.Text; } }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    okBtn.PerformClick();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
