using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using IR.Core.Streaming;

namespace IR.Core.Common
{
    /// <summary>
    /// See official C#-SDK sample on GitHub:
    /// https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk/blob/master/src/Tinkoff.Trading.OpenApi/Network/Connection.cs
    /// </summary>
    internal sealed class WsProxy : IDisposable
    {
        private ClientWebSocket _ws;
        private string _url;
        private string _token;
        private bool _inited;

        #region [.cctor]
        private WsProxy(IConfigurationFactory configFactory)
        {
            _ws = new ClientWebSocket();

            var config = configFactory.Configuration;
            _url = config["wsUrl"];
            _token = config["token"];
        }

        private async Task InitAsync()
        {
            // TODO: logger

            if (_inited) return;

            Console.WriteLine($"Connecting to: {_url}");
            _ws.Options.SetRequestHeader("Authorization", $"Bearer {_token}");
            await _ws
                .ConnectAsync(new Uri(_url), CancellationToken.None)
                .ConfigureAwait(false);
            _inited = true;
            Console.WriteLine($"Connected to: {_url}");

            var _ = Task.Run(async () =>
            {
                var transferBuffer = new byte[8096];
                var msgBuffer = new List<byte>();
                while (_ws.State == WebSocketState.Open)
                {
                    var buffer = new ArraySegment<byte>(transferBuffer);
                    var result = await _ws.ReceiveAsync(buffer, CancellationToken.None);
                    switch (result.MessageType)
                    {
                        case WebSocketMessageType.Close:
                            Dispose();
                            return;
                        case WebSocketMessageType.Text:
                            var receivedBytes = new byte[result.Count];
                            Array.ConstrainedCopy(buffer.Array, 0, receivedBytes, 0, result.Count);
                            msgBuffer.AddRange(receivedBytes);
                            if (result.EndOfMessage)
                            {
                                var data = Encoding.UTF8.GetString(msgBuffer.ToArray());
                                OnStreamingEvent(data);
                                msgBuffer.Clear();
                            }
                            break;
                        default:
                            // do nothing
                            break;
                    }
                }
            });
        }

        public static WsProxy Create(IConfigurationFactory configFactory)
        {
            var wsProxy = new WsProxy(configFactory);
            wsProxy.InitAsync().Wait();
            return wsProxy;
        }
        #endregion

        #region [Public methods]
        public async Task SendStreamingRequestAsync<TStreamingRequest>(TStreamingRequest request)
            where TStreamingRequest : StreamingRequest
        {
            if (_inited == false || _ws.State != WebSocketState.Open)
                throw new ApplicationException("The web socket was not created or closed.");

            var json = request.Serialize();
            var data = Encoding.UTF8.GetBytes(json);
            var buffer = new ArraySegment<byte>(data);
            await _ws.SendAsync(
                buffer,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None
            ).ConfigureAwait(false);
        }
        #endregion

        #region [Private methods]
        private void OnStreamingEvent(string data)
        {
            Console.WriteLine($"Streaming API: received event\n{data}");

            // TODO
            // ..

            // use data.Deserialize() ext method.
            //var response = JsonSerializer.Deserialize<StreamingResponse>(data);
            //var response = JsonConvert.DeserializeObject<StreamingResponse>(data);
        }
        #endregion

        #region [IDisposeable implementation]
        public void Dispose()
        {
            if (_ws != null)
            {
                _ws.CloseAsync(
                    WebSocketCloseStatus.Empty,
                    string.Empty,
                    CancellationToken.None
                ).Wait(TimeSpan.FromMilliseconds(100));
                Console.WriteLine($"Disconnected from: {_url}");

                _ws.Dispose();
                _ws = null;

                _token = null;
                _url = null;

                _inited = false;
            }
        }
        #endregion
    }
}
