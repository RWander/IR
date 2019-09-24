using System;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class Initialize : ApiStepAsync
    {
        public Initialize(ApiProxy proxy) : base(proxy) { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            // ..
            Console.WriteLine($"{nameof(Initialize)} - OK.");
            return ExecutionResult.Next();
        }
    }
}