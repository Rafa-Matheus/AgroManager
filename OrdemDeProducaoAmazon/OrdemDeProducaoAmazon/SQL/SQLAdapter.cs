#region Diretivas
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace OrdemDeProducaoAmazon
{
    public class SQLAdapter
    {

        #region Eventos Internos
        public event EventHandler<SQAdapterExceptionEventArgs> ThrownAdapterException;

        private EventHandler<SQAdapterExceptionEventArgs> handler;

        public class SQAdapterExceptionEventArgs : EventArgs
        {
            public Exception Exception { get; set; }
        }
        #endregion

        #region Construtor
        private SQLiteConnection conn;

        /// <summary>
        /// Inicializa o adaptador.
        /// </summary>
        public SQLAdapter(string entropy_code)
        {
            try
            {
                Setup();

                entropy = System.Text.Encoding.Unicode.GetBytes(entropy_code);

                insert_in_table_actions = new List<SQLTableActionHandler>();
                delete_from_actions = new List<SQLTableActionHandler>();
                update_table_actions = new List<SQLTableActionHandler>();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("SQLite"))
                    if (MessageBox.Show("É necessário instalar a última versão do SQLite em seu computador. Deseja abrir o site para baixar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        Process.Start("http://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki");

                Application.Exit();
            }
        }
        #endregion

        #region Métodos Internos
        private void Setup()
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
                conn = new SQLiteConnection("Data Source=" + source + ";Password=" + password + ";");
            }
            catch (Exception ex) { FlagException(ex); }
        }

        private void FlagException(Exception exception)
        {
            handler = ThrownAdapterException;
            SQAdapterExceptionEventArgs args = new SQAdapterExceptionEventArgs();
            args.Exception = exception;
            if (handler != null) handler(this, args);

            //Refazer conexão
            Setup();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Abre a conexão.
        /// </summary>
        public bool Open()
        {
            if (!opened)
                try
                {
                    conn.Open();
                    opened = true;

                    return true;
                }
                catch (Exception ex) { FlagException(ex); }

            return false;
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public void Close()
        {
            if (opened)
                try
                {
                    conn.Close();
                    opened = false;
                }
                catch (Exception ex) { FlagException(ex); }
        }

        /// <summary>
        /// Cria uma tabela.
        /// </summary>
        /// <param name="name">Nome da tabela.</param>
        /// <param name="values">Valoress</param>
        public void CreateTable(string user, string name, string values)
        {
            //try
            //{
            //    if (!Open()) return;

            //    string query = string.Format("CREATE TABLE IF NOT EXISTS {0}({1});", name, values);
            //    SQLiteCommand command = new SQLiteCommand(query, conn);
            //    command.ExecuteNonQuery();

            //    Close();
            //}
            //catch (Exception ex) { FlagException(ex); }

            Query(user, "CREATE TABLE IF NOT EXISTS {0}({1});", "Create Table", name, values);
        }

        /// <summary>
        /// Apaga uma tabela.
        /// </summary>
        /// <param name="name">Nome da tabela</param>
        public void DropTable(string user, string name)
        {
            //try
            //{
            //    if (!Open()) return;

            //    string query = string.Format("DROP TABLE {0};", name);
            //    SQLiteCommand command = new SQLiteCommand(query, conn);
            //    command.ExecuteNonQuery();

            //    Close();
            //}
            //catch (Exception ex) { FlagException(ex); }

            Query(user, "DROP TABLE IF EXISTS {0};", "Drop Table", name);
        }

        /// <summary>
        /// Insere itens em campos específicos em uma tabela.
        /// </summary>
        /// <param name="table">Tabela</param>
        /// <param name="fields">Campos</param>
        /// <param name="values">Valores</param>
        public void InsertInTable(string user, string table, string fields, string values)
        {
            int id = -1;

            Query(user, "INSERT INTO {0}({1}) VALUES({2});", "Insert Into Table", table, fields, values);

            try
            {
                //if (!Open()) return;

                //string query = string.Format("INSERT INTO {0}({1}) VALUES({2});", table, fields, values);
                //SQLiteCommand command = new SQLiteCommand(query, conn);
                //command.ExecuteNonQuery();

                //Close();

                //Código de identificação
                DataTable data = SelectField(user, "id", table);
                int count = data.Rows.Count;
                id = int.Parse(data.Rows[count - 1][0].ToString());
            }
            catch (Exception ex) { FlagException(ex); }

            //BackgroundTask task = new BackgroundTask();
            //task.DoWork += delegate
            //{
            //Realizar ação
            for (int i = 0; i < insert_in_table_actions.Count; i++)
            {
                string get_table = insert_in_table_actions[i].Table;
                if (get_table.Equals(table) || get_table.Equals("*"))
                    insert_in_table_actions[i].Action(this, new SQLTableEventArgs() { Table = table, Id = id });
            }
            //};
            //task.Start();
        }

        private List<SQLTableActionHandler> insert_in_table_actions;
        public void RegisterEventOnInsertInTable(string table, EventHandler<SQLTableEventArgs> action)
        {
            insert_in_table_actions.Add(new SQLTableActionHandler(table, action));
        }

        /// <summary>
        /// Apaga itens com valores específicos em uma tabela.
        /// </summary>
        /// <param name="table">Tabela</param>
        /// <param name="where">Onde</param>
        public void DeleteFrom(string user, string table, string where)
        {
            int id = -1;

            //try
            //{
            //Código de identificação
            DataTable data = SelectFieldWhere(user, "id", table, where);
            if (data.Rows.Count > 0)
            {
                id = int.Parse(data.Rows[0][0].ToString());

                //if (!Open()) return;

                //string query = string.Format("DELETE FROM {0} WHERE {1};", table, where);
                //SQLiteCommand command = new SQLiteCommand(query, conn);
                //command.ExecuteNonQuery();

                //Close();

                Query(user, "DELETE FROM {0} WHERE {1};", "Delete From Table", table, where);
            }
            //}
            //catch (Exception ex) { FlagException(ex); }

            //BackgroundTask task = new BackgroundTask();
            //task.DoWork += delegate
            //{
            //Realizar ação
            for (int i = 0; i < delete_from_actions.Count; i++)
            {
                string get_table = delete_from_actions[i].Table;
                if (get_table.Equals(table) || get_table.Equals("*"))
                    delete_from_actions[i].Action(this, new SQLTableEventArgs() { Table = table, Id = id });
            }
            //};
            //task.Start();
        }

        private List<SQLTableActionHandler> delete_from_actions;
        public void RegisterEventOnDeleteFrom(string table, EventHandler<SQLTableEventArgs> action)
        {
            delete_from_actions.Add(new SQLTableActionHandler(table, action));
        }

        /// <summary>
        /// Atualiza itens com valores específicos em uma tabela.
        /// </summary>
        /// <param name="table">Tabela</param>
        /// <param name="set">Novo valor</param>
        /// <param name="where">Onde</param>
        public void UpdateTable(string user, string table, string set, string where)
        {
            int id = -1;

            //try
            //{
            //Código de identificação
            DataTable data = SelectFieldWhere(user, "id", table, where);
            if (data.Rows.Count > 0)
            {
                id = int.Parse(data.Rows[0][0].ToString());

                //if (!Open()) return;

                //string query = string.Format("UPDATE {0} SET {1} WHERE {2};", table, set, where);
                //SQLiteCommand command = new SQLiteCommand(query, conn);
                //command.ExecuteNonQuery();

                //Close();

                Query(user, "UPDATE {0} SET {1} WHERE {2};", "Update Table", table, set, where);
            }
            //}
            //catch (Exception ex) { FlagException(ex); }

            //BackgroundTask task = new BackgroundTask();
            //task.DoWork += delegate
            //{
            //Realizar ação
            for (int i = 0; i < update_table_actions.Count; i++)
            {
                string get_table = update_table_actions[i].Table;
                if (get_table.Equals(table) || get_table.Equals("*"))
                    update_table_actions[i].Action(this, new SQLTableEventArgs() { Table = table, Id = id });
            }
            //};
            //task.Start();
        }

        private List<SQLTableActionHandler> update_table_actions;
        public void RegisterEventOnUpdateTable(string table, EventHandler<SQLTableEventArgs> action)
        {
            update_table_actions.Add(new SQLTableActionHandler(table, action));
        }

        /// <summary>
        /// Limpa todos os dados em uma tabela.
        /// </summary>
        /// <param name="table">Tabela</param>
        public void Clear(string user, string table)
        {
            //try
            //{
            //    if (!Open()) return;

            //    string query = string.Format("DELETE FROM {0}", table);
            //    SQLiteCommand command = new SQLiteCommand(query, conn);
            //    command.ExecuteNonQuery();

            //    Close();
            //}
            //catch (Exception ex) { FlagException(ex); }

            Query(user, "DELETE FROM {0}", "Clear", table);
        }

        /// <summary>
        /// Seleciona campos específicos em uma tabela.
        /// </summary>
        /// <param name="field">Campo</param>
        /// <param name="table">Tabela</param>
        /// <returns>Dados adquiridos.</returns>
        public DataTable SelectField(string user, string field, string table)
        {
            //try
            //{
            //    if (!Open()) return new DataTable();

            //    string query = string.Format("SELECT {0} FROM {1};", field, table);
            //    SQLiteCommand command = new SQLiteCommand(query, conn);
            //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            //    DataSet result = new DataSet();

            //    adapter.Fill(result);

            //    Close();

            //    return result.Tables[0];
            //}
            //catch (Exception ex) { FlagException(ex); }

            //return new DataTable();

            return GetDataTable(user, "SELECT {0} FROM {1};", "Select Field", field, table);
        }

        /// <summary>
        /// Seleciona campos com valores específicos em uma tabela.
        /// </summary>
        /// <param name="field">Campo</param>
        /// <param name="table">Tabela</param>
        /// <param name="where">Onde</param>
        /// <returns>Dados adquiridos.</returns>
        public DataTable SelectFieldWhere(string user, string field, string table, string where)
        {
            //try
            //{
            //    if (!Open()) return new DataTable();

            //    string query = string.Format("SELECT {0} FROM {1} WHERE {2};", field, table, where);
            //    SQLiteCommand command = new SQLiteCommand(query, conn);
            //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            //    DataSet result = new DataSet();

            //    adapter.Fill(result);

            //    Close();

            //    return result.Tables[0];
            //}
            //catch (Exception ex) { FlagException(ex); }

            //return new DataTable();

            return GetDataTable(user, "SELECT {0} FROM {1} WHERE {2};", "Select Field Where", field, table, where);
        }

        /// <summary>
        /// Seleciona todos os dados em uma tabela.
        /// </summary>
        /// <param name="table">Tabela</param>
        /// <returns>Dados adquiridos.</returns>
        public DataTable SelectAll(string user, string table)
        {
            //try
            //{
            //    if (!Open()) return new DataTable();

            //    string query = string.Format("SELECT * FROM {0};", table);
            //    SQLiteCommand command = new SQLiteCommand(query, conn);
            //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

            //    DataSet result = new DataSet();

            //    adapter.Fill(result);

            //    Close();

            //    return result.Tables[0];
            //}
            //catch (Exception ex) { FlagException(ex); }

            //return new DataTable();

            return GetDataTable(user, "SELECT * FROM {0};", "Select All", table);
        }

        //public string GetFirstString(string field, string table, string where)
        //{
        //    try
        //    {
        //        if (!Open()) return "";

        //        string query = string.Format("SELECT {0} FROM {1} WHERE {2};", field, table, where);
        //        SQLiteCommand command = new SQLiteCommand(query, conn);
        //        SQLiteDataReader reader = command.ExecuteReader();

        //        string result = "";
        //        while (reader.Read())
        //            result = reader.GetString(0);

        //        Close();

        //        return result;
        //    }
        //    catch (Exception ex) { FlagException(ex); }

        //    return "";
        //}

        /// <summary>
        /// Executa um comando em SQL.
        /// </summary>
        /// <param name="query"></param>
        public void Query(string user, string query, string description, params string[] args)
        {
            try
            {
                if (!Open()) return;

                string formatted_query = string.Format(query, args);

                InsertIntoLog(user, description, args);

                SQLiteCommand command = new SQLiteCommand(formatted_query, conn);
                command.ExecuteNonQuery();

                Close();
            }
            catch (Exception ex) { FlagException(ex); }
        }

        public DataSet GetDataSet(string query, params string[] args)
        {
            try
            {
                if (!Open()) return new DataSet();

                string formatted_query = string.Format(query, args);

                

                SQLiteCommand command = new SQLiteCommand(formatted_query, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                DataSet result = new DataSet();

                adapter.Fill(result);

                Close();

                return result;
            }
            catch (Exception ex) { FlagException(ex); }

            return new DataSet();
        }

        public DataTable GetDataTable(string user, string query, string description, params string[] args)
        {
            //InsertToLog(user, description, args);

            DataSet result = GetDataSet(query, args);
            if (result.Tables.Count > 0)
                return result.Tables[0];
            else
                return new DataTable();
        }

        /// <summary>
        /// Insere uma senha.
        /// </summary>
        /// <param name="password">Senha</param>
        public void ChangePassword(string password)
        {
            try
            {
                if (!Open()) return;

                this.password = password;

                conn.ChangePassword(password);

                Save();

                Close();
            }
            catch (Exception ex) { FlagException(ex); }
        }

        /// <summary>
        /// Remove a senha.
        /// </summary>
        public void RemovePassword()
        {
            ChangePassword(String.Empty);
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

        private string password = "";
        /// <summary>
        /// Senha do banco de dados.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool opened = false;
        /// <summary>
        /// Indica se a conexão está aberta.
        /// </summary>
        public bool IsOpened
        {
            get { return opened; }
            set { opened = value; }
        }
        #endregion

        #region Configuração
        //Carrega a conexão
        private void Load()
        {
            if (File.Exists(@".\config"))
            {
                string password = "";

                File.Decrypt(@".\config");

                string data = File.ReadAllText(@".\config");

                SecureString ss = DecryptString(data);

                using (StringReader sr = new StringReader(ToInsecureString(ss)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Linha em branco
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] args = line.Split('=');

                        switch (args[0])
                        {
                            case "password":
                                password = args[1];
                                break;
                        }
                    }
                }

                Password = password;
            }
            else
            {
                SetPasswordForm sp = new SetPasswordForm(this, false);
                if (sp.ShowDialog() == DialogResult.OK)
                {
                    Password = sp.Password;
                    Save();
                }
            }
        }

        //Salva a conexão
        private void Save()
        {
            string data = string.Format("password={0}", Password);

            SecureString ss = ToSecureString(data);

            File.Delete(@".\config");
            File.WriteAllText(@".\config", EncryptString(ss));
            File.SetAttributes(@".\config", FileAttributes.Hidden);
        }
        #endregion

        #region Registrador
        private void InsertIntoLog(string user, string description, params string[] args)
        {
            //Log.Info(string.Format("{0}: '{1}' do '{2}' with '{3}' arguments", DateTime.Now.ToLocalTime(), user, description, string.Join(", ", args)));
        }
        #endregion

        #region Segurança
        private byte[] entropy;

        private string EncryptString(System.Security.SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedData);
        }

        private SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch { return new SecureString(); }
        }

        private SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        private string ToInsecureString(SecureString input)
        {
            string result = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                result = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }

            return result;
        }
        #endregion

    }
}
