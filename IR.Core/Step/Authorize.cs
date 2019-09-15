using System;

using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace IR.Core.Step
{
    internal sealed class Authorize : ApiStep
    {
        // public Authorize(ApiProxy proxy) : base(proxy)
        // {
        // }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // ..
            Console.WriteLine("Authorize - OK.");
            return ExecutionResult.Next();
        }
    }
}