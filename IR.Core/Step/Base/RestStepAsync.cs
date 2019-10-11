using System;
using System.Threading.Tasks;

using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class RestStepAsync : StepBodyAsync
    {
        private readonly RestProxy _proxy; // NB: <-- singleton

        protected abstract bool EmptyResponsePayload { get; }

        protected RestStepAsync(RestProxy proxy)
        {
            _proxy = proxy;
        }

        protected async Task<ResponseObject<TResPayload>> GetAsync<TResPayload>(
            string path
        ) where TResPayload: Payload
        {
            // TODO: logging
            var resObj = await _proxy.GetAsync<TResPayload>(path, EmptyResponsePayload == false);
            Console.WriteLine($"path={path}");
            Console.WriteLine($"response={resObj}");

            return resObj;
        }

        protected async Task<ResponseObject<TResPayload>> PostAsync<TResPayload>(
            string path,
            string json
        ) where TResPayload : Payload
        {
            // TODO: logging
            var resObj = await _proxy.PostAsync<TResPayload>(path, json, EmptyResponsePayload == false);
            Console.WriteLine($"path={path}");
            Console.WriteLine($"response={resObj}");

            return resObj;
        }
    }
}