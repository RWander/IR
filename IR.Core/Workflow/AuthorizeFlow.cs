using WorkflowCore.Interface;

using IR.Core.Step;

namespace IR.Core.Workflow
{
    public sealed class AuthorizeFlow : IWorkflow
    {
        public string Id => nameof(AuthorizeFlow);

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<Authorize>()
                .Then<GetOrders>();
        }
    }
}