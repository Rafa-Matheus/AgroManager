#region Diretivas
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DHS.SQL
{
    public abstract class SQLAdapter
    {

        #region Eventos Internos
        public event EventHandler<SQAdapterExceptionEventArgs> ThrownAdapterException;

        public class SQAdapterExceptionEventArgs : EventArgs
        {
            public Exception Exception { get; set; }
            public string Command { get; set; }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Inicializa o adaptador.
        /// </summary>
        public SQLAdapter(string entropy_code)
        {
            entropy = Encoding.Unicode.GetBytes(entropy_code);

            insert_in_table_actions = new List<SQLTableActionHandler>();
            delete_from_actions = new List<SQLTableActionHandler>();
            update_table_actions = new List<SQLTableActionHandler>();
        }
        #endregion

        #region Métodos Internos
        public void Setup()
        {
            try
            {
                OnSetup();
            }
            catch (Exception ex) { FlagException(ex, "Setup"); }
        }

        public abstract void MissingSetupParams();

        protected void FlagException(Exception exception, string command)
        {
            if (ThrownAdapterException != null)
                ThrownAdapterException(this, new SQAdapterExceptionEventArgs() { Exception = exception, Command = command });
        }

        public abstract void OnSetup();

        public abstract void CreateConnection();

        public abstract string OnFormatField(string value);
        #endregion

        #region Métodos
        public abstract string GetIdSyntax();

        public abstract string GetTableNamesSyntax();

        /// <summary>
        /// Abre a conexão.
        /// </summary>
        public bool Open()
        {
            if (!opened)
            {
                try
                {
                    OnConnectionOpen();

                    opened = true;

                    return true;
                }
                catch (Exception ex) { FlagException(ex, "Open Connection"); }

                return false;
            }

            return true;
        }

        public abstract void OnConnectionOpen();

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public void Close()
        {
            if (opened)
                try
                {
                    OnConnectionClose();

                    opened = false;
                }
                catch (Exception ex) { FlagException(ex, "Close Connection"); }
        }

        public abstract void OnConnectionClose();

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="name">Nome do usuário</param>
        /// <param name="password">Senha</param>
        public void CreateUser(string user, string name, string password)
        {
            Query(user, GetCreateUserSyntax(), "Create User", name, password);
        }

        public abstract string GetCreateUserSyntax();

        /// <summary>
        /// Apaga um usuário.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="name">Nome do usuário</param>
        public void DropUser(string user, string name)
        {
            Query(user, GetDropUserSyntax(), "Drop User", name);
        }

        public abstract string GetDropUserSyntax();

        /// <summary>
        /// Criar um novo banco de dados.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="name">Nome</param>
        /// <param name="owner">Quem pertence</param>
        public void CreateDatabase(string user, string name, string owner)
        {
            Query(user, GetCreateDatabaseSyntax(), "Create Database", name, owner);
        }

        public abstract string GetCreateDatabaseSyntax();

        /// <summary>
        /// Apaga um banco de dados.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="name">Nome</param>
        public void DropDatabase(string user, string name)
        {
            Query(user, GetDropDatabaseSyntax(), "Drop Database", name);
        }

        public abstract string GetDropDatabaseSyntax();

        /// <summary>
        /// Cria uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="name">Nome da tabela</param>
        /// <param name="values">Valores</param>
        public void CreateTable(string user, string name, string values)
        {
            Query(user, GetCreateTableSyntax(), "Create Table", name, values);
        }

        public abstract string GetCreateTableSyntax();

        /// <summary>
        /// Apaga uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="name">Nome da tabela</param>
        public void DropTable(string user, string name)
        {
            Query(user, GetDropTableSyntax(), "Drop Table", name);
        }

        public abstract string GetDropTableSyntax();

        /// <summary>
        /// Insere itens em campos específicos em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="table">Tabela</param>
        /// <param name="fields">Campos</param>
        /// <param name="values">Valores</param>
        public void InsertInTable(string user, string table, string fields, string values)
        {
            int id = -1;

            Query(user, GetInsertInTableSyntax(), "Insert Into Table", table, fields, values);

            try
            {
                //Código de identificação
                DataTable data = SelectField(user, OnFormatField("id"), table);
                int count = data.Rows.Count;

                if (count > 0)
                    id = int.Parse(data.Rows[count - 1][0].ToString());

                //Realizar ação
                for (int i = 0; i < insert_in_table_actions.Count; i++)
                {
                    string get_table = insert_in_table_actions[i].Table;
                    if (get_table.Equals(table) || get_table.Equals("*"))
                        insert_in_table_actions[i].Action(this, new SQLTableEventArgs() { Table = table, Id = id });
                }
            }
            catch (Exception ex) { FlagException(ex, "Insert Into Table"); }
        }

        public abstract string GetInsertInTableSyntax();

        private List<SQLTableActionHandler> insert_in_table_actions;
        public void RegisterEventOnInsertInTable(string table, EventHandler<SQLTableEventArgs> action)
        {
            insert_in_table_actions.Add(new SQLTableActionHandler(table, action));
        }

        /// <summary>
        /// Apaga itens com valores específicos em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="table">Tabela</param>
        /// <param name="where">Onde</param>
        public void DeleteFrom(string user, string table, string where)
        {
            int id = -1;

            try
            {
                //Código de identificação
                DataTable data = SelectFieldWhere(user, OnFormatField("id"), table, where);
                if (data.Rows.Count > 0)
                {
                    id = int.Parse(data.Rows[0][0].ToString());

                    Query(user, GetDeleteFromWhereSyntax(), "Delete From Table", table, where);
                }

                //Realizar ação
                for (int i = 0; i < delete_from_actions.Count; i++)
                {
                    string get_table = delete_from_actions[i].Table;
                    if (get_table.Equals(table) || get_table.Equals("*"))
                        delete_from_actions[i].Action(this, new SQLTableEventArgs() { Table = table, Id = id });
                }
            }
            catch (Exception ex) { FlagException(ex, "Delete From Table"); }
        }

        public abstract string GetDeleteFromWhereSyntax();

        private List<SQLTableActionHandler> delete_from_actions;
        public void RegisterEventOnDeleteFrom(string table, EventHandler<SQLTableEventArgs> action)
        {
            delete_from_actions.Add(new SQLTableActionHandler(table, action));
        }

        /// <summary>
        /// Atualiza itens com valores específicos em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="table">Tabela</param>
        /// <param name="set">Novo valor</param>
        /// <param name="where">Onde</param>
        public void UpdateTable(string user, string table, string set, string where)
        {
            int id = -1;

            try
            {
                //Código de identificação
                DataTable data = SelectFieldWhere(user, OnFormatField("id"), table, where);
                if (data.Rows.Count > 0)
                {
                    id = int.Parse(data.Rows[0][0].ToString());

                    Query(user, GetUpdateWhereSyntax(), "Update Table", table, set, where);
                }

                //Realizar ação
                for (int i = 0; i < update_table_actions.Count; i++)
                {
                    string get_table = update_table_actions[i].Table;
                    if (get_table.Equals(table) || get_table.Equals("*"))
                        update_table_actions[i].Action(this, new SQLTableEventArgs() { Table = table, Id = id });
                }
            }
            catch (Exception ex) { FlagException(ex, "Update Table"); }
        }

        public abstract string GetUpdateWhereSyntax();

        private List<SQLTableActionHandler> update_table_actions;
        public void RegisterEventOnUpdateTable(string table, EventHandler<SQLTableEventArgs> action)
        {
            update_table_actions.Add(new SQLTableActionHandler(table, action));
        }

        /// <summary>
        /// Limpa todos os dados em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="table">Tabela</param>
        public void Clear(string user, string table)
        {
            Query(user, GetDeleteFromSyntax(), "Clear", table);
        }

        public abstract string GetDeleteFromSyntax();

        /// <summary>
        /// Seleciona campos específicos em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="field">Campo</param>
        /// <param name="table">Tabela</param>
        /// <returns>Dados adquiridos.</returns>
        public DataTable SelectField(string user, string field, string table)
        {
            return GetDataTable(user, GetSelectSyntax(), "Select Field", field, table);
        }

        public abstract string GetSelectSyntax();

        /// <summary>
        /// Seleciona campos com valores específicos em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="field">Campo</param>
        /// <param name="table">Tabela</param>
        /// <param name="where">Onde</param>
        /// <returns>Dados adquiridos.</returns>
        public DataTable SelectFieldWhere(string user, string field, string table, string where)
        {
            return GetDataTable(user, GetSelectWhereSyntax(), "Select Field Where", field, table, where);
        }

        public abstract string GetSelectWhereSyntax();

        /// <summary>
        /// Seleciona todos os dados em uma tabela.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="table">Tabela</param>
        /// <returns>Dados adquiridos.</returns>
        public DataTable SelectAll(string user, string table)
        {
            return GetDataTable(user, GetSelectAllSyntax(), "Select All", table);
        }

        public abstract string GetSelectAllSyntax();

        /// <summary>
        /// Executa um comando em SQL.
        /// </summary>
        /// <param name="user">Quem está fazendo a ação</param>
        /// <param name="query"></param>
        public void Query(string user, string query, string description, params string[] args)
        {
            if (TestMode || ShowCommands)
            {
                MessageBox.Show(string.Format(query, args));

                if (TestMode && !ShowCommands)
                    return;
            }

            string formatted_query = string.Format(query, args);

            try
            {
                if (!Open()) return;

                InsertIntoLog(user, description, args);

                OnDoCommand(formatted_query);

                Close();
            }
            catch (Exception ex) { FlagException(ex, formatted_query); }
        }

        public abstract void OnDoCommand(string query);

        public DataSet GetDataSet(string query, params string[] args)
        {
            if (TestMode || ShowCommands)
                MessageBox.Show(string.Format(query, args));

            string formatted_query = string.Format(query, args);

            try
            {
                if (!Open()) return new DataSet();

                DataSet data_set = OnGetDataSet(formatted_query);

                Close();

                return data_set;
            }
            catch (Exception ex) { FlagException(ex, formatted_query); }

            return new DataSet();
        }

        public abstract DataSet OnGetDataSet(string query);

        public DataTable GetDataTable(string user, string query, string description, params string[] args)
        {
            InsertIntoLog(user, description, args);

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
        public void ChangePassword(string password, string user = "")
        {
            try
            {
                if (!Open()) return;

                OnChangePassword(user, password);

                Save();

                Close();
            }
            catch (Exception ex) { FlagException(ex, "Change Password"); }
        }

        public abstract void OnChangePassword(string user, string password);

        /// <summary>
        /// Remove a senha.
        /// </summary>
        public void RemovePassword(string user = "")
        {
            ChangePassword(String.Empty, user);
        }
        #endregion

        #region Propriedades
        private bool opened = false;
        /// <summary>
        /// Indica se a conexão está aberta.
        /// </summary>
        public bool IsOpened
        {
            get { return opened; }
            set { opened = value; }
        }

        public bool TestMode { get; set; }

        public bool ShowCommands { get; set; }
        #endregion

        #region Configuração
        //Carrega a conexão
        protected void Load()
        {
            if (File.Exists(@".\config"))
            {
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

                        //Definir proprieadade
                        SetProperty(args[0], args[1]);
                    }
                }
            }
            else
                MissingSetupParams();
        }

        public abstract void SetProperty(string name, string value);

        //Salva a conexão
        public void Save()
        {
            SecureString ss = ToSecureString(OnGetProperties());

            File.Delete(@".\config");
            File.WriteAllText(@".\config", EncryptString(ss));
            File.SetAttributes(@".\config", FileAttributes.Hidden);
        }

        public abstract string OnGetProperties();
        #endregion

        #region Registrador
        private void InsertIntoLog(string user, string description, params string[] args)
        {
            OnLog(string.Format("{0}: '{1}' do '{2}' with '{3}' arguments", DateTime.Now.ToLocalTime(), user, description, string.Join(", ", args)));
        }

        public abstract void OnLog(string message);
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
