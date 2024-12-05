using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class ReportItem
    {

        public ReportItem(string title)
        {
            Title = title;
            SubItems = new List<ReportItem>();
        }

        public string Title { get; set; }

        public List<ReportItem> SubItems { get; set; }

        public static ReportItem GenerateFromListView(ListView list, string title)
        {
            ReportItem table_result = new ReportItem(title);
            for (int i = 0; i < list.Columns.Count; i++)
            {
                ReportItem column = new ReportItem(list.Columns[i].Text);

                for (int j = 0; j < list.Items.Count; j++)
                    if (i < list.Items[j].SubItems.Count)
                    {
                        float value = 0;
                        if (float.TryParse(list.Items[j].SubItems[i].Text, out value))
                            column.SubItems.Add(new ReportItem(string.Format("{0:N2}", value)));
                        else
                            column.SubItems.Add(new ReportItem(list.Items[j].SubItems[i].Text));
                    }

                table_result.SubItems.Add(column);
            }

            return table_result;
        }

    }
}
