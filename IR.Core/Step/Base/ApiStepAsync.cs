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

        protected async Task<ResponseObject> GETAsync(string path)
        {
            // TODO: logging
            var resObj = await _proxy.GetAsync<ResponseObject>(path);
            Console.WriteLine($"path={path}");
            Console.WriteLine($"response={resObj}");

            return resObj;
        }

        protected async Task<ResponseObject> POSTAsync(string path, string json)
        {
            // TODO: logging
            var resObj = await _proxy.POSTAsync<ResponseObject>(path, json);
            Console.WriteLine($"path={path}");
            Console.WriteLine($"response={resObj}");

            return resObj;
        }
    }
}