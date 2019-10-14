using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using WorkflowCore.Models;
using WorkflowCore.Interface;

using IR.Core.Domain;
using IR.Core.Common;
using IR.Core.Streaming;

namespace IR.Core.Step
{

    internal sealed class RunWatchers : WsStepAsync
    {
        public IList<Candle> Candles { get; set; }

        public RunWatchers(WsProxy proxy) : base(proxy)
        { }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var req = StreamingRequest.SubscribeCandle(
                "BBG006L8G4H1" /* YNDX */,
                CandleInterval.Minute()
            );
            await Proxy.SendStreamingRequestAsync(req);

            Console.WriteLine($"{nameof(RunWatchers)} - OK.");

            return ExecutionResult.Next();
        }
    }
}
