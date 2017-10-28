using Microsoft.Extensions.DependencyInjection;

namespace DarkXaHTeP.CommandLine
{
    public interface IStartup
    {
        void Configure(IApplicationBuilder app);
        void ConfigureServices(IServiceCollection services);
    }
}
