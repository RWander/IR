using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace IR.Core.Common
{
    /// <summary>
    /// See official C#-SDK sample on GitHub:
    /// https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk/blob/master/src/Tinkoff.Trading.OpenApi/Network/Connection.cs
    /// </summary>
    internal sealed class WsProxy: IDisposable
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

        private async Task Init()
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
        }

        public static WsProxy Create(IConfigurationFactory configFactory)
        {
            var wsProxy = new WsProxy(configFactory);
            wsProxy.Init().Wait();
            return wsProxy;
        }
        #endregion

        #region [Public methods]
        public void P()
        {
            // TODO
            // ..
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
