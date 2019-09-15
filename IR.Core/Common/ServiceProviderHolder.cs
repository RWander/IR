using System;
using Microsoft.Extensions.DependencyInjection;

namespace IR.Core.Common
{
    public static class ServiceProviderHolder 
    {
        public static IServiceProvider Instance { get; private set; }

        static ServiceProviderHolder()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(); // TODO: add logging (?)
            services.AddWorkflow();
            services.AddSingleton<IConfigurationFactory, ConfigurationFactory>();
            services.AddSingleton<ApiProxy>();

            Instance = services.BuildServiceProvider();
        }
    }
}
