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
    public class ProcessWatcher
    {

        public event Action ProcessChanged;

        private Timer t;
        private SQLAdapter sql;
        private int last_count;
        public ProcessWatcher(SQLAdapter sql)
        {
            this.sql = sql;

            t = new Timer();
            t.Interval = 2000;
            t.Tick += delegate
            {
                int count = GetProcessesCount(sql);

                if (count != last_count)
                {
                    last_count = count;

                    if (ProcessChanged != null)
                        ProcessChanged();
                }
            };
        }

        public void Start()
        {
            last_count = GetProcessesCount(sql);

            t.Start();
        }

        public void Stop()
        {
            t.Stop();
        }

        private int GetProcessesCount(SQLAdapter sql)
        {
            return sql.GetDataTable("", string.Format(sql.GetSelectAllSyntax(), "processes"), "").Rows.Count;
        }

    }
}
