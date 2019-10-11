using System;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class Finalize : RestStepAsync
    {
        protected override bool EmptyResponsePayload { get; } = true;

        public Finalize(RestProxy proxy) : base(proxy) { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            // TODO
            // ..
            Console.WriteLine("Good buy!");
            await Task.Run(() =>
            {
                Console.WriteLine($"{nameof(Finalize)} - OK.");
            });

            return ExecutionResult.Next();
        }
    }
}