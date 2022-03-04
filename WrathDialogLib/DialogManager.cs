using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WrathDialogLib.DialogSystem;

namespace WrathDialogLib
{
    public class DialogManager
    {
        private static DialogManager? _instance;
        public static DialogManager Instance 
        { 
            get => _instance ??= new DialogManager();
        }

        private Dictionary<string, BaseNode> Nodes = new();

        public static bool TryGetNode(string guid, out BaseNode? node)
        {
            return Instance.Nodes.TryGetValue(guid[..8], out node);
        }

        public static BaseNode GetNode(string guid)
        {
            return Instance.Nodes[guid[..8]];
        }

        private DialogManager() { }

        public async Task LoadDatabase(string path)
        {
            var serializedDb = await SerializedDialog.DeserializeAsync(path);
            Nodes = serializedDb.GetNodeDict();
        }
    }
}
