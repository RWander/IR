using System;

using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace IR.Core.Step
{
    internal sealed class Authorize : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // ..
            Console.WriteLine("Authorize - OK.");
            return ExecutionResult.Next();
        }
    }
}