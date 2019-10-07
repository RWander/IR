using System;
using System.Threading.Tasks;

using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class ApiStepAsync : StepBodyAsync
    {
        private readonly ApiProxy _proxy; // NB: <-- singleton

        protected ApiStepAsync(ApiProxy proxy)
        {
            _proxy = proxy;
        }

        protected async Task<ResponseObject<TResPayload>> GETAsync<TResPayload>(string path)
            where TResPayload: class, new()
        {
            // TODO: logging
            var resObj = await _proxy.GetAsync<TResPayload>(path);
            Console.WriteLine($"path={path}");
            Console.WriteLine($"response={resObj}");

            return resObj;
        }

        protected async Task<ResponseObject<TResPayload>> POSTAsync<TResPayload>(string path, string json)
            where TResPayload : class, new()
        {
            // TODO: logging
            var resObj = await _proxy.POSTAsync<TResPayload>(path, json);
            Console.WriteLine($"path={path}");
            Console.WriteLine($"response={resObj}");

            return resObj;
        }
    }
}