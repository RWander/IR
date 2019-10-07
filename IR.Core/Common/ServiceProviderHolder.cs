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
            services.AddSingleton<ApiProxy>(); // TODO: Transient or Singleton

            // TODO: refactoring: reflection on the 'Step' folder.
            services.AddTransient<Step.Initialize>();
            services.AddTransient<Step.Authorize>();
            services.AddTransient<Step.GetPortfolio>();
            services.AddTransient<Step.GetOperations>();
            services.AddTransient<Step.CreateLimitOrder>();
            services.AddTransient<Step.Finalize>();
#if DEBUG
            services.AddTransient<Step.Sandbox.Register>();
            services.AddTransient<Step.Sandbox.SetCurrenciesBalance>();
            services.AddTransient<Step.Sandbox.Clear>();
#endif
            services.AddTransient<Step.Market.GetStocks>();
            services.AddTransient<Step.RunWatchers>();

            Instance = services.BuildServiceProvider();
        }
    }
}
