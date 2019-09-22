using WorkflowCore.Interface;

namespace IR.Core.Workflow.Sandbox
{
    internal sealed class SandboxInitFlow: IWorkflow
    {
        public string Id => nameof(SandboxInitFlow);

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            // TODO: SandboxInitFlow logic
            // .. 

            //builder
            //    .StartWith<Authorize>()
            //    .Then<GetOrders>();
        }
    }
}
