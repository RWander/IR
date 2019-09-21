using System;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class GetOrders : ApiStep
    {
        public GetOrders(ApiProxy proxy) : base(proxy) { }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // ..
            Console.WriteLine("GetOrders - OK.");
            return ExecutionResult.Next();
        }
    }
}