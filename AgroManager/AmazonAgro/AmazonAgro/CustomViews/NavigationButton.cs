using System.Drawing;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class NavigationButton : RadioButton
    {

        public NavigationButton()
        {
            Appearance = Appearance.Button;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Segoe UI", 8, FontStyle.Bold);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            TextAlign = ContentAlignment.MiddleCenter;
            Cursor = Cursors.Hand;

            FlatAppearance.CheckedBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;

            AutoSize = false;

            this.Paint += (o, args) =>
            {
                args.Graphics.FillRectangle(new SolidBrush(Checked ? Color.FromArgb(112, 168, 59) : Color.White), new Rectangle(0, ClientSize.Height - 2, ClientSize.Width, 2));
            };
        }

    }
}
