using System;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class Initialize : RestStepAsync
    {
        protected override bool EmptyResponsePayload { get; } = true;

        public Initialize(RestProxy proxy) : base(proxy) { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            // TODO
            // ..

            await Task.Run(() =>
            {
                Console.WriteLine($"{nameof(Initialize)} - OK.");
            });

            return ExecutionResult.Next();
        }
    }
}