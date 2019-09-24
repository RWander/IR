using System;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Register: ApiStepAsync
    {
        public Register(ApiProxy proxy) : base(proxy) { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var resObj = await POSTAsync("sandbox/register");

            if (resObj.IsOk)
            {
                Console.WriteLine($"{nameof(Register)} - OK.");
                return ExecutionResult.Outcome(true);
            }
            else
            {
                Console.WriteLine($"{nameof(Register)} - Fail.");
                return ExecutionResult.Persist(false);
            }
        }
    }
}
