using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.ElementsSystem
{
    public abstract class Element
    {
        public abstract string GetCaption();

        // public abstract ExpressionSyntax GetExpression();

        public override string ToString()
        {
            return GetCaption();
        }

        public static implicit operator string(Element obj) => obj.ToString();

        public string name;
    }
}
