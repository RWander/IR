using System;
using System.Threading.Tasks;
using WorkflowCore.Models;

using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step
{
    internal abstract class ApiStepAsync : StepBodyAsync, IDisposable
    {
        private ApiProxy _proxy;

        protected ApiStepAsync(ApiProxy proxy)
        {
            _proxy = proxy;
        }

        protected async Task<ResponseObject> GETAsync(string path)
        {
            // TODO: logging
            ResponseObject resObj;
            try
            {
                resObj = await _proxy.GetAsync<ResponseObject>(path);
                Console.WriteLine($"path={path}");
                Console.WriteLine($"response={resObj}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return resObj;
        }

        void IDisposable.Dispose()
        {
            if (_proxy != null)
            {
                _proxy.Dispose();
                _proxy = null;
            }
        }
    }
}