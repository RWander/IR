using System;
using Microsoft.Extensions.DependencyInjection;

using WorkflowCore.Interface;

using IR.Core.Workflow;
using IR.Core.Common;

namespace IR.CLI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // start the workflow host
            var host = ServiceProviderHolder.Instance.GetService<IWorkflowHost>();

#if DEBUG
            // TODO: prepare sandbox
            // ..
#endif

            host.RegisterWorkflow<AuthorizeFlow>();        
            host.Start();

            host.StartWorkflow(nameof(AuthorizeFlow));
            
            Console.ReadLine();
#if DEBUG
            // TODO: clear sandbox
            // ..
#endif
            host.Stop();
        }
    }
}
