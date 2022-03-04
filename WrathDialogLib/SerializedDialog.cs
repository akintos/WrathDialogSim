using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrathDialogLib.DialogSystem;

namespace WrathDialogLib
{
    public class SerializedDialog
    {
        public List<DialogNode> DialogList = new();

        public List<AnswerNode> AnswerList = new();

        public List<CueNode> CueList = new();

        public List<CheckNode> CheckList = new();

        public List<BaseNode> NodeList = new();

        public List<BaseNode> LinkList = new();

        public Dictionary<string, BaseNode> GetNodeDict()
        {
            return Enumerable.Concat<BaseNode>(DialogList, AnswerList)
                             .Concat(CueList)
                             .Concat(CheckList)
                             .Concat(NodeList)
                             .Concat(LinkList)
                             .ToDictionary(x => x.Guid[..8]);
        }

        public static async Task<SerializedDialog> DeserializeAsync(string path)
        {
            return await JsonHelper.DeserializeJsonAsync<SerializedDialog>(path);
        }

        public async Task SerializeAsync(string path)
        {
            await JsonHelper.SerializeJsonAsync(path, this);
        }
    }
}
