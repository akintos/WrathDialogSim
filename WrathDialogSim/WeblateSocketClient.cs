using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WrathDialogSim;

/*
internal class WeblateSocketClient
{
    const int BUFFER_SIZE = 8192;
    const int RETRY_COUNT = 3;

    const int TIMEOUT_MS = 1000;

    private ClientWebSocket _socket;

    public JsonSerializerOptions Options { get; set; }

    private string _authToken = null;

    private readonly byte[] _buffer;
    private readonly ArraySegment<byte> _fullSegment;

    private readonly Uri _uri;

    public WeblateSocketClient(string url)
    {
        _uri = new Uri(url);
        _buffer = new byte[BUFFER_SIZE];

        _fullSegment = new ArraySegment<byte>(_buffer);
    }

    public void InitWebSocket()
    {
        _socket ??= new ClientWebSocket();

        if (_authToken != null)
        {
            _socket.Options.SetRequestHeader("Authentication", $"Token {_authToken}");
        }
    }

    public void SetAuthToken(string authToken)
    {
        _authToken = authToken;
        InitWebSocket();
    }

    public bool EnsureConnected()
    {
        if (_socket?.State == WebSocketState.Open)
        {
            return true;
        }

        if (_socket?.State == WebSocketState.Aborted)
        {
            _socket.Dispose();
            _socket = null;
        }

        InitWebSocket();

        _socket.ConnectAsync(_uri, default).GetAwaiter().GetResult();

        return _socket.State == WebSocketState.Open;
    }

    public T SendAndReceive<T>(string message)
    {
        Send(message);
        return Receive<T>();
    }

    public void Send(string message)
    {
        Exception lastException = null;

        for (int i = 0; i < RETRY_COUNT; i++)
        {
            try
            {
                EnsureConnected();
                SendInternal(message);
                return;
            }
            catch (Exception e)
            {
                lastException = e;
            }
        }

        throw lastException ?? new IOException("Failed to send message for unknown reason");
    }

    private void SendInternal(string message)
    {
        int length = Encoding.UTF8.GetBytes(message, 0, message.Length, _buffer, 0);
        CancellationToken timeOut = new CancellationTokenSource(TIMEOUT_MS).Token;

        _socket.SendAsync(
            new ArraySegment<byte>(_buffer, 0, length),
            WebSocketMessageType.Text,
            endOfMessage: true,
            cancellationToken: timeOut
        ).GetAwaiter().GetResult();
    }

    public T Receive<T>()
    {
        Exception lastException = null;

        for (int i = 0; i < RETRY_COUNT; i++)
        {
            try
            {
                EnsureConnected();
                return ReceiveInternal<T>();
            }
            catch (Exception e)
            {
                lastException = e;
            }
        }

        throw lastException ?? new IOException("Failed to receive message for unknown reason");
    }

    public T ReceiveInternal<T>()
    {
        CancellationToken timeOut = new CancellationTokenSource(TIMEOUT_MS).Token;
        WebSocketReceiveResult result = _socket.ReceiveAsync(_fullSegment, timeOut).GetAwaiter().GetResult();

        if (result.EndOfMessage)
        {
            var span = new ReadOnlySpan<byte>(_buffer, 0, result.Count);
            JsonResponse<T> resp = JsonSerializer.Deserialize<JsonResponse<T>>(span, Options);

            return resp.Data;
        }

        throw new NotImplementedException();
    }
}

*/