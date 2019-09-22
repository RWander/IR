using WorkflowCore.Interface;

using IR.Core.Step.Sandbox;

namespace IR.Core.Workflow.Sandbox
{
    public sealed class SandboxInitFlow: IWorkflow
    {
        public string Id => nameof(SandboxInitFlow);

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<Register>()
                .Then<CurrenciesBalance>();
        }
    }
}
