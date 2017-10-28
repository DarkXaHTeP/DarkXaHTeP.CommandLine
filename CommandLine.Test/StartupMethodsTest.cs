using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DarkXaHTeP.CommandLine.Test
{
    class InterfaceStartup: IStartup
    {
        public static bool ExecutedConfigure;
        public static bool ExecutedConfigureServices;
        
        public void Configure(IApplicationBuilder app)
        {
            ExecutedConfigure = true;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ExecutedConfigureServices = true;
        }
    }
    
    class ConventionStartup
    {
        public static bool ExecutedConfigure;
        public static bool ExecutedConfigureServices;
        
        public void Configure(IApplicationBuilder app)
        {
            ExecutedConfigure = true;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ExecutedConfigureServices = true;
        }
    }

    class NoServicesStartup
    {
        public static bool ExecutedConfigure;
        
        public void Configure(IApplicationBuilder app)
        {
            ExecutedConfigure = true;
        }
    }
    
    public class StartupMethodsTest
    {
        [Fact]
        public void ExecutesConfigureAndConfigureServicesForInterfaceBasedStartup()
        {
            new CommandLineHostBuilder()
                .UseStartup<InterfaceStartup>()
                .Build();
            
            Assert.True(InterfaceStartup.ExecutedConfigure);
            Assert.True(InterfaceStartup.ExecutedConfigureServices);
        }
        
        [Fact]
        public void ExecutesConfigureAndConfigureServicesForConventionBasedStartup()
        {
            new CommandLineHostBuilder()
                .UseStartup<ConventionStartup>()
                .Build();
            
            Assert.True(ConventionStartup.ExecutedConfigure);
            Assert.True(ConventionStartup.ExecutedConfigureServices);
        }
        
        [Fact]
        public void ExecutesConfigureForStartupWithoutServices()
        {
            new CommandLineHostBuilder()
                .UseStartup<NoServicesStartup>()
                .Build();
            
            Assert.True(NoServicesStartup.ExecutedConfigure);
        }
    }
}