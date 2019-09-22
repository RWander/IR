using System;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class GetOrders : ApiStepAsync
    {
        public GetOrders(ApiProxy proxy) : base(proxy) { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var resObj = await GETAsync("orders");

            // TODO: get orders logic is here
            // ..
            
            Console.WriteLine("GetOrders - OK.");

            return ExecutionResult.Next();
        }
    }
}