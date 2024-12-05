using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemDeProducaoAmazon
{
    public partial class Producao : Form
    {

        [Serializable]
        public class OrdemDeProducao
        {

            public string Cliente { get; set; }

            public double Densidade { get; set; }

            public double Quantidade { get; set; }

            public DataTable Dados { get; set; }

        }

        private SQLAdapter sql;
        public Producao(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            //Eventos ao editar item
            calculosGrid.CellEndEdit += delegate
            {
                AtualizarCalculos();
            };
            calculosGrid.UserDeletedRow += delegate
            {
                AtualizarCalculos();
            };

            AtualizarLista();

            for (int i = 0; i < materiasGrid.Columns.Count; i++)
                calculosGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = materiasGrid.Columns[i].Name });

            calculosGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "porcentagem" });
            calculosGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "por_kilo_ou_litro" });
        }

        private void AtualizarLista()
        {
            //Visualizar itens
            materiasGrid.DataSource = sql.SelectAll("", "materia_prima");
            materiasGrid.Update();
        }

        private double densidade;
        private double quantidade_litros;
        private void AtualizarCalculos()
        {
            if (!double.TryParse(densidadeTbx.Text, out densidade))
                return; //Não deixa continuar

            if (!double.TryParse(qdteLitrosTbx.Text, out quantidade_litros))
                return; //Não deixa continuar

            double quantidade_kilos = quantidade_litros * densidade;

            double porcentagem_total = 0;
            for (int i = 0; i < calculosGrid.Rows.Count; i++)
            {
                if (calculosGrid.Rows[i].Cells[0].Value == null)
                    continue;

                if (string.IsNullOrWhiteSpace(calculosGrid.Rows[i].Cells[0].Value.ToString()))
                    continue;

                Elemento[] nutrientes = JsonConvert.DeserializeObject(calculosGrid.Rows[i].Cells[2].Value.ToString(), typeof(Elemento[])) as Elemento[];
                Elemento[] garantias = JsonConvert.DeserializeObject(calculosGrid.Rows[i].Cells[3].Value.ToString(), typeof(Elemento[])) as Elemento[];

                double porcentagem;
                if (!double.TryParse(calculosGrid.Rows[i].Cells[6].Value as string, out porcentagem))
                    return; //Não deixa continuar

                calculosGrid.Rows[i].Cells[7].Value = porcentagem * quantidade_kilos / 100;

                porcentagem_total += porcentagem;
            }

            if (porcentagem_total > 100)
                msgLbl.Text = string.Format("A porcentagem total da matéria prima está com {0:N2}% a mais", porcentagem_total - 100);
            else if (porcentagem_total < 100)
                msgLbl.Text = string.Format("A porcentagem total da matéria prima ainda falta {0:N2}% para completar", 100 - porcentagem_total);
            else
                msgLbl.Text = "";
        }

        private void Main_TextChanged(object sender, EventArgs e)
        {
            AtualizarCalculos();
        }

        #region Arrastar e soltar
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = materiasGrid.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = materiasGrid.DoDragDrop(
                    materiasGrid.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            //Se a operação de mover foi bem sucedida
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow row = materiasGrid.Rows[rowIndexFromMouseDown];

                //Copiar valores do item arrastado
                object[] objects = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                    objects[i] = row.Cells[i].Value;

                DataGridViewRow new_row = new DataGridViewRow();
                new_row.CreateCells(calculosGrid, objects);

                calculosGrid.Rows.Add(new_row);
            }
        }
        #endregion

        private void menuItem2_Click(object sender, EventArgs e)
        {
            //Abrir ordem de produção
            OpenFileDialog abrir = new OpenFileDialog();
            if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OrdemDeProducao ordem = Binary.ReadFromBinary<OrdemDeProducao>(abrir.FileName);

                clienteTbx.Text = ordem.Cliente;
                densidadeTbx.Text = ordem.Densidade.ToString();
                qdteLitrosTbx.Text = ordem.Quantidade.ToString();

                calculosGrid.Columns.Clear();
                calculosGrid.Rows.Clear();

                //Carregar dados
                DataTable table = ordem.Dados;
                for (int i = 0; i < table.Columns.Count; i++)
                    calculosGrid.Columns.Add(new DataGridViewTextBoxColumn() { Name = table.Columns[i].ColumnName });

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //Copiar valores do item arrastado
                    object[] objects = new object[table.Columns.Count];
                    for (int j = 0; j < table.Columns.Count; j++)
                        objects[j] = table.Rows[i][j];

                    DataGridViewRow new_row = new DataGridViewRow();
                    new_row.CreateCells(calculosGrid, objects);

                    calculosGrid.Rows.Add(new_row);
                }

                AtualizarCalculos();
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            //Salvar ordem de produção
            OrdemDeProducao ordem = new OrdemDeProducao();
            ordem.Cliente = clienteTbx.Text;
            ordem.Densidade = densidade;
            ordem.Quantidade = quantidade_litros;

            //Salvar dados
            DataTable table = new DataTable();
            for (int i = 0; i < calculosGrid.Columns.Count; i++)
                table.Columns.Add(calculosGrid.Columns[i].Name);

            for (int i = 0; i < calculosGrid.Rows.Count - 1; i++)
            {
                int count = calculosGrid.Rows[i].Cells.Count;

                string[] values = new string[count];
                for (int j = 0; j < count; j++)
                {
                    object value = calculosGrid.Rows[i].Cells[j].Value;

                    values[j] = value != null ? value.ToString() : "";
                }

                table.Rows.Add(values);
            }
            ordem.Dados = table;

            SaveFileDialog salvar = new SaveFileDialog();
            if (salvar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Binary.WriteToBinary<OrdemDeProducao>(ordem, salvar.FileName);
        }

        private void pesquisarBtn_Click(object sender, EventArgs e)
        {
            Pesquisar pesquisar = new Pesquisar(sql);
            pesquisar.TableFilter = "clientes";
            if (pesquisar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                clienteTbx.Text = pesquisar.SelectedValue;
        }

    }
}
