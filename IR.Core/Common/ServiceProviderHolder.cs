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
            services.AddTransient<Step.Authorize>();
            services.AddTransient<Step.GetOrders>();
#if DEBUG
            services.AddTransient<Step.Sandbox.Register>();
            services.AddTransient<Step.Sandbox.CurrenciesBalance>();
            services.AddTransient<Step.Sandbox.Clear>();
#endif

            Instance = services.BuildServiceProvider();
        }
    }
}
