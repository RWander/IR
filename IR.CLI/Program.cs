using System;

using Microsoft.Extensions.DependencyInjection;

using WorkflowCore.Models.LifeCycleEvents;
using WorkflowCore.Interface;
using WorkflowCore.Models;

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
            host.OnStepError += Host_OnStepError;
            host.OnLifeCycleEvent += Host_OnLifeCycleEvent;
            host.RegisterWorkflow<MagicFlow, MagicStore>();
            host.Start();

            host.StartWorkflow(nameof(MagicFlow));
            
            Console.ReadLine();
            host.Stop();
        }

        private static void Host_OnLifeCycleEvent(LifeCycleEvent evt)
        {
            // TODO: logging
            // ..

            Console.WriteLine($"{evt.EventTimeUtc}, {evt.GetType().Name}");
        }

        private static void Host_OnStepError(WorkflowInstance workflow, WorkflowStep step, Exception exception)
        {
            // TODO: logging
            // ..

            Console.WriteLine($"Error in {workflow.WorkflowDefinitionId} in the {step.Name} step: exception {exception}");
        }
    }
}
