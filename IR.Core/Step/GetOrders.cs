using System;

using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace IR.Core.Step
{
    internal sealed class GetOrders : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // ..
            Console.WriteLine("GetOrders - OK.");
            return ExecutionResult.Next();
        }
    }
}