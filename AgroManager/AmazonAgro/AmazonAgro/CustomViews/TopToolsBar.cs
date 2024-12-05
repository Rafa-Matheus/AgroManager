using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class TopToolsBar : Panel
    {

        public event EventHandler<TopToolsPageSelectedIndexChangedEventArgs> PageSelectedIndexChanged;

        public class TopToolsPageSelectedIndexChangedEventArgs : EventArgs
        {
            public int Index { get; set; }
        }

        private CustomTabControl tabs;
        public TopToolsBar()
        {
            tabs = new CustomTabControl();
            tabs.SelectedIndexChanged += (o, args) =>
            {
                if (PageSelectedIndexChanged != null)
                    PageSelectedIndexChanged(this, new TopToolsPageSelectedIndexChangedEventArgs() { Index = tabs.SelectedIndex });
            };
            tabs.Dock = DockStyle.Fill;

            Controls.Add(tabs);
        }

        public void AddPage(string title)
        {
            TabPage page = new TabPage(title);
            page.BackColor = Color.Black;
            page.Padding = new Padding(0);
            tabs.TabPages.Add(page);
        }

        public void AddButton(string title, string icon_path, int page_index, TopToolsBarButtonSides side, Action on_click)
        {
            AddButton(title, File.Exists(icon_path) ? Image.FromFile(icon_path) : null, page_index, side, on_click);
        }

        public void AddButton(string title, Image icon, int page_index, TopToolsBarButtonSides side, Action on_click)
        {
            Button b = new Button();
            b.FlatStyle = FlatStyle.Flat;
            b.TextAlign = ContentAlignment.BottomCenter;
            b.FlatAppearance.BorderSize = 0;
            b.Text = title;
            b.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            b.Width = 80;
            b.FlatAppearance.MouseOverBackColor = Color.DimGray;

            b.Click += delegate
            {
                on_click();
            };

            b.Image = icon;
            b.TextImageRelation = TextImageRelation.ImageAboveText;

            if (page_index >= 0 && page_index < tabs.TabPages.Count)
                tabs.TabPages[page_index].Controls.Add(b);

            switch (side)
            {
                case TopToolsBarButtonSides.Left:
                    b.Dock = DockStyle.Left;
                    b.BringToFront();
                    break;
                case TopToolsBarButtonSides.Right:
                    b.Dock = DockStyle.Right;
                    break;
            }
        }

        public Button GetButton(int page_index, int button_index)
        {
            return (Button)tabs.TabPages[page_index].Controls[button_index];
        }

    }
}
