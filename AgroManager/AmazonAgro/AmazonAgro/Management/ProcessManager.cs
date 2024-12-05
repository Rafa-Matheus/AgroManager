using DHS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    public class ProcessManager
    {

        public static void Initialize(SQLAdapter sql)
        {
            sql.CreateTable("%system%", "processes", string.Format("{0} INTEGER", sql.OnFormatField("index")));
        }

        public static void SetCurrentProcessIndex(int index, SQLAdapter sql)
        {
            sql.InsertInTable("%system%", "processes", sql.OnFormatField("index"), index.ToString());
        }

        public static int GetCurrentProcessIndex(SQLAdapter sql)
        {
            DataTable data = sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "processes"), "");

            //Selecionar último item
            if (data.Rows.Count > 0)
            {
                int result;
                if (int.TryParse(data.Rows[data.Rows.Count - 1][0].ToString(), out result))
                    return result;
            }

            return -1;
        }

        public static void Clear(SQLAdapter sql)
        {
            sql.Clear("%system%", "processes");
        }

    }
}
