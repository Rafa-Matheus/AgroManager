using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.Printing
{
    public abstract class Page
    {

        public Page()
        {
            Margin = 10;
        }

        public enum Orientations
        {
            Portrait = 0,
            Landscape = 1
        }

        private Bitmap bmp;

        public Orientations Orientation { get; set; }

        public int Margin { get; set; }

        public void Draw()
        {
            //Criar folha
            if (Orientation == Orientations.Portrait)
                bmp = new Bitmap(2480, 3508);
            else
                bmp = new Bitmap(3508, 2480);

            OnDraw(bmp);
        }

        public static Bitmap DrawToBitmap(Page page)
        {
            page.Draw();

            return page.Result;
        }

        public abstract void OnDraw(Bitmap bmp);

        public abstract void Clear();

        public Bitmap Result { get { return bmp; } }

        public void Print()
        {
            //Desenhar tudo
            Draw();

            PrintDocument doc = new PrintDocument();

            //Preservar aspecto
            bool preserve = true;

            doc.PrintPage += (o, args) =>
            {
                Rectangle m = args.MarginBounds;

                if (preserve)
                {
                    if ((double)bmp.Width / (double)bmp.Height > (double)m.Width / (double)m.Height)
                        m.Height = (int)((double)bmp.Height / (double)bmp.Width * (double)m.Width);
                    else
                        m.Width = (int)((double)bmp.Width / (double)bmp.Height * (double)m.Height);
                }

                //Desenhar folha
                args.Graphics.DrawImage(bmp, m);
            };

            //Configurações de página
            doc.DefaultPageSettings.Landscape = Orientation == Orientations.Landscape;
            doc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            //Prévia da impressão
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.ShowIcon = false;
            preview.Document = doc;
            preview.PrintPreviewControl.Controls.Clear();
            preview.UseAntiAlias = true;

            ToolStrip ts = (ToolStrip)preview.Controls[1];
            ToolStripButton printButton = (ToolStripButton)(ts).Items[0];

            //Botão original alterado para dar acesso às configurações corretas
            ts.Items.Remove(printButton);
            ToolStripButton new_printButton = new ToolStripButton();
            new_printButton.ImageIndex = printButton.ImageIndex;
            new_printButton.Visible = true;

            new_printButton.Click += delegate
                        {
                            //Configurações de impressão
                            PrintDialog pd = new PrintDialog();
                            if (pd.ShowDialog() == DialogResult.OK)
                            {
                                //Cor e imagem
                                doc.PrinterSettings = pd.PrinterSettings;

                                //Imprimir
                                doc.Print();
                            }
                        };

            ts.Items.Insert(0, new_printButton);

            preview.ShowDialog();
        }

    }
}
