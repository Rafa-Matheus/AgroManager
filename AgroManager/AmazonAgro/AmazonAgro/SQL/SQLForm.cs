using DHS.SQL;
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
    public partial class SQLForm : Form
    {

        public SQLForm()
        {
            InitializeComponent();
        }

        private SQLAdapter sql;
        private SQLStruct structure;
        private SQLControls controls;
        private string table_name;
        private string title;
        private Font font;
        public SQLForm(SQLAdapter sql, string xml)
        {
            InitializeComponent();

            this.sql = sql;

            sql.ThrownAdapterException += (o, args) =>
            {
                MessageBox.Show(args.Exception.ToString());
            };

            structure = SQLXmlHelper.ReadFields(xml);
            this.Text = title = structure.Title;
            table_name = structure.Name;

            font = new Font("Segoe UI", 20, FontStyle.Regular);

            //Parte lógica
            SQLHelper.ConvertToTable("", structure, sql);

            //Parte visual
            controls = new SQLControls(panel1);
            controls.AddViews(structure, sql);

            //Evento para editar uma tabela
            itemsLvw.DoubleClick += delegate
            {
                EditItem();
            };

            //Barra de botões
            topToolsBar.AddPage("Gerenciar");
            topToolsBar.AddButton("Adicionar", Properties.Resources.add, 0, TopToolsBarButtonSides.Left, delegate
            {
                if (controls.IsUpdating) return;

                controls.Insert();

                RefreshList();
            });
            topToolsBar.AddButton("Editar", Properties.Resources.edit, 0, TopToolsBarButtonSides.Left, delegate
            {
                EditItem();
            });
            topToolsBar.AddButton("Apagar", Properties.Resources.remove_all, 0, TopToolsBarButtonSides.Left, delegate
            {
                if (controls.IsUpdating) return;

                DeleteItem();
            });
            topToolsBar.AddButton("Cancelar", Properties.Resources.cancel, 0, TopToolsBarButtonSides.Left, delegate
            {
                Cancel();
            });
            topToolsBar.GetButton(0, 0).Visible = false;

            RefreshList();
        }

        private void RefreshList()
        {
            //Visualizar itens
            SQLHelper.AddListViewItems(itemsLvw, structure, sql);
            itemsLvw.Enabled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    DeleteItem();
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EditItem()
        {
            if (controls.IsUpdating)
            {
                controls.EndUpdate();

                topToolsBar.GetButton(0, 0).Visible = false;

                RefreshList();

                topToolsBar.GetButton(0, 2).BackColor = Color.Black;
            }
            else if (itemsLvw.SelectedItems.Count > 0)
            {
                controls.StartUpdate(int.Parse(itemsLvw.SelectedItems[0].Tag.ToString()));

                itemsLvw.Enabled = false;

                topToolsBar.GetButton(0, 0).Visible = true;

                topToolsBar.GetButton(0, 2).BackColor = Color.FromArgb(112, 168, 59);
            }
            else
                MessageBox.Show("Selecione um item abaixo para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteItem()
        {
            if (itemsLvw.SelectedItems.Count > 0)
            {
                int count = itemsLvw.SelectedItems.Count;
                string message = count > 1 ? string.Format("esses {0} itens", count) : "esse item";
                if (MessageBox.Show(string.Format("Deseja mesmo apagar {0}?", message), "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (new InputPassword(sql).ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < count; i++)
                            controls.DeleteFrom(int.Parse(itemsLvw.SelectedItems[i].Tag.ToString()));

                        controls.ClearViews();

                        RefreshList();
                    }
                }
            }
            else
                MessageBox.Show("Selecione abaixo um ou mais itens para apagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Cancel()
        {
            if (controls.IsUpdating)
                if (MessageBox.Show("Deseja mesmo cancelar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controls.CancelUpdate();

                    topToolsBar.GetButton(0, 0).Visible = false;

                    RefreshList();

                    topToolsBar.GetButton(0, 2).BackColor = Color.Black;
                }
        }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            DrawUtil.DrawText(title, font, panel2.ClientRectangle, new PointF(.5f, 160), new PointF(.5f, .5f), e.Graphics, path);
            e.Graphics.FillPath(Brushes.White, path);
        }

        private void resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            if (controls.IsUpdating)
                if (MessageBox.Show("Você está fazendo uma alteração, deseja mesmo sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    //Dar mais destaque ao botão editar
                    topToolsBar.GetButton(0, 2).BackColor = Color.Gold;

                    e.Cancel = true;
                }
        }

    }
}
