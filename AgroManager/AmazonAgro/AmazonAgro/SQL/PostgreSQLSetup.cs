using DHS.SQL;
using System;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class PostgreSQLSetup : Form
    {

        private readonly PostgreSQLAdapter sql;
        public PostgreSQLSetup(PostgreSQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            serverTbx.Text = sql.Server;
            portTbx.Text = sql.Port;
            databaseTbx.Text = sql.Database;
            userTbx.Text = sql.User;
            passwordTbx.Text = sql.Password;

            FormClosing += delegate
            {
                bool isActive = false;
                for (int formIndex = 0; formIndex < Application.OpenForms.Count; formIndex++)
                    if (Application.OpenForms[formIndex].Name.Equals("Main"))
                    {
                        isActive = true;
                        break;
                    }

                if (!connectionOk && !isActive)
                    Application.Exit();
            };
        }

        private bool connectionOk;
        private void OnClick_testBtn(object sender, EventArgs e)
        {
            sql.ThrownAdapterException += (o, args) =>
            {
                MessageBox.Show(args.Exception.ToString());
            };

            sql.SetProperty("server", serverTbx.Text);
            sql.SetProperty("port", portTbx.Text);
            sql.SetProperty("database", databaseTbx.Text);
            sql.SetProperty("user", userTbx.Text);
            sql.SetProperty("password", passwordTbx.Text);

            //Definir valores
            sql.CreateConnection();

            if (sql.Open())
            {
                MessageBox.Show("Conexão realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UserManager.Initialize(sql);

                connectionOk = true;

                sql.Save();

                sql.Close();
            }
            else
                MessageBox.Show("Não foi possível realizar a conexão.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void OnClick_okBtn(object sender, EventArgs e)
        {
            Close();
        }

    }
}
