using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;

namespace IR.Core.Workflow.Sandbox
{
    internal sealed class SandboxClearFlow
    {
        public string Id => nameof(SandboxClearFlow);

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            // TODO: SandboxClearFlow logic
            // .. 

            //builder
            //    .StartWith<Authorize>()
            //    .Then<GetOrders>();
        }
    }
}
