using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class DragAndDropSupport
    {

        public event EventHandler<DragAndDropEventArgs> Dropped;

        public class DragAndDropEventArgs : EventArgs
        {
            public Control Control { get; set; }
        }

        private bool is_holded;
        private Control control;
        private Control a;
        private Control b;
        public DragAndDropSupport(Control a, Control b)
        {
            this.a = a;
            this.b = b;

            //Implementar eventos
            a.ControlAdded += (o, args) =>
            {
                args.Control.MouseDown += DragAndDropSupport_MouseDown;
                args.Control.MouseUp += DragAndDropSupport_MouseUp;
            };
            a.ControlRemoved += (o, args) =>
            {
                args.Control.MouseDown -= DragAndDropSupport_MouseDown;
                args.Control.MouseUp -= DragAndDropSupport_MouseUp;
            };

            for (int i = 0; i < a.Controls.Count; i++)
            {
                a.Controls[i].MouseDown += DragAndDropSupport_MouseDown;
                a.Controls[i].MouseUp += DragAndDropSupport_MouseUp;
            }
        }

        void DragAndDropSupport_MouseDown(object sender, MouseEventArgs e)
        {
            GetParent(a).Cursor = Cursors.Hand;
            control = (Control)sender;
            is_holded = true;
        }

        void DragAndDropSupport_MouseUp(object sender, MouseEventArgs e)
        {
            if (is_holded)
            {
                if (b.ClientRectangle.Contains(b.PointToClient(Control.MousePosition)))
                {
                    if (Dropped != null)
                        Dropped(this, new DragAndDropEventArgs() { Control = control });
                }

                is_holded = false;
                GetParent(a).Cursor = Cursors.Default;
            }
        }

        private Control GetParent(Control control)
        {
            if (control.Parent != null)
                return GetParent(control.Parent);

            return control;
        }

    }
}
