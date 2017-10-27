using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CommandLine.Test
{
    interface IService
    {
        string getValue();
    }

    class Service : IService
    {
        public string getValue()
        {
            return "value";
        }
    }
    
    class Startup: IStartup
    {
        public static bool Executed = false;
        
        public void Configure(CommandLineApplication app)
        {
            app.OnExecute(() =>
            {
                Executed = true;
                return 0;
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IService, Service>();
        }
    }
    
    public class CommandLineApplicationTest
    {
        [Fact]
        public void ExecutesSimplestApplication()
        {
            var host = new CommandLineHostBuilder()
                .UseStartup<Startup>()
                .Build();

            host.Run(new string[] { });
            
            Assert.True(Startup.Executed);
        }
    }
}