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
    public partial class MateriaPrima : Form
    {

        //ORDEM DE PRODUÇAO
        //REGISTRO DE FORMULAÇÕES
        //ANÁLISE DE FOLHA/SOLO

        public MateriaPrima()
        {
            InitializeComponent();
        }

        private SQLAdapter sql;
        public MateriaPrima(SQLAdapter sql)
        {
            InitializeComponent();

            this.sql = sql;

            //Tabela das matérias-primas
            //sql.DropTable("", "materia_prima");
            sql.CreateTable("", "materia_prima", "`id` INTEGER PRIMARY KEY AUTOINCREMENT, `nome` TEXT, `nutrientes` TEXT, `garantia_produto_final` TEXT, `valor` TEXT, `tipo` INTEGER");

            AtualizarLista();

            //Eventos ao remover ou para editar uma tabela
            materiasGrid.UserDeletingRow += (o, args) =>
            {
                if (MessageBox.Show("Deseja mesmo excluir essa matéria prima?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    sql.DeleteFrom("", "materia_prima", string.Format("`id` = {0}", args.Row.Cells[0].Value.ToString()));
                else
                    args.Cancel = true;
            };
            materiasGrid.UserDeletedRow += (o, args) =>
            {
                AtualizarLista();
            };
            materiasGrid.DoubleClick += delegate
            {
                if (materiasGrid.SelectedRows.Count > 0)
                {
                    selected_row = materiasGrid.Rows[materiasGrid.SelectedRows[0].Index];

                    is_editing = true;

                    AdicionarOuEditar();
                }
            };
        }

        private void AdicionarOuEditarMateriaPrima(string nome, Elemento[] nutrientes, Elemento[] garantias, string valor, int tipo)
        {
            //Converter estrutura de classe em linhas json
            string json_nutrientes = JsonConvert.SerializeObject(nutrientes);
            string json_garantias = JsonConvert.SerializeObject(garantias);

            //Inserir item na tabela de matéria-prima
            if (is_editing)
                sql.UpdateTable("", "materia_prima", string.Format("`nome` = '{0}', `nutrientes` = '{1}', `garantia_produto_final` = '{2}', `valor` = '{3}', `tipo` = {4}", nome, json_nutrientes, json_garantias, valor, tipo), string.Format("`id` = {0}", selected_row.Cells[0].Value.ToString()));
            else
                sql.InsertInTable("", "materia_prima", "`nome`, `nutrientes`, `garantia_produto_final`, `valor`, `tipo`", string.Format("'{0}', '{1}', '{2}', '{3}', {4}", nome, json_nutrientes, json_garantias, valor, tipo));

            AtualizarLista();
        }

        private void AtualizarLista()
        {
            //Visualizar itens
            materiasGrid.DataSource = sql.SelectAll("", "materia_prima");
            materiasGrid.Update();
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {
            AdicionarOuEditar();
        }

        private bool is_editing;
        private DataGridViewRow selected_row;
        public void AdicionarOuEditar()
        {
            EditarNomeEValor editarnome = new EditarNomeEValor();
            editarnome.Text = "Matéria Prima";

            if (is_editing)
            {
                editarnome.Nome = selected_row.Cells[1].Value.ToString();
                editarnome.Valor = selected_row.Cells[4].Value.ToString();
                editarnome.Tipo = (int)selected_row.Cells[5].Value;
            }

            if (editarnome.ShowDialog() == DialogResult.OK)
            {
                EditarElementos nutrientes = new EditarElementos();
                nutrientes.Text = "Nutrientes";

                if (is_editing)
                    nutrientes.Elementos = JsonConvert.DeserializeObject(selected_row.Cells[2].Value.ToString(), typeof(Elemento[])) as Elemento[];

                if (nutrientes.ShowDialog() == DialogResult.OK)
                {
                    //Copiar elementos para garantias
                    EditarElementos garantias = new EditarElementos();
                    garantias.Text = "Garantias";

                    if (is_editing)
                        garantias.Elementos = JsonConvert.DeserializeObject(selected_row.Cells[3].Value.ToString(), typeof(Elemento[])) as Elemento[];
                    else
                        garantias.Elementos = nutrientes.Elementos.Select(n => new Elemento() { Simbolo = n.Simbolo, Porcentagem = 0 }).ToArray();

                    if (garantias.ShowDialog() == DialogResult.OK)
                        AdicionarOuEditarMateriaPrima(editarnome.Nome, nutrientes.Elementos, garantias.Elementos, editarnome.Valor, editarnome.Tipo);
                }
            }
        }

    }
}
