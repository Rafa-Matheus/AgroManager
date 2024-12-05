using System.Drawing;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class CustomButton : Button
    {

        public CustomButton()
        {
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Segoe UI", 8, FontStyle.Bold);
            ForeColor = Color.White;
            BackColor = Color.FromArgb(112, 168, 59);
        }

    }
}
