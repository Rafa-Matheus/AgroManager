using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    public class DrawUtil
    {

        public static void DrawText(string text, Font font, RectangleF rect, PointF text_align, PointF in_text_align, Graphics g, GraphicsPath path)
        {
            SizeF sz = g.MeasureString(text, font);

            if (sz.Width > rect.Width)
            {
                float d = sz.Width - rect.Width;
                int l = (int)(text.Length * (1f - (d / sz.Width)));

                text = text.Substring(0, l) + "...";
            }

            float x = text_align.X <= 1f ? rect.X + ((rect.Width * text_align.X) - (sz.Width * in_text_align.X)) : text_align.X;
            float y = text_align.Y <= 1f ? rect.Y + ((rect.Height * text_align.Y) - (sz.Height * in_text_align.Y)) : text_align.Y;

            path.AddString(text, font.FontFamily, (int)font.Style, font.Size * 1.30f, new PointF(x, y), new StringFormat());
        }

    }
}
