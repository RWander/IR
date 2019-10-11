using System;
using System.Diagnostics;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class RestMethodAsync<TReqBody, TResPayload> : RestStepAsync
        where TReqBody: class, new()
        where TResPayload: Payload
    {
        public TReqBody RequestBodyObj { get; set; }
        public TResPayload ResponsePayload { get; set; }
        protected abstract string Method { get; }
        protected abstract ERestMethodType MethodType { get; }

        protected RestMethodAsync(RestProxy proxy) : base(proxy) { }

        public sealed override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            ResponseObject<TResPayload> resObj;
            try
            {
                switch (MethodType)
                {
                    case ERestMethodType.GET:
                        resObj = await GetAsync<TResPayload>(Method);
                        break;
                    case ERestMethodType.POST:
                        var reqBody = RequestBodyObj.Serialize();
                        resObj = await PostAsync<TResPayload>(Method, reqBody);
                        break;
                    case ERestMethodType.PUT:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    case ERestMethodType.DELETE:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    default:
                        throw new IndexOutOfRangeException($"Unknown {nameof(MethodType)}={MethodType}.");
                }
            }
            catch (Exception e)
            {
                string method;
                switch (MethodType)
                {
                    case ERestMethodType.GET:
                        method = nameof(GetAsync);
                        break;
                    case ERestMethodType.POST:
                        method = nameof(GetAsync);
                        break;
                    case ERestMethodType.PUT:
                        // TODO: implement
                        // ..
                        throw new NotImplementedException("TODO");
                    case ERestMethodType.DELETE:
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
                throw new WorkflowAbortException(resObj.ToString());
            }

            ResponsePayload = resObj.Payload;

            return ExecutionResult.Next();
        }
    }
}
