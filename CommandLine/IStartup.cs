using Microsoft.Extensions.DependencyInjection;

namespace CommandLine
{
    public interface IStartup
    {
        void Configure(IApplicationBuilder app);
        void ConfigureServices(IServiceCollection services);
    }
}
