using IR.Core.Step;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace IR.Core.Common
{
    internal sealed class ApiProxy: IDisposable
    {
        private HttpClient _client;

        public ApiProxy(IConfigurationFactory configFactory) 
        {
            var config = configFactory.Configuration;

            var baseUrl = config["baseUrl"];
            var token = config["token"];

            // HttpClint documentation is here https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
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
        public async Task<ResponseObject<TResPayload>> GetAsync<TResPayload>(string path)
            where TResPayload : class, new()
        {
            // TODO: logging
            ResponseObject<TResPayload> data;
            var res = await _client.GetAsync(path);
            if (res.IsSuccessStatusCode)
            {
                var resJson = await res.Content.ReadAsStringAsync();
                data = ResponseObject<TResPayload>.Build<TResPayload>(resJson);
            }
            else
            {
                // TODO: correct error handling
                throw new Exception(ResponseError.ToString(path, null, res.ToString()));
            }
            return data;
        }

        public async Task<ResponseObject<TResPayload>> POSTAsync<TResPayload>(string path, string json)
            where TResPayload : class, new()
        {
            // TODO: logging
            ResponseObject<TResPayload> data;
            var content = new StringContent(json);
            var res = await _client.PostAsync(path, content);
            if (res.IsSuccessStatusCode)
            {
                var resJson = await res.Content.ReadAsStringAsync();
                data = ResponseObject<TResPayload>.Build<TResPayload>(resJson);
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