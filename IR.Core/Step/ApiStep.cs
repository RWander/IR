using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class ApiStep: StepBody
    {
        protected ApiProxy Proxy;

        protected ApiStep(ApiProxy proxy)
        {
            Proxy = proxy;
        }
    }

    internal abstract class ApiStepAsync : StepBodyAsync
    {
        protected ApiProxy Proxy;

        protected ApiStepAsync(ApiProxy proxy)
        {
            Proxy = proxy;
        }
    }
}