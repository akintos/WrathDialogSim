using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace WrathDialogSim;

internal class UriSchemeManager
{
    public string Scheme { get; private set; }

    public UriSchemeManager(string scheme)
    {
        Scheme = scheme;
    }

    public void RegisterUriScheme()
    {
        string applicationPath = Process.GetCurrentProcess().MainModule.FileName;

        // using RegistryKey hkcrClass = Registry.ClassesRoot.CreateSubKey(Scheme);

        using RegistryKey hkcrClass = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + Scheme);

        hkcrClass.SetValue(null, $"URL:{Scheme} Protocol");
        hkcrClass.SetValue("URL Protocol", String.Empty, RegistryValueKind.String);

        using (RegistryKey defaultIcon = hkcrClass.CreateSubKey("DefaultIcon"))
        {
            string iconValue = string.Format("\"{0}\",0", applicationPath);
            defaultIcon.SetValue(null, iconValue);
        }

        using (RegistryKey command = hkcrClass.CreateSubKey(@"shell\open\command"))
        {
            string cmdValue = string.Format("\"{0}\" \"%1\"", applicationPath);
            command.SetValue(null, cmdValue);
        }
    }
}