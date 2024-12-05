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
    public partial class Materials : Form
    {

        public Materials()
        {
            InitializeComponent();
        }

        private SQLAdapter sql;
        private SQLStruct structure;
        private Font font;
        public Materials(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            //Tabela das matérias primas
            structure = SQLXmlHelper.ReadFields(@".\tables\materia_prima.xml");
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

        private void AddOrEdit(string nome, Element[] nutrientes)
        {
            //Converter estrutura de classe em linhas json
            string json_nutrientes = JsonConvert.SerializeObject(nutrientes);

            //Inserir item na tabela de matéria-prima
            if (is_editing)
                sql.UpdateTable("", "materia_prima", string.Format("{0} = '{1}', {2} = '{3}'", sql.OnFormatField("nome"), nome, sql.OnFormatField("nutrientes"), json_nutrientes), string.Format("{0} = {1}", sql.OnFormatField("id"), (string)itemsLvw.Items[selected_index].Tag));
            else
                sql.InsertInTable("", "materia_prima", string.Format("{0}, {1}", sql.OnFormatField("nome"), sql.OnFormatField("nutrientes")), string.Format("'{0}', '{1}'", nome, json_nutrientes));

            RefreshList();
        }

        private void RefreshList()
        {
            //Visualizar itens
            SQLHelper.AddListViewItems(itemsLvw, structure, sql);

            itemsLvw.Columns[1].Width = 0;
        }

        private bool is_editing;
        private int selected_index;
        public void AddOrEditItem()
        {
            InputName input_name = new InputName();
            input_name.Text = "Nome";

            if (is_editing)
                input_name.Value = itemsLvw.Items[selected_index].Text;

            if (input_name.ShowDialog() == DialogResult.OK)
            {
                EditElements nutrientes = new EditElements(true, sql);

                if (is_editing)
                {
                    DataTable table = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "materia_prima"), "");

                    Element[] elements = JsonConvert.DeserializeObject<Element[]>((string)table.Rows[selected_index][3]);
                    for (int i = 0; i < elements.Length; i++)
                    {
                        Element element = elements[i];

                        BlockElementView view = new BlockElementView(true);
                        view.Style = BlockStyles.Input;
                        view.Title = element.Name;
                        view.StripeColor = Color.White; //Branco para padrozinar
                        view.AddFields(new BlockField("%", "percent") { Value = element.Percent.ToString() });

                        nutrientes.Elements.Add(view);
                    }
                }

                if (nutrientes.ShowDialog() == DialogResult.OK)
                {
                    List<Element> elements = new List<Element>();
                    for (int i = 0; i < nutrientes.Elements.Count; i++)
                    {
                        if (nutrientes.Elements[i] is BlockElementView)
                        {
                            BlockElementView view = ((BlockElementView)nutrientes.Elements[i]);

                            elements.Add(new Element(view.Title, 0) { Percent = float.Parse(view.Element.GetFieldValueByName("percent")) });
                        }
                    }

                    AddOrEdit(input_name.Value, elements.ToArray());
                }
            }

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

        private void composeBtn_Click(object sender, EventArgs e)
        {
            new ComposeMaterials(sql).ShowDialog();
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
                string message = count > 1 ? string.Format("essas {0} matérias primas", count) : "essa matéria prima";
                if (MessageBox.Show(string.Format("Deseja mesmo apagar {0}?", message), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (new InputPassword(sql).ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < count; i++)
                            sql.DeleteFrom("", "materia_prima", string.Format("{0} = {1}", sql.OnFormatField("id"), (string)itemsLvw.SelectedItems[i].Tag.ToString()));

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
