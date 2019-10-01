using WorkflowCore.Interface;

using IR.Core.Domain;

namespace IR.Core.Workflow
{
    public sealed class MagicFlow : IWorkflow<MagicStore>
    {
        public void Build(IWorkflowBuilder<MagicStore> builder)
        {
            builder
                .StartWith<Step.Initialize>()
#if DEBUG
                .Then<Step.Sandbox.Register>()
                .Then<Step.Sandbox.CurrenciesBalance>()
#endif
                .Then<Step.Authorize>()
                .Then<Step.GetPortfolio>()
                    .Output(data => data.Portfolio, step => step.Portfolio)
                .Then<Step.Market.GetStocks>()
                    .Output(data => data.Stocks, step => step.Stocks)
#if DEBUG
                .Then<Step.Sandbox.Clear>()
#endif
                .Then<Step.Finalize>();
        }

        public string Id => nameof(MagicFlow);

        public int Version => 1;
    }
}