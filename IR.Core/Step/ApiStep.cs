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
}