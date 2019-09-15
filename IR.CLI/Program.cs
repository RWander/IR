using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using WorkflowCore.Interface;

using IR.Core.Workflow;
using IR.CLI.Common;
using IR.Core;

namespace IR.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            // start the workflow host
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<AuthorizeFlow>();        
            host.Start();        

            host.StartWorkflow("Authorize");
            
            Console.ReadLine();
            host.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            // setup dependency injection
            IServiceCollection services = new ServiceCollection();            
            services.AddLogging(); // TODO: add logging (?)
            services.AddWorkflow();
            services.AddSingleton<IConfigurationFactory, ConfigurationFactory>();
            // services.AddTransient<GoodbyeWorld>();
            
            var serviceProvider = services.BuildServiceProvider();

            // config logging
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //loggerFactory.AddDebug();
            return serviceProvider;
        }
    }
}
