using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.SQL
{
    public abstract class SQLViewsHelperBase
    {

        public SQLAdapter Adapter { get; set; }

        public SQLStruct Structure { get; set; }

        public abstract void OnStart();

        public abstract void OnAddView(SQLStruct structure, SQLEnumItem[] items);

        public void AddViews(SQLStruct structure, SQLAdapter sql)
        {
            Adapter = sql;
            Structure = structure;

            OnStart();

            for (int i = 0; i < structure.Fields.Count; i++)
            {
                SQLStruct field = structure.Fields[i];

                //Não é visível
                if (field.ContainsProperty("visible"))
                    if (!bool.Parse(field.GetPropertyValue("visible")))
                        continue;

                OnAddView(field, GetEnumItems("", field, sql));
            }

            OnEnd();
        }

        public abstract void OnEnd();

        public abstract void ClearViews();

        public void Insert()
        {
            if (IsUpdating) return;

            SQLParams parameters = GetInsertQuery();

            Adapter.InsertInTable("", (string)parameters.Values[0], (string)parameters.Values[1], (string)parameters.Values[2]);

            ClearViews();
        }

        public SQLParams GetInsertQuery()
        {
            SQLField[] columns = OnGetViewValues();

            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            for (int i = 0; i < columns.Length; i++)
            {
                SQLField column = columns[i];

                if (column.Type.Equals("sep"))
                    continue;

                fields.Add(Adapter.OnFormatField(column.Name));
                values.Add(OnFormatValue(column.Type, column.Value));
            }

            string sfields = string.Join(", ", fields.ToArray());
            string svalues = string.Join(", ", values.ToArray());

            return new SQLParams(string.Format(Adapter.GetInsertInTableSyntax(), Structure.Name, sfields, svalues), Structure.Name, sfields, svalues);
        }

        //Atualizar item
        public void StartUpdate(int id)
        {
            if (IsUpdating) return;

            SQLParams parameters = GetStartUpdateQuery(id);

            DataTable table = Adapter.GetDataTable("", parameters.Query, "");
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                    OnSetViewValue(new SQLField(((List<string>)parameters.Values[0])[i], Structure.Fields.First(s => s.Name.Equals(((List<string>)parameters.Values[0])[i])).Type, table.Rows[0][i].ToString()));

                UpdateId = id;

                IsUpdating = true;
            }
        }

        public SQLParams GetStartUpdateQuery(int id)
        {
            List<string> columns = new List<string>();
            for (int i = 0; i < Structure.Fields.Count; i++)
            {
                SQLStruct column = Structure.Fields[i];

                if (column.Type.Equals("sep"))
                    continue;

                if (column.ContainsProperty("visible"))
                    if (!bool.Parse(column.GetPropertyValue("visible")))
                        continue;

                columns.Add(Structure.Fields[i].Name);
            }

            return new SQLParams(string.Format(Adapter.GetSelectWhereSyntax(), string.Join(", ", columns.Select(c => Adapter.OnFormatField(c)).ToArray()), Structure.Name, string.Format("{0} = {1}", Adapter.OnFormatField("id"), id)), columns);
        }

        public bool IsUpdating { get; set; }

        public int UpdateId { get; set; }

        public void EndUpdate()
        {
            if (!IsUpdating) return;

            SQLParams parameters = GetEndUpdateParams();

            Adapter.UpdateTable("", (string)parameters.Values[0], (string)parameters.Values[1], (string)parameters.Values[2]);

            IsUpdating = false;

            ClearViews();
        }

        public void CancelUpdate()
        {
            if (!IsUpdating) return;

            IsUpdating = false;

            ClearViews();
        }

        public SQLParams GetEndUpdateParams()
        {
            SQLField[] columns = OnGetViewValues();

            //Remover separadores
            columns = columns.Where(c => !c.Type.Equals("sep")).ToArray();

            string set = string.Join(", ", columns.Select(c => string.Format("{0} = {1}", Adapter.OnFormatField(c.Name), OnFormatValue(c.Type, c.Value))).ToArray());
            string where = string.Format("{0} = {1}", Adapter.OnFormatField("id"), UpdateId);

            return new SQLParams(string.Format(Adapter.GetUpdateWhereSyntax(), Structure.Name, set, where), Structure.Name, set, where);
        }

        public abstract void OnSetViewValue(SQLField field);

        public abstract SQLField[] OnGetViewValues();

        private string OnFormatValue(string type, string value)
        {
            switch (type)
            {
                case "enum":
                case "text":
                case "ptext":
                case "mtext":
                case "mask":
                case "chitem":
                case "chitems":
                case "date":
                case "decimal":
                    return string.Format("'{0}'", value);
            }

            return value;
        }

        public void DeleteFrom(int id)
        {
            Adapter.DeleteFrom("", Structure.Name, string.Format(string.Format("{0} = {1}", Adapter.OnFormatField("id"), id)));
        }

        #region Adquirir valores da tabela
        private static DataTable GetTableValues(string user, string get_from, SQLAdapter sql)
        {
            //Valores de uma tabela
            string[] args = get_from.Split(':');

            string arg_table = args[0];
            string arg_column = args[1];

            return sql.SelectField(user, string.Format("{0}, {1}", sql.OnFormatField("id"), sql.OnFormatField(arg_column)), arg_table);
        }
        #endregion

        private static SQLEnumItem[] GetEnumItems(string user, SQLStruct structure, SQLAdapter sql)
        {
            bool is_separator = structure.Type.Equals("sep");

            List<SQLEnumItem> enum_items = new List<SQLEnumItem>();

            //Separador
            if (!is_separator)
            {
                //Proprieades
                if (structure.Properties.Length > 0)
                    for (int j = 0; j < structure.Properties.Length; j++)
                    {
                        SQLProperty p = structure.Properties[j];

                        switch (p.Name)
                        {
                            case "get_from":
                                string get_from = structure.GetPropertyValue("get_from");

                                //Valores de uma tabela
                                if (get_from.Contains(":"))
                                {
                                    DataTable data = GetTableValues(user, get_from, sql);

                                    for (int k = 0; k < data.Rows.Count; k++)
                                    {
                                        string id = data.Rows[k][0].ToString();
                                        string data_item = data.Rows[k][1].ToString();

                                        enum_items.Add(new SQLEnumItem(data_item, id));
                                    }
                                }
                                else
                                    switch (get_from)
                                    {
                                        //Nomes de todas as tabelas
                                        //case "%table_names%":
                                        //    //for (int k = 0; k < TableManager.Tables.Count; k++)
                                        //    //{
                                        //    //    string table_name = TableManager.Tables[k].Name;
                                        //    //    string table_title = TableManager.Tables[k].Title;

                                        //    //    enum_items.Add(new SQLEnumItem(table_title, table_name));
                                        //    //}
                                        //    break;
                                        //Dias da semana
                                        case "days":
                                            string[] days = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
                                            for (int k = 0; k < 7; k++)
                                                enum_items.Add(new SQLEnumItem(days[k], k.ToString()));
                                            break;
                                    }
                                break;
                        }
                    }

                //Outros sub-campos
                if (structure.Fields != null)
                    for (int i = 0; i < structure.Fields.Count; i++)
                    {
                        SQLStruct item = structure.Fields[i];
                        if (item.Type.Equals("item"))
                            enum_items.Add(new SQLEnumItem(item.Title, item.GetPropertyValue("value")));
                    }
            }

            return enum_items.ToArray();
        }

    }
}
