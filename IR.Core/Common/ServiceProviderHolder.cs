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
            services.AddTransient<ApiProxy>();

            // TODO: refactoring: reflection on the 'Step' folder.
            services.AddSingleton<Step.Authorize>();
            services.AddSingleton<Step.GetOrders>();
#if DEBUG
            services.AddSingleton<Step.Sandbox.Register>();
            services.AddSingleton<Step.Sandbox.CurrenciesBalance>();
            services.AddSingleton<Step.Sandbox.Clear>();
#endif

            Instance = services.BuildServiceProvider();
        }
    }
}
