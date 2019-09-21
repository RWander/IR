using System;
using Microsoft.Extensions.DependencyInjection;

namespace IR.Core.Common
{
    public static class ServiceProviderHolder 
    {
        public static IServiceProvider Instance { get; }

        static ServiceProviderHolder()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(); // TODO: add logging (?)
            services.AddWorkflow();
            services.AddSingleton<IConfigurationFactory, ConfigurationFactory>();
            services.AddSingleton<ApiProxy>();

            // TODO: refactoring: reflection on the 'Step' folder.
            services.AddSingleton<Step.Authorize>();
            services.AddSingleton<Step.GetOrders>();

            Instance = services.BuildServiceProvider();
        }
    }
}
