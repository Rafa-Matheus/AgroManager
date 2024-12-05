using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHS.SQL
{
    public class SQLCommandNotSupportedByAdapterException : Exception
    {

        public override string Message
        {
            get
            {
                return string.Format("O comando não é suportado pelo tipo de adaptador '{0}'.", Source.GetType().Name);
            }
        }

    }
}
