using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib
{
    public class LocalizedString
    {
        public string Guid;
        public string Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
