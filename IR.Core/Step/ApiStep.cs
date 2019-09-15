using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal abstract class ApiStep: StepBody
    {
        protected ApiProxy Proxy;

        protected ApiStep()
        {
            Proxy = ServiceProviderHolder.Instance.GetService<ApiProxy>();
        }
    }
}