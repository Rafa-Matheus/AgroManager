using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemDeProducaoAmazon
{
    public class SQLTableActionHandler
    {

        public SQLTableActionHandler(string table, EventHandler<SQLTableEventArgs> action)
        {
            Table = table;
            Action = action;
        }

        public string Table { get; set; }

        public EventHandler<SQLTableEventArgs> Action { get; set; }

    }
}
