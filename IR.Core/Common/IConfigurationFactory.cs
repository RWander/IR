using System.IO;
using Microsoft.Extensions.Configuration;

namespace IR.Core.Common
{
    public interface IConfigurationFactory
    {
        IConfiguration Configuration { get; }
    } 

    internal sealed class ConfigurationFactory: IConfigurationFactory
    {
        private static IConfigurationBuilder Configure(string envName)
        {
            const string name = "appsettings";
            const string ext = "json";

            var appSettings = string.IsNullOrEmpty(envName)
                ? $"{name}.{ext}"
                : $"{name}.{envName}.{ext}";

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettings, false, false);
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
                    var env = string.Empty; // empty env is release
#if DEBUG
                    env = "debug";
#endif
                    var configured = Configure(env);
                    _config = configured.Build();
                }
                return _config;
            }
        }
        private IConfiguration _config;
    }
}