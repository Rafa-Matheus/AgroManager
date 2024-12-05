using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class CustomTabControl : TabControl
    {
        public static bool N_PositionMode;
        public static bool N_PlusButton;

        public CustomTabControl()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            //DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;

            ItemSize = new Size(120, 30);

            N_PositionMode = false;
            N_PlusButton = false;

            //SetWindowTheme(this.Handle, "", "");
            //var tab = new TabPadding(this);
        }

        //[DllImportAttribute("uxtheme.dll")]
        //private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        //All Properties
        [Description("Desides if the Tab Control will display in vertical mode."), Category("Design"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool VerticalMode { get { return N_PositionMode; } set { N_PositionMode = value; if (N_PositionMode == true) { SetToVerticalMode(); } if (N_PositionMode == false) { SetToHorrizontalMode(); } } }

        //Method for all of the properties
        private void SetToHorrizontalMode() { ItemSize = new Size(120, 30); Alignment = TabAlignment.Top; }
        private void SetToVerticalMode() { ItemSize = new Size(30, 120); Alignment = TabAlignment.Left; }

        //protected override void CreateHandle()
        //{
        //    base.CreateHandle();
        //    Alignment = TabAlignment.Top;
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Width, Height);

            Graphics g = Graphics.FromImage(bitmap);

            //Back Color
            g.Clear(Color.FromArgb(30, 30, 30));

            Color NonSelected = Color.FromArgb(62, 62, 62);

            //Aba selecionada
            Color Selected = Color.FromArgb(112, 168, 59);

            SolidBrush NOSelect = new SolidBrush(NonSelected);
            SolidBrush ISSelect = new SolidBrush(Selected);

            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle TabRectangle = GetTabRect(i);

                if (i == SelectedIndex)
                    //Tab is selected
                    g.FillRectangle(ISSelect, TabRectangle);
                else
                    //Tab is not selected
                    g.FillRectangle(NOSelect, TabRectangle);

                StringFormat sf = new StringFormat();

                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                Font font = new Font("Segoe UI", 10.0f);

                g.DrawString(TabPages[i].Text, font, Brushes.White, TabRectangle, sf);

                //TabPages[i].BackColor = Color.FromArgb(62, 62, 62);
                //TabPages[i].Padding = Point(0, 0);
            }

            e.Graphics.DrawImage(bitmap, 0, 0);
            g.Dispose();
            bitmap.Dispose();

            //base.OnPaint(e);
        }

    }
}
