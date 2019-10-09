using WorkflowCore.Interface;

using IR.Core.Domain;
using IR.Core.Step;
using Sandbox = IR.Core.Step.Sandbox;
using Market = IR.Core.Step.Market;

namespace IR.Core.Workflow
{
    public sealed class MagicFlow : IWorkflow<MagicStore>
    {
        public void Build(IWorkflowBuilder<MagicStore> builder)
        {
            builder
                .StartWith<Initialize>()
#if DEBUG
                .Then<Sandbox.Register>()
                .Then<Sandbox.SetCurrenciesBalance>()
                    .Input(
                        s => s.RequestBodyObj,
                        d => new Sandbox.SetCurrenciesBalance.RequestBody
                        {
                            Currency = "RUB",
                            Balance = 100000
                        }
                    )
#endif
                .Then<GetPortfolio>()
                    .Output(d => d.Portfolio, s => s.ResponsePayload)
#if DEBUG
                .Then<CreateLimitOrder>()
                    .Input(
                        s => s.Figi,
                        d => "BBG006L8G4H1" // YNDX
                    )
                    .Input(
                        s => s.RequestBodyObj,
                        d => new CreateLimitOrder.RequestBody
                        {
                            Lots = 5,
                            Operation = "Buy",
                            Price = 2300
                        }
                    )
                .Then<GetPortfolio>()
                    .Output(d => d.Portfolio, s => s.ResponsePayload)
#endif
                //.Then<Market.GetStocks>()
                //    .Output(d => d.Stocks, s => s.Stocks)
                .Then<RunWatchers>()
                    .Output(d => d.Candles, s => s.Candles)
#if DEBUG
                .Then<Sandbox.Clear>()
#endif
                .Then<Finalize>();
        }

        public string Id => nameof(MagicFlow);

        public int Version => 1;
    }
}