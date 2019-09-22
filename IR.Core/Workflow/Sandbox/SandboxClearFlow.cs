using WorkflowCore.Interface;

using IR.Core.Step.Sandbox;

namespace IR.Core.Workflow.Sandbox
{
    public sealed class SandboxClearFlow: IWorkflow
    {
        public string Id => nameof(SandboxClearFlow);

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<Clear>();
        }
    }
}
