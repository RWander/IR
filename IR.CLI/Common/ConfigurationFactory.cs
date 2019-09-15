using System;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

using IR.Core;

namespace IR.CLI.Common
{
    internal sealed class ConfigurationFactory: IConfigurationFactory
    {
        // /// <summary>
        // /// Use for ASP.NET Core Web applications.
        // /// </summary>
        // /// <param name="config"></param>
        // /// <param name="env"></param>
        // /// <returns></returns>
        // public static IConfigurationBuilder Configure(IConfigurationBuilder config, IHostingEnvironment env)
        // {
        //     return Configure(config, env.EnvironmentName);
        // }

        /// <summary>
        /// Use for .NET Core Console applications.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        private static IConfigurationBuilder Configure(IConfigurationBuilder config, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            return Configure(config, env.EnvironmentName);
        }

        private static IConfigurationBuilder Configure(IConfigurationBuilder config, string environmentName)
        {
            return config
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        /// <summary>
        /// Use for .NET Core Console applications.
        /// </summary>
        /// <returns></returns>
        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var env = new HostingEnvironment
                    {
                        EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                        ApplicationName = AppDomain.CurrentDomain.FriendlyName,
                        ContentRootPath = AppDomain.CurrentDomain.BaseDirectory,
                        ContentRootFileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory)
                    };

                    var config = new ConfigurationBuilder();
                    var configured = Configure(config, env);
                    _config = configured.Build();
                }
                return _config;
            }
        }
        private IConfiguration _config;
    }
}