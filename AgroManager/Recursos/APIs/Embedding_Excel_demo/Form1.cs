using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmbeddedExcel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            excelWrapper1.OpenFile(this.openFileDialog1.FileName);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            excelWrapper1.ToolBarVisible = this.checkBox1.Checked;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            excelWrapper1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            excelWrapper1.Replace("", "");
        }

    }
}