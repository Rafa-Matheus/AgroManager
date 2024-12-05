using DHS.SQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class SQLControls : SQLViewsHelperBase
    {

        private Control control;
        public SQLControls(Control control)
        {
            this.control = control;
        }

        public override void OnAddView(SQLStruct structure, SQLEnumItem[] items)
        {
            SQLControlField field = new SQLControlField();
            field.Name = structure.Name;
            field.Dock = DockStyle.Top;

            field.SetField(structure, items);

            control.Controls.Add(field);

            field.BringToFront();
        }

        public override void OnStart()
        {
        }

        public override void OnEnd()
        {
        }

        public override void ClearViews()
        {
            for (int i = 0; i < control.Controls.Count; i++)
                if (control.Controls[i] is SQLControlField)
                {
                    SQLControlField cf = (SQLControlField)control.Controls[i];

                    //Se não estiver visível
                    if (!cf.FieldStructure.IsVisible) continue;

                    cf.Clear();
                }
        }

        public override SQLField[] OnGetViewValues()
        {
            List<SQLField> fields = new List<SQLField>();
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is SQLControlField)
                {
                    SQLControlField cf = (SQLControlField)control.Controls[i];

                    //Se não estiver visível
                    if (!cf.FieldStructure.IsVisible) continue;

                    string value = "";
                    if (cf.GetField() is TextBox)
                        value = ((TextBox)cf.GetField()).Text;
                    else if (cf.GetField() is MaskedTextBox)
                        value = ((MaskedTextBox)cf.GetField()).Text;
                    else if (cf.GetField() is DateTimePicker)
                        value = ((DateTimePicker)cf.GetField()).Value.ToBinary().ToString();
                    else if (cf.GetField() is NumericUpDown)
                        value = ((NumericUpDown)cf.GetField()).Value.ToString();
                    else if (cf.GetField() is CheckBox)
                        value = ((CheckBox)cf.GetField()).Checked.ToString().ToLower();
                    else if (cf.GetField() is CheckedListBox)
                    {
                        CheckedListBox chk = (CheckedListBox)cf.GetField();

                        int[] values = new int[chk.Items.Count];
                        for (int j = 0; j < chk.Items.Count; j++)
                            values[j] = chk.GetItemChecked(j) ? 1 : 0;

                        value = string.Join(";", values);
                    }
                    else if (cf.GetField() is ComboBox)
                        value = ((ComboBox)cf.GetField()).Text;

                    SQLField sqlf = new SQLField(cf.FieldStructure.Name, cf.FieldStructure.Type, value);

                    fields.Add(sqlf);
                }
            }

            return fields.ToArray();
        }

        public override void OnSetViewValue(SQLField field)
        {
            Control[] controls = control.Controls.Find(field.Name, true);

            if (controls.Length > 0)
            {
                SQLControlField cf = (SQLControlField)controls[0];

                //Se não estiver visível
                if (!cf.FieldStructure.IsVisible) return;

                switch (field.Type)
                {
                    case "enum":
                        ((ComboBox)cf.GetField()).Text = field.Value;
                        break;
                    case "text":
                    case "ptext":
                    case "mtext":
                        ((TextBox)cf.GetField()).Text = field.Value;
                        break;
                    case "mask":
                        ((MaskedTextBox)cf.GetField()).Text = field.Value;
                        break;
                    case "date":
                        ((DateTimePicker)cf.GetField()).Value = DateTime.FromBinary(long.Parse(field.Value));
                        break;
                    case "decimal":
                        ((NumericUpDown)cf.GetField()).Value = decimal.Parse(field.Value);
                        break;
                    case "chitem":
                        bool value;
                        if (bool.TryParse(field.Value, out value))
                            ((CheckBox)cf.GetField()).Checked = value;
                        break;
                    case "chitems":
                        int[] values = field.Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(v => int.Parse(v)).ToArray();
                        for (int i = 0; i < values.Length; i++)
                            ((CheckedListBox)cf.GetField()).SetItemChecked(i, values[i] == 1);
                        break;
                }
            }
        }

    }
}
