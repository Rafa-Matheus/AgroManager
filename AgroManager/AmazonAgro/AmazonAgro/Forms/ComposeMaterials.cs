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
    public partial class ComposeMaterials : Form
    {

        public ComposeMaterials()
        {
            InitializeComponent();
        }

        private SQLAdapter sql;
        private SQLStruct structure;
        private Font font;
        public ComposeMaterials(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            //Tabela das matérias primas
            structure = SQLXmlHelper.ReadFields(@".\tables\elemento_composto.xml");
            this.Text = structure.Title;

            font = new Font("Segoe UI", 20, FontStyle.Regular);

            //Parte lógica
            SQLHelper.ConvertToTable("", structure, sql);

            RefreshList();

            //Evento para editar
            itemsLvw.DoubleClick += delegate
            {
                EditItem();
            };
        }

        private void AddOrEdit(string formula)
        {
            //Inserir item na tabela de elementos compostos
            if (is_editing)
                sql.UpdateTable("", "elemento_composto", string.Format("{0} = '{1}'", sql.OnFormatField("formula"), formula), string.Format("{0} = {1}", sql.OnFormatField("id"), (string)itemsLvw.Items[selected_index].Tag));
            else
                sql.InsertInTable("", "elemento_composto", string.Format("{0}", sql.OnFormatField("formula")), string.Format("'{0}'", formula));

            RefreshList();
        }

        private void RefreshList()
        {
            //Visualizar itens
            SQLHelper.AddListViewItems(itemsLvw, structure, sql);
        }

        private bool is_editing;
        private int selected_index;
        public void AddOrEditItem()
        {
            InputName input_name = new InputName();
            input_name.Text = "Fórmula";

            if (is_editing)
                input_name.Value = itemsLvw.Items[selected_index].Text;

            if (input_name.ShowDialog() == DialogResult.OK)
                AddOrEdit(input_name.Value);

            is_editing = false;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            AddOrEditItem();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        public void EditItem()
        {
            if (itemsLvw.SelectedItems.Count > 0)
            {
                is_editing = true;

                selected_index = itemsLvw.SelectedIndices[0];

                AddOrEditItem();
            }
        }

        private void DeleteItem()
        {
            if (itemsLvw.SelectedItems.Count > 0)
            {
                int count = itemsLvw.SelectedItems.Count;
                string message = count > 1 ? string.Format("esses {0} elementos compostos", count) : "esse elemento composto";
                if (MessageBox.Show(string.Format("Deseja mesmo apagar {0}?", message), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (new InputPassword(sql).ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < count; i++)
                            sql.DeleteFrom("", "elemento_composto", string.Format("{0} = {1}", sql.OnFormatField("id"), (string)itemsLvw.SelectedItems[i].Tag.ToString()));

                        RefreshList();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    DeleteItem();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(this.Text, font, ClientRectangle, new PointF(.5f, 50), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

        private void resize(object sender, EventArgs e)
        {
            Refresh();
        }

    }
}
