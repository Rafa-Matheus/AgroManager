using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace AmazonAgro
{
    public partial class BlockElementView : UserControl
    {

        public event Action ValueChanged;

        private MouseMoveMessageFilter mouseMessageFilter;

        private Font font;
        public BlockElementView(bool is_disposable)
        {
            InitializeComponent();

            font = new Font("Segoe UI", 12, FontStyle.Regular);

            element = new BlockElement();

            disposeBtn.Visible = is_disposable;

            //Iniciar não visível
            fieldsPnl.Visible = false;
        }

        public void AddMouseEvents()
        {
            MouseMoveMessageFilter mouseMessageFilter = new MouseMoveMessageFilter();
            mouseMessageFilter.TargetControl = fieldsPnl;
            mouseMessageFilter.MouseMove += (o, args) =>
            {
                fieldsPnl.Visible = fieldsPnl.ClientRectangle.Contains(fieldsPnl.PointToClient(args.Location));
            };
            Application.AddMessageFilter(mouseMessageFilter);

            this.Disposed += delegate
            {
                Application.RemoveMessageFilter(this.mouseMessageFilter);
            };
        }

        public class MouseMoveMessageFilter : IMessageFilter
        {

            public event EventHandler<MouseEventArgs> MouseMove;

            public Control TargetControl { get; set; }

            public bool PreFilterMessage(ref Message m)
            {
                //Se não tiver sido descartado
                if (TargetControl.IsDisposed) return false;

                int numMsg = m.Msg;
                if (numMsg == 0x0200 /* WM_MOUSEMOVE */)
                {
                    if (MouseMove != null)
                        MouseMove(this, new MouseEventArgs(MouseButtons.None, 0, Control.MousePosition.X, Control.MousePosition.Y, 0));
                }

                return false;
            }

        }

        private BlockElement element;
        public BlockElement Element
        {
            get { return element; }
            set
            {
                element = value;

                Style = element.Style;
                StripeColor = element.StripeColor;
                Location = element.Location;

                //Definir propriedades
                if (element.Fields != null)
                    AddFields(element.Fields);

                Refresh();
            }
        }

        public string Title
        {
            get { return element.Title; }
            set { element.Title = value; Refresh(); }
        }

        public string Description
        {
            get { return element.Description; }
            set { element.Description = value; Refresh(); }
        }

        public BlockStyles Style
        {
            get { return element.Style; }
            set
            {
                switch (element.Style = value)
                {
                    case BlockStyles.Small:
                        Size = new Size(60, 60);
                        break;
                    case BlockStyles.List:
                        Height = 40;
                        Dock = DockStyle.Top;
                        break;
                    case BlockStyles.Input:
                        Size = new Size(150, 150);
                        break;
                }
            }
        }

        public Color StripeColor
        {
            get { return element.StripeColor; }
            set { element.StripeColor = value; }
        }

        public new Point Location
        {
            get { return base.Location; }
            set { element.Location = value; base.Location = value; }
        }

        private void paint(object sender, PaintEventArgs e)
        {
            if (element != null)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                //Desenhar faixa
                e.Graphics.FillRectangle(new SolidBrush(element.StripeColor), new Rectangle(0, 20, ClientSize.Width, 3));

                //Desenhar descrição
                e.Graphics.DrawString(element.Description, font, Brushes.White, new PointF(7, 24));

                //Desenhar título
                e.Graphics.DrawString(element.Title, font, Brushes.White, new PointF(5, Style == BlockStyles.List ? 8 : 0));

                //Se o painel estiver oculto, mostrar um resumo das informações para economizar processamento
                if (element.Fields != null && !fieldsPnl.Visible)
                {
                    string[] list = element.Fields.Select(f => string.Format("{0}: {1}", f.Title, f.Value)).ToArray();
                    e.Graphics.DrawString(string.Join("\n", list), new Font(font.FontFamily, 9), Brushes.White, new PointF(10, 50));
                }
            }
        }

        public void AddFields(params BlockField[] fields)
        {
            //Copiar campos
            element.Fields = new BlockField[fields.Length];
            for (int i = 0; i < fields.Length; i++)
                element.Fields[i] = new BlockField(fields[i].Title, fields[i].Name) { Value = fields[i].Value };

            for (int i = 0; i < fields.Length; i++)
            {
                Label label = new Label();
                label.Font = new Font(font.FontFamily, 9);
                label.Text = string.Format("{0}:", fields[i].Title);

                int index = i;
                NumericUpDown numericUd = new NumericUpDown();
                numericUd.DecimalPlaces = 2;
                numericUd.Minimum = -1000000;
                numericUd.Maximum = 1000000;

                //Definir valor
                decimal value;
                if (decimal.TryParse(element.Fields[i].Value, out value))
                    numericUd.Value = value;

                numericUd.Dock = DockStyle.Fill;
                numericUd.ValueChanged += delegate
                {
                    element.Fields[index].Value = numericUd.Value.ToString();

                    if (ValueChanged != null)
                        ValueChanged();
                };

                TableLayoutPanel layoutPnl = new TableLayoutPanel();
                layoutPnl.ColumnCount = 2;
                layoutPnl.RowCount = 1;
                layoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .5f));
                layoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .5f));
                layoutPnl.Dock = DockStyle.Top;
                layoutPnl.Height = 23;

                layoutPnl.Controls.Add(label);
                layoutPnl.Controls.Add(numericUd);

                fieldsPnl.Controls.Add(layoutPnl);

                //Trazer para cima
                layoutPnl.BringToFront();
            }

            AddMouseEvents();

            Height = (fields.Length * 23) + 60;
        }

        public void SetFieldValueByName(decimal value, string name)
        {
            for (int i = 0; i < element.Fields.Length; i++)
                if (element.Fields[(element.Fields.Length - 1) - i].Name.Equals(name)) ((NumericUpDown)((TableLayoutPanel)fieldsPnl.Controls[i]).Controls[1]).Value = value;
        }

        //Clonar bloco
        public BlockElementView Clone(bool is_disposable)
        {
            BlockElementView clone = new BlockElementView(is_disposable);

            BlockElement element_clone = new BlockElement() { Title = this.Title, Description = this.Description, Style = this.Style, StripeColor = this.StripeColor };

            //Copiar campos
            if (this.Element.Fields != null)
            {
                element_clone.Fields = new BlockField[this.Element.Fields.Length];
                for (int i = 0; i < this.Element.Fields.Length; i++)
                {
                    BlockField block_field = this.Element.Fields[i];
                    element_clone.Fields[i] = new BlockField(block_field.Title, block_field.Name) { Value = block_field.Value };
                }
            }

            clone.Element = element_clone;

            return clone;
        }

        //Salvar e carregar blocos
        public static void SaveBlocks(Control control, string path)
        {
            List<BlockElement> elements = new List<BlockElement>();
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control c = control.Controls[i];
                if (c is BlockElementView)
                    elements.Add(((BlockElementView)c).Element);
            }

            Binary.WriteToBinary(elements, path);
        }

        public static void LoadBlocks(Control control, BlockElement[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
                control.Controls.Add(new BlockElementView(true) { Element = elements[i] });
        }

        private void disposeBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
