using System;
using Microsoft.Extensions.DependencyInjection;

using WorkflowCore.Interface;

using IR.Core.Workflow;
using IR.Core.Common;
using IR.Core.Workflow.Sandbox;

namespace IR.CLI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // start the workflow host
            var host = ServiceProviderHolder.Instance.GetService<IWorkflowHost>();
            host.RegisterWorkflow<AuthorizeFlow>();

#if DEBUG
            host.RegisterWorkflow<SandboxInitFlow>();
            host.RegisterWorkflow<SandboxClearFlow>();
            host.Start();

            host.StartWorkflow(nameof(SandboxInitFlow));
#endif

            host.StartWorkflow(nameof(AuthorizeFlow));
            
            Console.ReadLine();
#if DEBUG
            host.StartWorkflow(nameof(SandboxClearFlow));
#endif
            host.Stop();
        }
    }
}
