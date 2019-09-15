using Microsoft.Extensions.Configuration;

namespace IR.Core
{
    public interface IConfigurationFactory
    {
        IConfiguration Configuration { get; }
    } 
}