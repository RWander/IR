using IR.Core.Common;

using WorkflowCore.Models;

namespace IR.Core.Step
{
    internal abstract class WsStepAsync : StepBodyAsync
    {
        protected WsProxy Proxy; // NB: <-- singleton

        protected WsStepAsync(WsProxy proxy)
        {
            Proxy = proxy;
        }
    }
}