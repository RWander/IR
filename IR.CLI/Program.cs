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
            host.RegisterWorkflow<AuthorizeFlow>();        
            host.Start();        

            host.StartWorkflow("Authorize");
            
            Console.ReadLine();
            host.Stop();
        }
    }
}
