using System;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class CurrenciesBalance: ApiStepAsync
    {
        public CurrenciesBalance(ApiProxy proxy) : base(proxy) { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            // ..
            Console.WriteLine($"{nameof(CurrenciesBalance)} - OK.");
            return ExecutionResult.Next();
        }
    }
}
