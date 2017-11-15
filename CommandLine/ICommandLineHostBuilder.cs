using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DarkXaHTeP.CommandLine
{
    public interface ICommandLineHostBuilder
    {
        ICommandLineHostBuilder ConfigureAppConfiguration(Action<IConfigurationBuilder> configureDelegate);
        ICommandLineHostBuilder ConfigureAppConfiguration(Action<CommandLineHostBuilderContext, IConfigurationBuilder> configureDelegate);
        ICommandLineHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);
        ICommandLineHostBuilder ConfigureServices(Action<CommandLineHostBuilderContext, IServiceCollection> configureServices);
        ICommandLineHostBuilder ConfigureLogging(Action<ILoggingBuilder> configureLogging);
        ICommandLineHostBuilder ConfigureLogging(Action<CommandLineHostBuilderContext, ILoggingBuilder> configureLogging);
        ICommandLineHostBuilder UseStartup<TStartup>() where TStartup : class;
        ICommandLineHostBuilder AllowUnexpectedArgs();
        ICommandLineHost Build();
    }
}