using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem
{
    public static class NodeRefExtensions
    {
        public static NodeRef<T> ToReference<T>(this T node) where T : BaseNode
        {
            return new NodeRef<T>(node.Guid);
        }
    }
}
