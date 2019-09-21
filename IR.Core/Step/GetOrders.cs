using System;
using System.Collections.Generic;
using System.Net.Http;
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
            // TODO: logging

            IEnumerable<Order> orders;
            try
            {
                orders = await Proxy.GetAsync<IEnumerable<Order>>("TODO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("GetOrders - OK.");

            return ExecutionResult.Next();
        }
    }

    public sealed class Order
    {

    }
}