using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLine
{
    public class CommandLineHost : ICommandLineHost
    {
        private readonly ServiceCollection _services;
        private readonly IConfiguration _config;
        private readonly bool _allowUnexpectedArgs;
        private readonly ServiceProvider _serviceProvider;
        private IStartup _startup;
        private CommandLineApplication _commandLineApp;

        public CommandLineHost(ServiceCollection services, IConfiguration config, bool allowUnexpectedArgs)
        {
            _services = services;
            _serviceProvider = services.BuildServiceProvider();
            _config = config;
            _allowUnexpectedArgs = allowUnexpectedArgs;
        }

        public void Initialize()
        {
            EnsureStartup();
            _commandLineApp = new CommandLineApplication(_allowUnexpectedArgs);
            
            _startup.ConfigureServices(_services);
            _startup.Configure(_commandLineApp);
        }
        
        public int Run(string[] args)
        {
            return _commandLineApp.Execute(args);
        }
        
        private void EnsureStartup()
        {
            if (_startup != null)
            {
                return;
            }

            _startup = _serviceProvider.GetService<IStartup>();

            if (_startup == null)
            {
                throw new InvalidOperationException($"No startup configured. Please specify startup via CommandLineHostBuilder.UseStartup.");
            }
        }
    }
}