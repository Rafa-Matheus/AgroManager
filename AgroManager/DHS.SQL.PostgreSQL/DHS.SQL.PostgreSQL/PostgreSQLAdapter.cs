using Npgsql;
using System;
using System.Data;

namespace DHS.SQL
{
    public class PostgreSQLAdapter : SQLAdapter
    {

        public event Action OpenSetupDialog;

        #region Construtor
        public PostgreSQLAdapter(string entropyCode)
            : base(entropyCode)
        {
        }
        #endregion

        #region Configuração
        private NpgsqlConnection conn;
        public override void OnSetup()
        {
            //Carregar configuração
            Load();

            //Fechar conexão (Caso esteja aberta)
            Close();
        }

        public override void CreateConnection()
        {
            try
            {
                conn = new NpgsqlConnection(string.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};", server, port, data_base, user_id, password));
            }
            catch (Exception ex) { FlagException(ex, "Create Connection"); }
        }

        public override void MissingSetupParams()
        {
            if (OpenSetupDialog != null)
                OpenSetupDialog();
        }

        public override void SetProperty(string name, string value)
        {
            switch (name)
            {
                case "server":
                    Server = value;
                    break;
                case "port":
                    Port = value;
                    break;
                case "database":
                    Database = value;
                    break;
                case "user":
                    User = value;
                    break;
                case "password":
                    Password = value;
                    break;
            }
        }

        public override string OnFormatField(string value)
        {
            return string.Format("\"{0}\"", value);
        }

        public override string OnGetProperties()
        {
            return string.Format("server={0}\nport={1}\ndatabase={2}\nuser={3}\npassword={4}", server, port, data_base, user_id, password);
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
            return string.Format("{0} SERIAL", OnFormatField("id"));
        }

        public override string GetTableNamesSyntax()
        {
            return "SELECT table_name FROM information_schema.tables WHERE table_schema='public' AND table_type='BASE TABLE';";
        }

        public override string GetCreateUserSyntax()
        {
            return "CREATE USER {0} WITH PASSWORD '{1}';";
        }

        public override string GetDropUserSyntax()
        {
            return "DROP USER IF EXISTS {0};";
        }

        public override string GetCreateDatabaseSyntax()
        {
            return "CREATE DATABASE {0} WITH OWNER = {1} ENCODING = 'UTF8' CONNECTION LIMIT = -1;";
        }

        public override string GetDropDatabaseSyntax()
        {
            return "DROP DATABASE {0};";
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
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        public override DataSet OnGetDataSet(string query)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);

            DataSet result = new DataSet();

            adapter.Fill(result);

            return result;
        }
        #endregion

        #region Segurança
        public override void OnChangePassword(string user, string password)
        {
            Query("", string.Format("ALTER USER {0} WITH PASSWORD '{1}';", user, password), "");
        }

        public override void OnLog(string message)
        {
        }
        #endregion

        #region Propriedades
        private string server = "";
        /// <summary>
        /// Servidor do banco de dados.
        /// </summary>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        private string port = "";
        /// <summary>
        /// Porta do banco de dados.
        /// </summary>
        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        private string data_base = "";
        /// <summary>
        /// Nome do banco de dados.
        /// </summary>
        public string Database
        {
            get { return data_base; }
            set { data_base = value; }
        }

        private string user_id = "";
        /// <summary>
        /// Usuário do banco de dados.
        /// </summary>
        public string User
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private string password = "";
        /// <summary>
        /// Usuário do banco de dados.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

    }
}
