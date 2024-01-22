using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Threading;

using WrathDialogLib;
using WrathDialogSim.Properties;

using MahApps.Metro.Controls.Dialogs;

using DialogManager = WrathDialogLib.DialogManager;

namespace WrathDialogSim;

public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
{
    private readonly DialogueSimulator sim;
    private readonly Settings settings;
    private readonly WeblateClient client;

    public Uri StartupUri = null;

    public MainWindow()
    {
        InitializeComponent();
        this.TitleCharacterCasing = CharacterCasing.Normal;

        this.settings = Settings.Default;
        InitSettingsCheckBox();

        this.client = new WeblateClient("pathfinder-wotr");

        client.SetAuthToken(settings.AuthToken);
        TestAuth();

        this.sim = new DialogueSimulator(RichTextBoxDialogue, settings, client);

        new UriSchemeManager("wotrsim").RegisterUriScheme();

        RichTextBoxDialogue.Document = new FlowDocument(new Paragraph(new Run("Enter node ID and press [Start] button.")));
    }

    private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var controller = await this.ShowProgressAsync("Please wait...", "Loading database");

        string applicationPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        string applicationDirectory = Path.GetDirectoryName(applicationPath);

        controller.SetProgress(0.2);
        string databasePath = Path.Combine(applicationDirectory, "data", "database.json");
        await DialogManager.Instance.LoadDatabase(databasePath);

        await controller.CloseAsync();

        if (StartupUri != null)
        {
            UriReceived(this, StartupUri);
            StartupUri = null;
        }
    }

    #region UI event handlers

    private void ButtonStart_Click(object sender, RoutedEventArgs e)
    {
        if (DialogManager.TryGetNode(TextBoxNode.Text.ToLowerInvariant(), out var node) && node != null)
        {
            sim.ClearAndStartNode(node);
        }
        else
        {
            this.ShowMessageAsync("Error", $"올바르지 않은 노드 ID: {TextBoxNode.Text}");
        }
    }

    private void ButtonOptions_Click(object sender, RoutedEventArgs e)
    {
        var prev_width = MainGrid.ColumnDefinitions[1].MaxWidth;
        MainGrid.ColumnDefinitions[1].MaxWidth = prev_width == double.PositiveInfinity ? 0 : double.PositiveInfinity;

        settings.OptionsCollapsed = OptionsCollapsed = !OptionsCollapsed;
    }

    private bool OptionsCollapsed
    {
        get => Grid.GetColumnSpan(RichTextBoxDialogue) == 2;
        set => Grid.SetColumnSpan(RichTextBoxDialogue, value ? 2 : 1);
    }

    private void ButtonFindPrevious_Click(object sender, RoutedEventArgs e)
    {
        sim.ShowMoreHistory();
    }

    internal void UriReceived(object sender, Uri uri)
    {
        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        {
            Activate();
        }));

        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        {
            TextBoxNode.Text = uri.Host;
            ButtonStart_Click(sender, null);
        }));
    }

    private async void ButtonAuthSetting_Click(object sender, RoutedEventArgs e)
    {
        var result = await this.ShowInputAsync("weblate 연동", "weblate API 키를 입력하세요");
        if (!string.IsNullOrWhiteSpace(result))
        {
            settings.AuthToken = result;
            client.SetAuthToken(result);

            TestAuth();
        }
    }

    private void TestAuth()
    {
        var result = client.TestAuth();
        this.LabelAuth.Content = "상태: " + result;
    }

    private void HandleRequestNavigate(object sender, RequestNavigateEventArgs args)
    {
        var uri = args.Uri;
        System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
        myProcess.StartInfo.UseShellExecute = true; // true is the default, but it is important not to set it to false
        myProcess.StartInfo.FileName = uri.ToString();
        myProcess.Start();
    }

    #endregion UI event handlers

    #region Settings CheckBox

    private void InitSettingsCheckBox()
    {
        CheckBoxShowSource.IsChecked = settings.ShowSource;
        CheckBoxShowNumber.IsChecked = settings.ShowDialogueNo;
        CheckBoxShowNode.IsChecked = settings.ShowDialogueId;
        CheckBoxShowCondition.IsChecked = settings.ShowCondition;
        CheckBoxEnableTranslation.IsChecked = settings.EnableTranslation;
    }

    #pragma warning disable CS8629 // Nullable
    private void OptionCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (sender == CheckBoxShowNode)
            settings.ShowDialogueId = CheckBoxShowNode.IsChecked.Value;
        else if (sender == CheckBoxShowNumber)
            settings.ShowDialogueNo = CheckBoxShowNumber.IsChecked.Value;
        else if (sender == CheckBoxEnableTranslation)
            settings.EnableTranslation = CheckBoxEnableTranslation.IsChecked.Value;
        else if (sender == CheckBoxShowSource)
            settings.ShowSource = CheckBoxShowSource.IsChecked.Value;
        else if (sender == CheckBoxShowCondition)
            settings.ShowCondition = CheckBoxShowCondition.IsChecked.Value;
    }
#pragma warning restore CS8629 // Nullable
    #endregion Settings CheckBox

}
