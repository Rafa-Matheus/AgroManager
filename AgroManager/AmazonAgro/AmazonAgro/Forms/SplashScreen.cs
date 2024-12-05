using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class SplashScreen : Form
    {

        //Efeito sombra e aceleração gráfica
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = 0x20000;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private string[] messages = {
            "Carregando metas...",
            "Carregando custeio...",
            "Carregando recomendações...",
            "Carregando busca de produtos...",
            "Carregando ferramentas...",
            "Carregando telas do ambiente..."
        };

        private int message_index = 0;
        public SplashScreen()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            this.Shown += delegate
            {
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Interval = 700; //Isso é o que determina o quanto a tela de exibição irá ser mostrada

                t.Tick += delegate
                {
                    if (message_index < messages.Length)
                    {
                        messageLbl.Text = messages[message_index];

                        message_index++;
                    }
                    else
                        Close();
                };
                t.Start();
            };
        }

        private void paint(object sender, PaintEventArgs e)
        {
            //Borda da janela
            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1));
        }

    }
}
