using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.SQL
{
    public class SQLiteAdapter : SQLAdapter
    {

        #region Construtor
        public SQLiteAdapter(string entropy_code)
            : base(entropy_code)
        {
        }
        #endregion

        #region Configuração
        private SQLiteConnection conn;
        public override void OnSetup()
        {
            source = string.Format(@"{0}\data_base.db", Application.StartupPath);

            //Carregar configuração
            Load();

            //Criar arquivo do banco de dados
            if (!File.Exists(source))
                File.Create(source);

            //Fechar conexão (Caso esteja aberta)
            Close();

            try
            {
                conn = new SQLiteConnection(string.Format("Data Source={0};Password={1};", source, password));
            }
            catch (Exception ex) { FlagException(ex); }
        }

        public override void FailOnSetup(Exception ex)
        {
            if (ex.ToString().Contains("SQLite"))
            {
                if (MessageBox.Show("É necessário instalar a última versão do SQLite em seu computador. Deseja abrir o site para baixar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start("http://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki");
            }
            //else
            //    MessageBox.Show(ex.Message);

            Application.Exit();
        }

        public override void OnSetProperty(string name, string value)
        {
        }

        public override string OnGetProperties()
        {
            return string.Format("password={0}", Password);
        }
        #endregion

        #region Conexão
        public override void OnConnectionOpen()
        {
            conn.Open();
        }

        public override void OnConnectionClose()
        {
            conn.Close();
        }
        #endregion

        #region Sintaxe
        public override string GetIdSyntax()
        {
            return string.Format(string.Format("{0} INTEGER AUTOINCREMENT", OnFormatField("id")));
        }

        public override string GetTableNamesSyntax()
        {
            return "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%';";
        }

        public override string GetCreateUserSyntax()
        {
            throw new SQLCommandNotSupportedByAdapterException();
        }

        public override string GetDropUserSyntax()
        {
            throw new SQLCommandNotSupportedByAdapterException();
        }

        public override string GetCreateDatabaseSyntax()
        {
            throw new SQLCommandNotSupportedByAdapterException();
        }

        public override string GetDropDatabaseSyntax()
        {
            throw new SQLCommandNotSupportedByAdapterException();
        }

        public override string GetCreateTableSyntax()
        {
            return "CREATE TABLE IF NOT EXISTS {0}({1});";
        }

        public override string GetDropTableSyntax()
        {
            return "DROP TABLE IF EXISTS {0};";
        }

        public override string GetInsertInTableSyntax()
        {
            return "INSERT INTO {0}({1}) VALUES({2});";
        }

        public override string GetDeleteFromSyntax()
        {
            return "DELETE FROM {0}";
        }

        public override string GetDeleteFromWhereSyntax()
        {
            return "DELETE FROM {0} WHERE {1};";
        }

        public override string GetUpdateWhereSyntax()
        {
            return "UPDATE {0} SET {1} WHERE {2};";
        }

        public override string GetSelectSyntax()
        {
            return "SELECT {0} FROM {1};";
        }

        public override string GetSelectWhereSyntax()
        {
            return "SELECT {0} FROM {1} WHERE {2};";
        }

        public override string GetSelectAllSyntax()
        {
            return "SELECT * FROM {0};";
        }
        #endregion

        #region Comandos
        public override void OnDoCommand(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public override DataSet OnGetDataSet(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, conn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            DataSet result = new DataSet();

            adapter.Fill(result);

            return result;
        }
        #endregion

        #region Segurança
        public override void OnChangePassword(string user, string password)
        {
            conn.ChangePassword(password);
        }

        public override void OnLog(string message)
        {
        }
        #endregion

        #region Propriedades
        private string source = "";
        /// <summary>
        /// Local do banco de dados.
        /// </summary>
        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        #endregion

    }
}
