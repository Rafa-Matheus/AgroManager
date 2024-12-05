using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHS.SQL
{
    public partial class SQLFieldBase : UserControl
    {

        public SQLFieldBase()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public string SQLName { get; set; }

        public Control Panel
        {
            get { return panel; }
        }

    }
}
