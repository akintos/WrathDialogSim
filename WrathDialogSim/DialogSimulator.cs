using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using WrathDialogLib;
using WrathDialogLib.DialogSystem;

namespace WrathDialogSim
{
    internal class DialogueSimulator
    {
        private static readonly Brush ForegroundBrush = new SolidColorBrush(Color.FromRgb(0xD6, 0xD6, 0xD6));

        internal Properties.Settings Settings { get; set; }

        public WeblateClient Client { get; set; }

        public RichTextBox TextBox { get; set; }

        private readonly List<BaseNode> DisplayedNodes;

        private Paragraph? lastResponseParagraph;

        private BaseNode? oldestNode;

        private readonly StringBuilder sb = new StringBuilder();

        public DialogueSimulator(RichTextBox textbox, Properties.Settings settings, WeblateClient client)
        {
            DisplayedNodes = new();
            Settings = settings;
            Client = client;
            TextBox = textbox;
        }

        internal void ClearAndStartNode(BaseNode node)
        {
            ClearDocument();

            oldestNode = node;
            ShowMoreHistory();

            StartNode(node);
        }

        private void StartNode(BaseNode node)
        {
            BaseNode currentNode = node;

            while (true)
            {
                Paragraph? paragraph = GetDialogueParagraph(currentNode);
                if (paragraph != null)
                    AddParagraph(paragraph);

                var children = currentNode.NextNodes;

                if (children.Length == 0)
                {
                    AddParagraph(new Paragraph(new Run("[End of conversation]")));
                    break;
                }
                else if (children.Length == 1)
                {
                    currentNode = children[0];
                    continue;
                }
                else
                {
                    ShowChoices(currentNode);
                    break;
                }
            }
        }

        private void ShowChoices(BaseNode currentNode)
        {
            var resultParagraph = new Paragraph();

            int i = 0;
            foreach (BaseNode node in nodes)
            {
                sb.Clear();
                sb.Append($"{i + 1}. ");

                if (node.Speaker != default && node.Speaker != "You")
                {
                    sb.Append($"({node.Speaker}) ");
                }

                if (node.DialogLines != default)
                {
                    sb.Append(GetTranslatedField(node.DialogLines, $"Dialogue Text/{node.Id}", " - ", out bool fuzzy, out bool approved));
                }
                else
                {
                    sb.Append(node.GetText());
                }

                sb.Append('\n');

                Run textRun = new Run(sb.ToString());
                textRun.Foreground = ForegroundBrush;
                Hyperlink textLink = new Hyperlink(textRun);
                textLink.NavigateUri = new Uri($"dialog://{node.Id}");
                textLink.TextDecorations = null;            // Remove underline
                textLink.Foreground = Brushes.Black;        // Remove blue hyperlink color
                textLink.RequestNavigate += HandleRequestNavigate;

                if (node.IsRedCheck) textLink.Foreground = Brushes.Red;
                if (node.IsWhiteCheck) textLink.Foreground = Brushes.Gray;

                resultParagraph.Inlines.Add(textLink);
                i++;
            }

            AddParagraph(resultParagraph);
            lastResponseParagraph = resultParagraph;
        }

        public void ShowMoreHistory()
        {
            if (oldestNode == null)
                return;

            var currentNode = oldestNode;
            int nodeCount = 0;

            while (currentNode.PrevNode != null)
            {
                currentNode = currentNode.PrevNode.Get();

                if (currentNode is DialogNode)
                    break;

                var paragraph = GetDialogueParagraph(currentNode);
                if (paragraph == null)
                    continue;
                InsertParagraphFront(paragraph);
                if (++nodeCount >= 10)
                    break;
            }

            oldestNode = currentNode;
        }

        private void AddParagraph(Paragraph block)
        {
            TextBox.Document.Blocks.Add(block);
            TextBox.ScrollToEnd();
        }

        private void InsertParagraphFront(Paragraph block)
        {
            if (TextBox.Document.Blocks.Count == 0)
            {
                AddParagraph(block);
            }
            else
            {
                TextBox.Document.Blocks.InsertBefore(TextBox.Document.Blocks.FirstBlock, block);
                TextBox.ScrollToHome();
            }
        }

        private void ClearDocument()
        {
            oldestNode = null;
            lastResponseParagraph = null;
            TextBox.Document.Blocks.Clear();
        }

        public Paragraph? GetDialogueParagraph(BaseNode node)
        {
            bool hasBody = false;
            var paragraph = new Paragraph();

            var speakerRun = new Run(node.GetSpeaker());
            speakerRun.FontWeight = FontWeights.Bold;
            speakerRun.FontSize *= 1.5;
            paragraph.Inlines.Add(speakerRun);

            if (Settings.ShowDialogueId)
            {
                if (paragraph.Inlines.Count != 0)
                {
                    paragraph.Inlines.Add(new Run(" "));
                }

                var nodeIdRun = new Run(node.Guid[..8]);
                nodeIdRun.Foreground = Brushes.LightGray;
                nodeIdRun.FontSize *= 1;
                nodeIdRun.FontFamily = new FontFamily("Consolas, Courier New");

                Hyperlink nodeIdLink = new Hyperlink(nodeIdRun)
                {
                    NavigateUri = new Uri($"dialognew://{node.Guid[..8]}"),
                    TextDecorations = null,         // Remove underline
                    Foreground = ForegroundBrush    // Remove blue hyperlink color
                };
                nodeIdLink.RequestNavigate += HandleRequestNavigate;
                paragraph.Inlines.Add(nodeIdLink);
            }

            if (paragraph.Inlines.Count != 0)
            {
                paragraph.Inlines.Add(new Run("\n"));
            }

            if (node.Text != default)
            {
                string key = node.Text.Guid;
                paragraph.Inlines.Add(MakeDialogueHyperlink(node.Text.Value, key, "\n"));
                hasBody = true;
            }
            else if (node.AlternativeText != default)
            {
                var altRun = new Run(node.AlternativeText);
                altRun.Foreground = ForegroundBrush;
                paragraph.Inlines.Add(altRun);
                hasBody = true;
            }

            if (Settings.ShowCondition && !string.IsNullOrWhiteSpace(node.Comment))
            {
                var commentRun = new Run("\n" + node.Comment);
                commentRun.Foreground = Brushes.Gray;
                commentRun.FontSize = 14;
                paragraph.Inlines.Add(commentRun);
            }

            if (hasBody)
                return paragraph;

            return null;
        }

        private Hyperlink MakeDialogueHyperlink(string source, string key, string separator)
        {
            var message = GetTranslatedField(source, key, separator, out bool fuzzy, out bool approved);
            //if (settings.ShowDialogueNo)
            //    message = $"D{no}:{message}";
            var textRun = new Run(message);

            textRun.Foreground = ForegroundBrush;
            if (fuzzy)
                textRun.Foreground = Brushes.IndianRed;
            if (approved)
                textRun.Foreground = Brushes.LightGreen;

            Hyperlink textLink = new Hyperlink(textRun)
            {
                NavigateUri = new Uri(Client?.GetDialogueLink(key) ?? "http://akintos.iptime.org"),
                TextDecorations = null,       // Remove underline
                Foreground = Brushes.Black    // Remove blue hyperlink color
            };
            textLink.RequestNavigate += HandleRequestNavigate;

            return textLink;
        }

        private string GetTranslatedField(string source, string key, string separator, out bool fuzzy, out bool approved)
        {
            fuzzy = false;
            approved = false;

            if (!Settings.EnableTranslation || Client == default)
                return source;

            if (!Client.TryGetTranslation(key, out TranslationUnit? unit) || unit == null)
                return source;

            bool hasTranslation = unit.translated || unit.fuzzy;

            if (!hasTranslation)
                return source;

            if (fuzzy = unit.fuzzy)
                unit.target = "[수정 필요] " + unit.target;

            approved = unit.approved;

            if (Settings.ShowSource)
                return unit.source + separator + unit.target;
            else
                return unit.target;
        }

        private void HandleRequestNavigate(object sender, RequestNavigateEventArgs args)
        {
            var uri = args.Uri;
            if (uri.Scheme == "http")
            {
                System.Diagnostics.Process.Start(uri.ToString());
                return;
            }
            else if (uri.Scheme == "dialog" || uri.Scheme == "dialognew")
            {
                var node = DialogManager.GetNode(uri.Host);

                if (lastResponseParagraph != null && TextBox.Document.Blocks.Remove(lastResponseParagraph))
                    lastResponseParagraph = null;

                if (uri.Scheme == "dialog")
                    StartNode(node);
                else if (uri.Scheme == "dialognew")
                    ClearAndStartNode(node);
                return;
            }
            throw new NotImplementedException();
        }
    }
}
