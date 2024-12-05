using DHS.Printing;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class ReportPage : Page
    {

        private Pen black;
        private Font font;
        private Font bold_font;
        private string user;
        public ReportPage()
        {
            black = Pens.Black;
            font = new Font("Arial", 46, FontStyle.Regular);
            bold_font = new Font("Arial", 46, FontStyle.Bold);
            border = 100;

            Tables = new List<ReportItem>();
        }

        public string Title { get; set; }

        public List<ReportItem> Tables { get; set; }

        private float border;
        private float x;
        private float y;
        public override void OnDraw(Bitmap bmp)
        {
            if (Tables.Count > 0)
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);

                    g.DrawString("AgroManager v1.0\nSforza Tec.", new Font("Consolas", 32, FontStyle.Regular), Brushes.Black, new PointF(50, bmp.Height - 150));

                    x = border;
                    y = border;

                    //Título
                    g.DrawString(Title, new Font(font.FontFamily, 60, FontStyle.Bold), Brushes.Black, new PointF(x, y));

                    //Espaço para informações de cabeçalho
                    y += line_height * 5;

                    DrawLogo(@".\logo.png", g);

                    for (int i = 0; i < Tables.Count; i++)
                        DrawTable(Tables[i], g);
                }
        }

        private void DrawLogo(string path, Graphics g)
        {
            Bitmap bmp = new Bitmap(Image.FromFile(path));

            g.DrawImage(bmp, new RectangleF(Result.Width - border - bmp.Width, border, bmp.Width, bmp.Height));
        }

        //Desenhar tabela
        private void DrawTable(ReportItem table, Graphics g)
        {
            float max_width = Result.Width - (x * 2);

            float initial_y = y + line_height;

            int columns_count = table.SubItems.Count;

            float column_width = max_width / columns_count;

            //Título da tabela
            DrawLineText(table.Title, true, line_height, g);
            y += line_height * 2;

            //Calcular número mínimo de linhas
            int min_rows_count = 0;
            for (int i = 0; i < table.SubItems.Count; i++)
            {
                ReportItem item = table.SubItems[i];
                if (item.SubItems.Count > min_rows_count)
                    min_rows_count = item.SubItems.Count;
            }

            //Desenhar colunas
            for (int i = 0; i < columns_count; i++)
            {
                ReportItem column = table.SubItems[i];

                //Desenhar títulos das colunas
                g.Clip = new Region(DrawLineGrid(column_width, Color.WhiteSmoke, line_height, g));

                DrawLineText(column.Title, true, line_height, g);

                g.ResetClip();

                y += line_height;

                //Desenhar itens da coluna
                if (column.SubItems != null)
                {
                    //float min_height = MeasureMinHeight(table.SubItems, 0, columns_count, g) + line_height;

                    //Desenhar todas as grades antes
                    for (int j = 0; j < min_rows_count; j++)
                    {
                        g.Clip = new Region(DrawLineGrid(column_width, Color.White, line_height, g));

                        //Desenhar conteúdo
                        if (j < column.SubItems.Count)
                            DrawLineText(column.SubItems[j].Title, false, line_height, g);

                        y += line_height;

                        g.ResetClip();
                    }
                }

                x += column_width;
                y = initial_y + line_height;
            }

            x = border;
            y += (min_rows_count + 2) * line_height;
        }

        //Medir altura mínima
        //private float MeasureMinHeight(ReportItem[] table, int start_index, int length, Graphics g)
        //{
        //    float result = line_height;

        //    for (int i = start_index; i < length; i++)
        //    {
        //        ReportItem column = table[i];

        //        int rows_count = column.SubItems.Count;

        //        for (int j = 0; j < rows_count; j++)
        //        {
        //            float h = MeasureText(column.SubItems[j].Title, font, g).Height;
        //            if (h > result)
        //                result = h;
        //        }
        //    }

        //    return result;
        //}

        //Desenhar fundo da grade
        private float line_height = 80;
        private RectangleF DrawLineGrid(float column_width, Color back_color, float h, Graphics g)
        {
            RectangleF rect = new RectangleF(x, y, column_width, h);

            if (back_color != Color.Empty)
            {
                g.FillRectangle(new SolidBrush(back_color), rect);
                g.DrawRectangles(black, new[] { rect });
            }

            return rect;
        }

        //Desenhar linha
        private void DrawLineText(string content, bool bold, float h, Graphics g)
        {
            Font f = bold ? bold_font : font;
            SizeF sz = MeasureText(content, f, g);

            g.DrawString(content, f, Brushes.Black, new PointF(x + 5, y + ((h - sz.Height) / 2)));
        }

        private SizeF MeasureText(string text, Font font, Graphics g)
        {
            SizeF sz = g.MeasureString(text, font);
            sz.Height *= .85f;

            return sz;
        }

        public override void Clear()
        {
        }

        public static ReportPage GenerateFromListView(ListView list, string title)
        {
            ReportPage result = new ReportPage();
            result.Title = title;

            ReportItem table_result = new ReportItem("");
            for (int i = 0; i < list.Columns.Count; i++)
            {
                ReportItem column = new ReportItem(list.Columns[i].Text);

                for (int j = 0; j < list.Items.Count; j++)
                    if (i < list.Items[j].SubItems.Count)
                        column.SubItems.Add(new ReportItem(list.Items[j].SubItems[i].Text));

                table_result.SubItems.Add(column);
            }

            result.Tables.Add(table_result);

            return result;
        }

    }
}
