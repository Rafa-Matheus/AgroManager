using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;

namespace howto_print_listview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Make the ListView column headers.
            lvwBooks.SetColumnHeaders(
                new object[] {
                    "Title", HorizontalAlignment.Left,
                    "URL", HorizontalAlignment.Left,
                    "ISBN", HorizontalAlignment.Left,
                    "Pages", HorizontalAlignment.Right,
                    "Year", HorizontalAlignment.Right
                });

            // Remove any existing items.
            lvwBooks.Items.Clear();

            // Add data rows.
            lvwBooks.AddRow("Interview Puzzles Dissected", "tinyurl.com/j3nex2u", "978-1539504887", "300", "2016");
//lvwBooks.AddRow("Interview Puzzles Dissecte", "www.csharphelper.com/puzzles.htm", "978-1539504887", "300", "2016");
            lvwBooks.AddRow("C# 24-Hour Trainer ", "tinyurl.com/n2a5797", "978-1-119-06566-1", "600", "2015");
            lvwBooks.AddRow("Beginning Software Engineering", "tinyurl.com/pz7bavo", "978-1-118-96914-4", "480", "2015");
            lvwBooks.AddRow("C# 5.0 Programmer's Reference", "tinyurl.com/qzcefsp", "978-1-118-84728-2", "960", "2014");
            lvwBooks.AddRow("Essential Algorithms", "tinyurl.com/pzuofop", "978-1-118-61210-1", "624", "2013");
            lvwBooks.AddRow("MCSD Certification Toolkit: Programming in C#", "tinyurl.com/oadu6c2", "978-1-118-61209-5", "648", "2013");
//lvwBooks.AddRow("MCSD Certification Toolkit (Exam 70-483): Programming in C#", "tinyurl.com/oadu6c2", "978-1-118-61209-5", "648", "2013");
            lvwBooks.AddRow("Visual Basic 2012 Programmer's Reference", "tinyurl.com/y8rowwnd", "978-0-470-49983-2", "1272", "2012");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Algorithms", "www.vb-helper.com/vba.htm", "0-471-24268-3", "395", "1998");
            lvwBooks.AddRow("Visual Basic Graphics Programming", "www.vb-helper.com/vbgp.htm", "0-472-35599-2", "712", "2000");
            lvwBooks.AddRow("Advanced Visual Basic Techniques", "www.vb-helper.com/avbt.htm", "0-471-18881-6", "440", "1997");
            lvwBooks.AddRow("Custom Controls Library", "www.vb-helper.com/ccl.htm", "0-471-24267-5", "684", "1998");
            lvwBooks.AddRow("Ready-to-Run Delphi Algorithms", "www.vb-helper.com/da.htm", "0-471-25400-2", "398", "1998");
            lvwBooks.AddRow("Bug Proofing Visual Basic", "www.vb-helper.com/err.htm", "0-471-32351-9", "397", "1999");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Code Library", "www.vb-helper.com/vbcl.htm", "0-471-33345-X", "424", "1999");

            lvwBooks.AddRow("Bogus Book", "www.noplace.com/bogus.htm", "0-123-45678-9", "100", "6");
            lvwBooks.AddRow("Fakey", "www.skatepark.com/fakey.htm", "9-876-54321-0", "9", "700");

            // Size the columns.
            lvwBooks.SizeColumnsToFitDataAndHeaders();

            // Make the form big enough to show the ListView.
            Rectangle item_rect =
                lvwBooks.GetItemRect(lvwBooks.Columns.Count - 1);
            this.SetClientSizeCore(
                item_rect.Left + item_rect.Width + 50,
                item_rect.Top + item_rect.Height + 75);

        }

        // Print the ListView's contents.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Start maximized.
            Form frm = ppdListView as Form;
            frm.WindowState = FormWindowState.Maximized;

            // Start at 100% scale.
            ppdListView.PrintPreviewControl.Zoom = 1.0;

            // Display.
            ppdListView.ShowDialog();
        }

        // Print the ListView's data.
        private void pdocListView_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Print the ListView.
            lvwBooks.PrintData(e.MarginBounds.Location,
                e.Graphics, Brushes.Black,
                Brushes.Blue, Pens.Blue);
        }
    }
}
