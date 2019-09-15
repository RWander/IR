using System;
using RestSharp;

namespace IR.Core.Common
{
    internal sealed class ApiProxy // TODO: singleton?, IDisposable
    {
        private readonly string _token; // TODO: sandbox and regular token (see git-ignored .token file) 
        private readonly IRestClient _client;

        public ApiProxy(IConfigurationFactory configFactory) 
        {
            var config = configFactory.Configuration;

            var baseUrl = config["baseUrl"];
            _client = new RestClient(baseUrl);
            _token = config["token"];

            //_client.Timeout = ? // TODO set Timeout.
            //_client.Authenticator = new HttpBasicAuthenticator(accountSid, secretKey);
            //_accountSid = accountSid;
        }

        public T Execute<T>(RestRequest req) where T : new() // TODO: private (?)
        {
            req.AddHeader("Authorization", $"Bearer {_token}"); // used on every request
            var res = _client.Execute<T>(req);

            if (res.ErrorException != null)
            {
                const string msg = "Error retrieving response. Check inner details for more info.";
                var ex = new Exception(msg, res.ErrorException);
                throw ex;
            }
            return res.Data;
        }
    }
}