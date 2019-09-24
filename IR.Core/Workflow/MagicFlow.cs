using WorkflowCore.Interface;

using IR.Core.Domain;
using IR.Core.Step;

namespace IR.Core.Workflow
{
    public sealed class MagicFlow : IWorkflow<MagicStore>
    {
        public void Build(IWorkflowBuilder<MagicStore> builder)
        {
            builder
                .StartWith<Authorize>()
                .Then<GetOrders>();
        }

        public string Id => nameof(MagicFlow);

        public int Version => 1;
    }
}