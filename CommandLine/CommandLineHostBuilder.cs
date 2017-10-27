using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLine
{
    public class CommandLineHostBuilder: ICommandLineHostBuilder
    {
        private readonly List<Action<CommandLineHostBuilderContext, IConfigurationBuilder>> _configureAppConfigurationBuilderDelegates;
        private readonly List<Action<CommandLineHostBuilderContext, IServiceCollection>> _configureServicesDelegates;
        private bool _commandLineHostBuilt = false;
        private readonly IConfiguration _config;
        private readonly ICommandLineEnvironment _commandLineEnvironment;
        private readonly CommandLineHostBuilderContext _context;
        private bool _allowUnexpectedArgs = false;

        public CommandLineHostBuilder()
        {
            _configureAppConfigurationBuilderDelegates = new List<Action<CommandLineHostBuilderContext, IConfigurationBuilder>>();
            _configureServicesDelegates = new List<Action<CommandLineHostBuilderContext, IServiceCollection>>();
            _config = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "COMMANDLINE_")
                .Build();
            
            _commandLineEnvironment = new CommandLineEnvironment(_config["COMMANDLINE_ENVIRONMENT"]);


            _context = new CommandLineHostBuilderContext
            {
                CommandLineEnvironment = _commandLineEnvironment,
                Configuration = _config
            };
        }
        
        public ICommandLineHostBuilder ConfigureAppConfiguration(Action<IConfigurationBuilder> configureDelegate)
        {
            ConfigureAppConfiguration((_, config) => configureDelegate(config));
            
            return this;
        }

        public ICommandLineHostBuilder ConfigureAppConfiguration(Action<CommandLineHostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            _configureAppConfigurationBuilderDelegates.Add(configureDelegate);

            return this;
        }

        public ICommandLineHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            ConfigureServices((_, services) => configureServices(services));

            return this;
        }

        public ICommandLineHostBuilder ConfigureServices(Action<CommandLineHostBuilderContext, IServiceCollection> configureServices)
        {
            _configureServicesDelegates.Add(configureServices);

            return this;
        }

        public ICommandLineHostBuilder UseStartup<TStartup>() where TStartup : class
        {
            var startupType = typeof(TStartup);

            this.ConfigureServices(services =>
            {
                {
                    if (typeof(IStartup).GetTypeInfo().IsAssignableFrom(startupType.GetTypeInfo()))
                    {
                        services.AddSingleton(typeof(IStartup), startupType);
                    }
                    else
                    {
                        services.AddSingleton(
                            typeof(IStartup),
                            sp => new ConventionBasedStartup(
                                StartupLoader.LoadMethods(
                                    sp,
                                    startupType,
                                    _commandLineEnvironment.EnvironmentName
                                )
                            )
                        );
                    }
                }
            });

            return this;
        }

        public ICommandLineHostBuilder AllowUnexpectedArgs()
        {
            _allowUnexpectedArgs = true;

            return this;
        }

        public ICommandLineHost Build()
        {
            if (_commandLineHostBuilt)
            {
                throw new InvalidOperationException("CommandLineHostBuilder allows creation only of a single instance of CommandLineHost");
            }

            _commandLineHostBuilt = true;
            
            var services = new ServiceCollection();
            services.AddSingleton(_commandLineEnvironment);
            services.AddSingleton(_context);
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(_commandLineEnvironment.ContentRootPath)
                .AddInMemoryCollection(_config.AsEnumerable());

            foreach (var configureAppConfiguration in _configureAppConfigurationBuilderDelegates)
            {
                configureAppConfiguration(_context, builder);
            }

            var configuration = builder.Build();
            services.AddSingleton<IConfiguration>(configuration);
            _context.Configuration = configuration;
            
            services.AddOptions();
            services.AddLogging();
            
            foreach (var configureServices in _configureServicesDelegates)
            {
                configureServices(_context, services);
            }

            var host = new CommandLineHost(services, _config, _allowUnexpectedArgs);
            host.Initialize();

            return host;
        }
    }
}