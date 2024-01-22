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

namespace WrathDialogSim;

internal class DialogueSimulator
{
    private static readonly Brush ForegroundBrush = new SolidColorBrush(Color.FromRgb(0xD6, 0xD6, 0xD6));
    private static readonly FontFamily ConsoleFont = new FontFamily("Consolas, Courier New");

    internal Properties.Settings Settings { get; set; }

    public WeblateClient Client { get; set; }

    public RichTextBox TextBox { get; set; }

    private Paragraph lastResponseParagraph;

    private BaseNode oldestNode;

    private readonly StringBuilder sb = new StringBuilder();

    public DialogueSimulator(RichTextBox textbox, Properties.Settings settings, WeblateClient client)
    {
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
            Paragraph paragraph = GetDialogueParagraph(currentNode);
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

        var childNodes = currentNode.GetDisplayableChildNodes();

        for (int i = 0; i < childNodes.Count; i++)
        {
            BaseNode node = childNodes[i];
            sb.Clear();
            sb.Append($"{i + 1}. ");

            if (node is AnswerNode ans)
            {
                if (ans.MythicRequirement != default)
                    sb.Append($"[{ans.MythicRequirement}] ");

                if (ans.AlignmentShift != null)
                    sb.Append($"[{ans.AlignmentShift.Direction}] ");
            }

            sb.Append($"({node.GetSpeaker()}) ");

            if (node.Text != default)
            {
                sb.Append(GetTranslatedField(node.Text, " - ", out var unit));
            }
            else
            {
                sb.Append(node.AlternativeText);
            }

            if (i != childNodes.Count - 1)
                sb.Append("\n");

            Run textRun = new Run(sb.ToString());
            textRun.Foreground = ForegroundBrush;
            Hyperlink textLink = new Hyperlink(textRun);
            textLink.NavigateUri = new Uri($"dialog://{node.Guid}");
            textLink.TextDecorations = null;            // Remove underline
            textLink.Foreground = Brushes.Black;        // Remove blue hyperlink color
            textLink.RequestNavigate += HandleRequestNavigate;

            resultParagraph.Inlines.Add(textLink);

            if (Settings.ShowCondition && !string.IsNullOrWhiteSpace(node.Conditions))
            {
                Run conditionRun = new Run(node.Conditions + "\n");
                conditionRun.Foreground = Brushes.Gray;
                conditionRun.FontSize = 14;
                conditionRun.FontFamily = ConsoleFont;
                resultParagraph.Inlines.Add(conditionRun);
            }

            if (i != childNodes.Count - 1)
            {
                var sepRun = new Run(" \n")
                {
                    FontSize = 5,
                };
                resultParagraph.Inlines.Add(sepRun);
            }
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

            var paragraph = GetDialogueParagraph(currentNode);
            if (paragraph == null)
                continue;
            InsertParagraphFront(paragraph);
            if (++nodeCount >= 10)
                break;

            if (currentNode is DialogNode)
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

    public Paragraph GetDialogueParagraph(BaseNode node)
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

            var nodeIdRun = new Run(node.Guid.Substring(0, 8));
            nodeIdRun.Foreground = Brushes.LightGray;
            nodeIdRun.FontSize *= 1;
            nodeIdRun.FontFamily = ConsoleFont;

            Hyperlink nodeIdLink = new Hyperlink(nodeIdRun)
            {
                NavigateUri = new Uri($"dialognew://{node.Guid.Substring(0, 8)}"),
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

        if (node is AnswerNode ans0)
        {
            sb.Clear();
            if (ans0.MythicRequirement != default)
                sb.Append($"[{ans0.MythicRequirement}] ");

            if (ans0.AlignmentShift != null)
                sb.Append($"[{ans0.AlignmentShift.Direction}] ");
            
            if (sb.Length != 0)
            {
                paragraph.Inlines.Add(new Run(sb.ToString()));
            }
        }

        if (node.Text != default && !node.Text.IsEmptyString())
        {
            paragraph.Inlines.Add(MakeDialogueHyperlink(node.Text, "\n"));
            hasBody = true;
        }
        else if (node.AlternativeText != default)
        {
            var altRun = new Run(node.AlternativeText);
            altRun.Foreground = ForegroundBrush;
            paragraph.Inlines.Add(altRun);
            hasBody = true;
        }

        if (node is AnswerNode ans && ans.AlignmentShift != null && ans.AlignmentShift.Value != 0)
        {
            var run = new Run($"\n[{ans.AlignmentShift.Direction}] ");
            run.FontSize = 14;
            run.Foreground = Brushes.Gray;
            paragraph.Inlines.Add(run);

            var link = MakeDialogueHyperlink(node.AlignmentShift.Description, "\n");
            link.FontSize = 14;
            link.Inlines.FirstInline.Foreground = Brushes.Gray;
            paragraph.Inlines.Add(link);
        }

        if (Settings.ShowCondition && !string.IsNullOrWhiteSpace(node.Conditions))
        {
            var conditionsRun = new Run("\n" + node.Conditions);
            conditionsRun.Foreground = Brushes.Gray;
            conditionsRun.FontSize = 14;
            conditionsRun.FontFamily = ConsoleFont;
            paragraph.Inlines.Add(conditionsRun);
        }

        if (Settings.ShowCondition && !string.IsNullOrWhiteSpace(node.Comment))
        {
            var commentRun = new Run("\n" + node.Comment);
            commentRun.Foreground = Brushes.Gray;
            commentRun.FontSize = 14;
            commentRun.FontFamily = ConsoleFont;
            paragraph.Inlines.Add(commentRun);
        }

        if (hasBody)
            return paragraph;

        return null;
    }

    private Hyperlink MakeDialogueHyperlink(LocalizedString localizedString, string separator)
    {
        var message = GetTranslatedField(localizedString, separator, out TranslationUnit unit);
        //if (settings.ShowDialogueNo)
        //    message = $"D{no}:{message}";
        var textRun = new Run(message);

        textRun.Foreground = ForegroundBrush;
        if (unit.Fuzzy)
            textRun.Foreground = Brushes.IndianRed;
        if (unit.Approved)
            textRun.Foreground = Brushes.LightGreen;

        string translateUrl;
        if (unit is not null)
        {
            translateUrl = $"{Constants.WEBLATE_HOST}/translate/{Constants.PROJECT_SLUG}/{unit.component}/ko/?checksum={unit.checksum}";
        }
        else
        {
            translateUrl = $"{Constants.WEBLATE_HOST}/translate/{Constants.PROJECT_SLUG}/";
        }

        Hyperlink textLink = new(textRun)
        {
            NavigateUri = new Uri(translateUrl),
            TextDecorations = null,       // Remove underline
            Foreground = Brushes.Black    // Remove blue hyperlink color
        };
        textLink.RequestNavigate += HandleRequestNavigate;

        return textLink;
    }

    private string GetTranslatedField(LocalizedString localizedString, string separator, out TranslationUnit unit)
    {
        unit = null;

        string source = localizedString.Value;

        if (!Settings.EnableTranslation || Client == default)
            return source;

        if (!Client.TryGetTranslation(localizedString.Guid, out unit) || unit == null)
            return source;

        bool hasTranslation = unit.state > 0;

        if (!hasTranslation)
            return source;

        string target = unit.target;

        if (unit.Fuzzy)
            target = "[수정 필요] " + target;

        if (Settings.ShowSource)
            return unit.source + separator + target;
        else
            return target;
    }

    private void HandleRequestNavigate(object sender, RequestNavigateEventArgs args)
    {
        var uri = args.Uri;
        if (uri.Scheme == "http" || uri.Scheme == "https")
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.UseShellExecute = true; // true is the default, but it is important not to set it to false
            myProcess.StartInfo.FileName = uri.ToString();
            myProcess.Start();
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
