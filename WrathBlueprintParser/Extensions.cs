using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrathDialogLib.DialogSystem;

namespace Kingmaker
{
    public static class Extensions
    {
        public static NodeRefBase ToNodeRef(this BlueprintReferenceBase bpref)
        {
            return new NodeRefBase(bpref.Guid.ToString("N"));
        }

        public static List<NodeRefBase> ToNodeRefList<T>(this List<T> blueprintList) where T : BlueprintReferenceBase
        {
            return new List<NodeRefBase>(blueprintList.Select(x => x.ToNodeRef()));
        }

        public static NodeRefBase[] ToNodeRefArray<T>(this List<T> blueprintList) where T : BlueprintReferenceBase
        {
            return blueprintList.Select(ToNodeRef).ToArray();
        }
    }
}
