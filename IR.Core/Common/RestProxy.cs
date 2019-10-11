using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using IR.Core.Step;

namespace IR.Core.Common
{
    internal sealed class RestProxy: IDisposable
    {
        private HttpClient _client;

        public RestProxy(IConfigurationFactory configFactory) 
        {
            var config = configFactory.Configuration;

            var restUrl = config["restUrl"];
            var token = config["token"];

            // HttpClint documentation is here https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
            _client = new HttpClient
            {
                BaseAddress = new Uri(restUrl)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// GET
        /// </summary>
        public async Task<ResponseObject<TResPayload>> GetAsync<TResPayload>(
            string path,
            bool readPayload
        ) where TResPayload : Payload
        {
            // TODO: logging
            ResponseObject<TResPayload> data;
            var res = await _client.GetAsync(path).ConfigureAwait(false);
            if (res.IsSuccessStatusCode)
            {
                var resJson = await res.Content.ReadAsStringAsync();
                data = ResponseObject<TResPayload>.Build<TResPayload>(resJson, readPayload);
            }
            else
            {
                // TODO: correct error handling
                throw new Exception(ResponseError.ToString(path, null, res.ToString()));
            }
            return data;
        }

        public async Task<ResponseObject<TResPayload>> PostAsync<TResPayload>(
            string path,
            string json,
            bool readPayload
        ) where TResPayload : Payload
        {
            // TODO: logging
            ResponseObject<TResPayload> data;
            var content = new StringContent(json);
            var res = await _client.PostAsync(path, content).ConfigureAwait(false);
            if (res.IsSuccessStatusCode)
            {
                var resJson = await res.Content.ReadAsStringAsync();
                data = ResponseObject<TResPayload>.Build<TResPayload>(resJson, readPayload);
            }
            else
            {
                // TODO: correct error handling
                throw new Exception(ResponseError.ToString(path, json, res.ToString()));
            }
            return data;
        }

        #region IDisposable implementation
        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }
        #endregion

        #region [Nested classes]
        private sealed class ResponseError
        {
            public string Method { get; }
            public string Param { get; }
            public string Error { get; }

            public ResponseError(string method, string param, string error)
            {
                Method = method;
                Param = param;
                Error = error;
            }

            public static string ToString(string method, string param, string error)
            {
                var err = new ResponseError(method, param, error);
                return err.ToString();
            }

            public override string ToString()
            {
                return $"\nMethod: {Method}\nParam: {Param}\nError: {Error}";
            }
        }
        #endregion
    }
}