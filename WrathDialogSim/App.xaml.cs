using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WrathDialogSim;

public partial class App : Application
{
    void App_Startup(object sender, StartupEventArgs e)
    {
        Uri uri = null;
        if (Environment.GetCommandLineArgs().Length > 1)
        {
            string arg = Environment.GetCommandLineArgs()[1];
            if (arg.StartsWith("wotrsim://"))
            {
                uri = new Uri(arg);
            }
        }

        try
        {
            IUriHandler remoteHandler = UriHandler.GetHandler();
            if (remoteHandler != null)
            {
                if (uri != null) remoteHandler.HandleUri(uri);
                Current.Shutdown();
            }
        }
        catch (Exception) { }

        UriHandler.RegisterIpc();

        var mainWindow = new MainWindow();
        if (uri != null)
        {
            mainWindow.StartupUri = uri;
        }
        UriHandler.UriReceived += mainWindow.UriReceived;
        MainWindow = mainWindow;
        MainWindow.Show();
    }
}
