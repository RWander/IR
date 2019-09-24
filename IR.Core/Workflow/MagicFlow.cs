using WorkflowCore.Interface;

using IR.Core.Domain;
using IR.Core.Step;
using IR.Core.Step.Sandbox;

namespace IR.Core.Workflow
{
    public sealed class MagicFlow : IWorkflow<MagicStore>
    {
        public void Build(IWorkflowBuilder<MagicStore> builder)
        {
            builder
                .StartWith<Initialize>()
#if DEBUG
                .Then<Register>()
                .Then<CurrenciesBalance>()
#endif
                .Then<Authorize>()
                .Then<Finalize>();
        }

        public string Id => nameof(MagicFlow);

        public int Version => 1;
    }
}