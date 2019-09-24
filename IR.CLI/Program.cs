using System;

using Microsoft.Extensions.DependencyInjection;

using WorkflowCore.Interface;

using IR.Core.Workflow;
using IR.Core.Common;
using IR.Core.Domain;

namespace IR.CLI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // start the workflow host
            var host = ServiceProviderHolder.Instance.GetService<IWorkflowHost>();
            host.RegisterWorkflow<MagicFlow, MagicStore>();
            host.Start();

            host.StartWorkflow(nameof(MagicFlow));
            
            Console.ReadLine();
            host.Stop();
        }
    }
}
