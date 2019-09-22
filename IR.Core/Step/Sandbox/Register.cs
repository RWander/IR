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

            // TODO: get orders logic is here
            // ..

            Console.WriteLine("Register - OK.");
            return ExecutionResult.Next();
        }
    }
}
