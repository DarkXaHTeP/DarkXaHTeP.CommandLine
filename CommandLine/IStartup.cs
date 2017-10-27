using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLine
{
    public interface IStartup
    {
        void Configure(CommandLineApplication app);
        void ConfigureServices(IServiceCollection services);
    }
}
