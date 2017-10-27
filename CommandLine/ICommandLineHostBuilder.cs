using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLine
{
    public interface ICommandLineHostBuilder
    {
        ICommandLineHostBuilder ConfigureAppConfiguration(Action<IConfigurationBuilder> configureDelegate);
        ICommandLineHostBuilder ConfigureAppConfiguration(Action<CommandLineHostBuilderContext, IConfigurationBuilder> configureDelegate);
        ICommandLineHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);
        ICommandLineHostBuilder ConfigureServices(Action<CommandLineHostBuilderContext, IServiceCollection> configureServices);
        ICommandLineHostBuilder UseStartup<TStartup>() where TStartup : class, IStartup;
        ICommandLineHostBuilder AllowUnexpectedArgs();
        ICommandLineHost Build();
    }
}