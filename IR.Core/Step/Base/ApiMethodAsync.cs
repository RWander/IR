using System;
using System.Diagnostics;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class ApiMethodAsync: ApiStepAsync
    {
        public abstract string Method { get; }
        public virtual string MethodData { get; } = string.Empty;
        public abstract EApiMethodType MethodType { get; }

        public ApiMethodAsync(ApiProxy proxy) : base(proxy) { }

        public override sealed async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            ResponseObject resObj = null;
            try
            {
                switch (MethodType)
                {
                    case EApiMethodType.GET:
                        resObj = await GETAsync(Method);
                        break;
                    case EApiMethodType.POST:
                        resObj = await POSTAsync(Method, MethodData);
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
                        throw new WorkflowAbortException($"Exception in {method} method.", e);
                }
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
