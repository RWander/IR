using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.Json;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class ApiMethodAsync<TReqBody>: ApiStepAsync
        where TReqBody: class, new()
    {
        public TReqBody RequestBodyObj { get; set; }
        protected abstract string Method { get; }
        protected abstract EApiMethodType MethodType { get; }

        protected ApiMethodAsync(ApiProxy proxy) : base(proxy) { }

        public sealed override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            ResponseObject resObj;
            try
            {
                switch (MethodType)
                {
                    case EApiMethodType.GET:
                        resObj = await GETAsync(Method);
                        break;
                    case EApiMethodType.POST:
                        var reqBody = JsonSerializer.Serialize(RequestBodyObj);
                        resObj = await POSTAsync(Method, reqBody);
                        break;
                    case EApiMethodType.PUT:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    case EApiMethodType.DELETE:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    default:
                        throw new IndexOutOfRangeException($"Unknown {nameof(MethodType)}={MethodType}.");
                }
            }
            catch (Exception e)
            {
                var method = string.Empty;
                switch (MethodType)
                {
                    case EApiMethodType.GET:
                        method = nameof(GETAsync);
                        break;
                    case EApiMethodType.POST:
                        method = nameof(GETAsync);
                        break;
                    case EApiMethodType.PUT:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    case EApiMethodType.DELETE:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    default:
                        throw new IndexOutOfRangeException($"Unknown {nameof(MethodType)}={MethodType}.");
                }

                throw new WorkflowAbortException($"Exception in {method} method.", e);
            }

            Debug.Assert(resObj != null);
            if (resObj.IsOk == false)
            {
                throw new WorkflowAbortException(resObj.Status);
            }

            return ExecutionResult.Next();
        }
    }
}
