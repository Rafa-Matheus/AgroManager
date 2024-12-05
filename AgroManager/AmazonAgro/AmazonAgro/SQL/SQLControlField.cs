using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DHS.SQL;

namespace AmazonAgro
{
    public partial class SQLControlField : UserControl
    {

        private Font font;
        public SQLControlField()
        {
            InitializeComponent();

            font = new Font("Segoe UI", 12, FontStyle.Regular);
        }

        private void paint(object sender, PaintEventArgs e)
        {
            //Desenhar título
            e.Graphics.DrawString(title, font, Brushes.White, new PointF(5, 0));
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; Refresh(); }
        }

        public SQLStruct FieldStructure { get; set; }

        public void SetField(SQLStruct field, SQLEnumItem[] items)
        {
            FieldStructure = field;

            if (field.Type.Equals("sep"))
                this.Height = 20;

            bool is_null = string.IsNullOrWhiteSpace(field.Title);
            if (!is_null)
                title = string.Format("{0}:", field.Title);

            Control control = null;
            switch (field.Type)
            {
                case "text":
                    control = new TextBox() { Dock = DockStyle.Fill };
                    break;
                case "ptext":
                    control = new TextBox() { Dock = DockStyle.Fill, PasswordChar = '*' };
                    break;
                case "mtext":
                    control = new TextBox() { Dock = DockStyle.Fill, Multiline = true };

                    this.Height = 150;
                    break;
                case "mask":
                    MaskedTextBox mask = new MaskedTextBox();
                    mask.Dock = DockStyle.Fill;
                    if (field.ContainsProperty("mask"))
                        mask.Mask = field.GetPropertyValue("mask");

                    control = mask;
                    break;
                case "date":
                    control = new DateTimePicker() { Dock = DockStyle.Fill, Value = DateTime.Now };
                    break;
                case "decimal":
                    control = new NumericUpDown() { Maximum = 1000000, DecimalPlaces = 2 };
                    break;
                case "enum":
                    ComboBox cbx = new ComboBox();
                    cbx.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbx.Dock = DockStyle.Fill;

                    cbx.Items.AddRange(items);

                    control = cbx;
                    break;
                case "chitem":
                    control = new CheckBox() { Dock = DockStyle.Fill };
                    break;

                case "chitems":
                    CheckedListBox chitem = new CheckedListBox();
                    chitem.CheckOnClick = true;
                    chitem.Dock = DockStyle.Fill;

                    chitem.Items.AddRange(items.ToArray());
                    control = chitem;

                    this.Height = 150;
                    break;
            }

            if (control != null)
                container.Controls.Add(control);
        }

        public Control GetField()
        {
            if (!FieldStructure.Type.Equals("sep"))
                return container.Controls[0];

            return new Control();
        }

        public void Clear()
        {
            if (!FieldStructure.Type.Equals("sep"))
            {
                Control control = container.Controls[0];

                if (control is TextBox)
                    ((TextBox)control).Text = "";
                else if (control is MaskedTextBox)
                    ((MaskedTextBox)control).Text = "";
                else if (control is NumericUpDown)
                    ((NumericUpDown)control).Value = 0;
                else if (control is DateTimePicker)
                    ((DateTimePicker)control).Value = DateTime.Now;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control is CheckedListBox)
                {
                    CheckedListBox chk = (CheckedListBox)control;

                    int[] values = new int[chk.Items.Count];
                    for (int j = 0; j < chk.Items.Count; j++)
                        chk.SetItemChecked(j, false);
                }
                else if (control is ComboBox)
                    ((ComboBox)control).SelectedIndex = -1;
            }
        }

    }
}
