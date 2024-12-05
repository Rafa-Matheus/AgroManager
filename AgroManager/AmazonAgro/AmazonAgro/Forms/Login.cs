using DHS.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class Login : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private PostgreSQLAdapter sql;
        private Font font;
        public Login()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            //Tela de exibição
            new SplashScreen().ShowDialog();

            font = new Font("Segoe UI", 20, FontStyle.Bold);

            sql = new PostgreSQLAdapter("");
            sql.OpenSetupDialog += delegate
            {
                new PostgreSQLSetup(sql).ShowDialog();
            };
            sql.Setup();
            sql.CreateConnection();

            UserManager.Initialize(sql);

            //this.Shown += delegate
            //{
            //    userTbx.Text = "manuel";
            //    passwordTbx.Text = "manuel";
            //    loginBtn.PerformClick();
            //};

            //Definir mensagem de saudação aleatória
            message = messages[new Random().Next(0, messages.Length)];
        }

        private string[] messages =
        {
            "Olá!",
            "Bem-vindo de volta!"
        };

        private string message;
        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(message, font, panel2.ClientRectangle, new PointF(.5f, .5f), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            switch (UserManager.Login(userTbx.Text, passwordTbx.Text, sql))
            {
                case 1:
                    userTbx.Text = "";
                    passwordTbx.Text = "";
                    userTbx.Focus();

                    this.Visible = false;

                    Main main = new Main(sql);
                    main.FormClosed += delegate
                    {
                        this.Visible = true;
                    };
                    main.Show();
                    break;
                //case 2:
                //    MessageBox.Show("O login já foi feito com esse usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    break;
                case 0:
                    MessageBox.Show("Usuário ou senha incorretos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.Enter))
                loginBtn.PerformClick();

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
