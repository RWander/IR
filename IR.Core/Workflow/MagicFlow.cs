using WorkflowCore.Interface;
using WorkflowCore.Models;

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
                .OnError(WorkflowErrorHandling.Terminate)
                .Then<CurrenciesBalance>()
#endif
                .Then<Authorize>()
                .Then<Finalize>();
        }

        public string Id => nameof(MagicFlow);

        public int Version => 1;
    }
}