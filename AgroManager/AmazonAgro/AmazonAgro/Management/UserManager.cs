using DHS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public static class UserManager
    {

        public static void Initialize(SQLAdapter sql)
        {
            SQLStruct structure = SQLXmlHelper.ReadFields(@".\tables\users.xml");
            SQLHelper.ConvertToTable("%system%", structure, sql);
        }

        public static string CurrentUser { get; set; }

        public static int CurrentUserId { get; set; }

        public static bool IsAdmin { get; set; }

        public static int Login(string user, string password, SQLAdapter sql)
        {
            DataTable data = sql.GetDataTable("%system%", string.Format(sql.GetSelectSyntax(), string.Format("{0}, {1}, {2}, {3}", sql.OnFormatField("id"), sql.OnFormatField("user"), sql.OnFormatField("password"), sql.OnFormatField("is_logged")), "users"), "");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int id = int.Parse(data.Rows[i][0].ToString());
                string c_user = data.Rows[i][1].ToString();
                string c_password = data.Rows[i][2].ToString();

                bool is_logged = false;
                try
                {
                    is_logged = bool.Parse(data.Rows[i][3].ToString());
                }
                catch { }

                //Já está logado
                //if (is_logged)
                //    return 2;

                //O login foi feito com sucesso
                if (user.Equals(c_user) && password.Equals(c_password))
                {
                    CurrentUser = user;

                    CurrentUserId = id;

                    IsAdmin = CheckAdmin(id, sql);

                    //Definir como logado
                    sql.UpdateTable("%system%", "users", string.Format("{0} = 'true'", sql.OnFormatField("is_logged")), string.Format("{0} = {1}", sql.OnFormatField("id"), id));

                    return 1;
                }
            }

            //O login não foi feito
            return 0;
        }

        public static void Logout(SQLAdapter sql)
        {
            //Definir como não logado
            sql.UpdateTable("%system%", "users", string.Format("{0} = 'false'", sql.OnFormatField("is_logged")), string.Format("{0} = {1}", sql.OnFormatField("id"), CurrentUserId));
        }

        public static bool CheckAdmin(int id, SQLAdapter sql)
        {
            return CheckPermission(id, 3, sql);
        }

        public static bool CheckPermission(int id, int number, SQLAdapter sql)
        {
            DataTable data = sql.GetDataTable("%system%", string.Format(sql.GetSelectWhereSyntax(), sql.OnFormatField("permissions"), "users", string.Format("{0} = {1}", sql.OnFormatField("id"), id)), "");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int[] permissions = data.Rows[i][0].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToArray();

                //O usuário tem a permissão
                if (permissions[number] == 1)
                    return true;
            }

            //O usuário não tem a permissão
            return false;
        }

        //Verificar se a senha corresponde
        public static bool CheckPassword(string password, SQLAdapter sql)
        {
            DataTable data = sql.GetDataTable("%system%", string.Format(sql.GetSelectWhereSyntax(), sql.OnFormatField("password"), "users", string.Format("{0} = {1}", sql.OnFormatField("id"), CurrentUserId)), "");
            if (data.Rows.Count > 0)
                return password.Equals(data.Rows[0][0].ToString());

            return false;
        }

    }
}
