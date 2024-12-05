using DHS.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public partial class EditElements : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private Font font_1;
        private Font font_2;
        public EditElements(bool show_compose, SQLAdapter sql)
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            DragAndDropSupport dnd1 = new DragAndDropSupport(periodicPnl, itemsPnl);
            dnd1.Dropped += (o, args) =>
            {
                BlockElementView clone = ((BlockElementView)args.Control).Clone(true);
                clone.Style = BlockStyles.Input;
                clone.StripeColor = Color.White; //Branco para padronizar

                clone.AddFields(new BlockField("%", "percent"));

                itemsPnl.Controls.Add(clone);
            };

            PeriodicTable.Generate(periodicPnl);

            font_1 = new Font("Segoe UI", 20, FontStyle.Regular);
            font_2 = new Font("Segoe UI", 12, FontStyle.Bold);

            if (!show_compose)
            {
                splitter2.Visible = false;
                composePnl.Visible = false;
            }
            else
            {
                //Adicionar elementos compostos
                DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "elemento_composto"), "");

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string name = table.Rows[i][2].ToString();

                    BlockElementView block = new BlockElementView(false);
                    block.Element = new BlockElement() { Title = name };
                    block.Width = 110;

                    composePnl.Controls.Add(block);
                }

                DragAndDropSupport dnd2 = new DragAndDropSupport(composePnl, itemsPnl);
                dnd2.Dropped += (o, args) =>
                {
                    BlockElementView clone = ((BlockElementView)args.Control).Clone(true);
                    clone.Style = BlockStyles.Input;
                    clone.StripeColor = Color.White; //Branco para padronizar

                    clone.AddFields(new BlockField("%", "percent"));

                    itemsPnl.Controls.Add(clone);
                };
            }
        }

        //Adquirir elementos do elemento composto
        //public BlockElement[] GetElements(string formula, DataTable data)
        //{
        //    List<BlockElement> elements = new List<BlockElement>();
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        if (data.Rows[i][2].ToString().Equals(formula))
        //        {
        //            Element[] all_elements = JsonConvert.DeserializeObject(data.Rows[i][3].ToString(), typeof(Element[])) as Element[];
        //            for (int j = 0; j < all_elements.Length; j++)
        //            {
        //                BlockElement block = new BlockElement();
        //                block.StripeColor = Color.White;
        //                block.Style = BlockStyles.Input;
        //                block.Title = all_elements[j].Name;
        //                BlockField field = new BlockField("%", "percent");
        //                field.Value = all_elements[j].Percent.ToString();
        //                block.Fields = new[] { field };

        //                elements.Add(block);
        //            }

        //            return elements.ToArray();
        //        }

        //    }

        //    return elements.ToArray();
        //}

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public System.Windows.Forms.Control.ControlCollection Elements { get { return itemsPnl.Controls; } }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(this.Text, font_1, ClientRectangle, new PointF(.5f, 50), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

        private void resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void items_paint(object sender, PaintEventArgs e)
        {
            //Exibir mensagem para arrastar e soltar
            if (itemsPnl.Controls.Count == 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath path = new GraphicsPath();
                DrawUtil.DrawText("   Arraste e solte\nos elementos aqui", font_2, itemsPnl.ClientRectangle, new PointF(.5f, .5f), new PointF(.5f, .5f), e.Graphics, path);
                e.Graphics.FillPath(Brushes.Silver, path);
            }
        }

        private void added(object sender, ControlEventArgs e)
        {
            itemsPnl.Refresh();
        }

        private void removed(object sender, ControlEventArgs e)
        {
            itemsPnl.Refresh();
        }

    }
}
