using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CommandLine.Test
{
    public class ConstructorInjectionStartup
    {
        public static string Environment;
        
        private readonly ICommandLineEnvironment _commandLineEnvironment;

        public ConstructorInjectionStartup(ICommandLineEnvironment commandLineEnvironment)
        {
            _commandLineEnvironment = commandLineEnvironment;
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            Environment = _commandLineEnvironment.EnvironmentName;
        }
    }
    
    public class ConfigureInjectionStartup
    {
        public static string Environment;

        public void Configure(IApplicationBuilder applicationBuilder, ICommandLineEnvironment commandLineEnvironment)
        {
            Environment = commandLineEnvironment.EnvironmentName;
        }
    }

    public interface IService
    {
        string GetTestValue();
    }

    public class Service : IService
    {
        public string GetTestValue()
        {
            return "test";
        }
    }

    public class CustomServicesInjectionStartup
    {
        public static string TestValue;

        public void Configure(IApplicationBuilder applicationBuilder, IService service)
        {
            TestValue = service.GetTestValue();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IService, Service>();
        }
    }
    
    public class StartupDependencyInjectionTest
    {
        [Fact]
        public void InjectsDepenenciesInConstructor()
        {
            new CommandLineHostBuilder()
                .UseStartup<ConstructorInjectionStartup>()
                .Build();
            
            Assert.Equal("Production", ConstructorInjectionStartup.Environment);
        }
        
        [Fact]
        public void InjectsDepenenciesInConfigure()
        {
            new CommandLineHostBuilder()
                .UseStartup<ConfigureInjectionStartup>()
                .Build();
            
            Assert.Equal("Production", ConfigureInjectionStartup.Environment);
        }
        
        [Fact]
        public void InjectsCustomDepenenciesInConfigure()
        {
            new CommandLineHostBuilder()
                .UseStartup<CustomServicesInjectionStartup>()
                .Build();
            
            Assert.Equal("test", CustomServicesInjectionStartup.TestValue);
        }
    }
}
