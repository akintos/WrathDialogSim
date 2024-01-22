using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace WrathDialogSim;

internal class UriHandler : MarshalByRefObject, IUriHandler
{
    public delegate void UriReceivedEventHandler(object sender, Uri uri);

    public static event UriReceivedEventHandler UriReceived;

    private static string IpcChannelName => Assembly.GetEntryAssembly().GetName().Name;

    public static bool RegisterIpc()
    {
        try
        {
            IpcServerChannel channel = new IpcServerChannel(IpcChannelName);
            ChannelServices.RegisterChannel(channel, ensureSecurity: true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(UriHandler), "UriHandler", WellKnownObjectMode.SingleCall);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public static IUriHandler GetHandler()
    {
        IpcClientChannel channel = new();
        ChannelServices.RegisterChannel(channel, ensureSecurity: true);
        string address = $"ipc://{IpcChannelName}/UriHandler";
        IUriHandler handler = (IUriHandler)RemotingServices.Connect(typeof(IUriHandler), address);

        // need to test whether connection was established
        TextWriter.Null.WriteLine(handler.ToString());

        return handler;
    }

    public bool HandleUri(Uri uri)
    {
        UriReceived?.Invoke(this, uri);
        return true;
    }
}

internal interface IUriHandler
{
    bool HandleUri(Uri uri);
}
