using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using IR.Core.Step;

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
        public async Task<T> GetAsync<T>(string path)
            where T: class
        {
            // TODO: logging
            T data;
            var res = await _client.GetAsync(path);
            if (res.IsSuccessStatusCode)
            {
                data = await res.Content.ReadAsAsync<T>();
            }
            else
            {
                // TODO: correct error handling
                throw new Exception(res.StatusCode.ToString());
            }
            return data;
        }

        #region IDisposable implementation
        void IDisposable.Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }
        #endregion
    }
}