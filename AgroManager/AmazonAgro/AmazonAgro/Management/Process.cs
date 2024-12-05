using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAgro
{
    public class Process
    {

        public Process(string title, int window, int permission)
        {
            Title = title;
            Window = window;
            Permission = permission;
            IsFinished = true;
        }

        public string Title { get; set; }

        public int Window { get; set; }

        public int Permission { get; set; }

        private event Action action;
        public void SetHandler(Action action)
        {
            this.action = action;
        }

        public void HandleAction()
        {
            if (action != null)
                action();
        }

        public bool IsFinished { get; set; }

    }
}
