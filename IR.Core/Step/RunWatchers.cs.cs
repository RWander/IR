using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using WorkflowCore.Models;
using WorkflowCore.Interface;

using IR.Core.Domain;
using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class RunWatchers : WsStepAsync
    {
        public IList<Candle> Candles { get; set; }

        public RunWatchers(WsProxy proxy) : base(proxy)
        { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            // TODO
            // ..

            await Task.Run(() =>
            {
                Console.WriteLine($"{nameof(RunWatchers)} - OK.");
            });

            return ExecutionResult.Next();
        }
    }
}
