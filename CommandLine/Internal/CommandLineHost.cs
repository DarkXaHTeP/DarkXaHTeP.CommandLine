using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace DarkXaHTeP.CommandLine.Internal
{
    public class CommandLineHost : ICommandLineHost
    {
        private readonly ServiceCollection _services;
        private readonly bool _allowUnexpectedArgs;
        private readonly ServiceProvider _serviceProvider;
        private IStartup _startup;
        private CommandLineApplication _commandLineApp;

        public CommandLineHost(ServiceCollection services, bool allowUnexpectedArgs)
        {
            _services = services;
            _serviceProvider = services.BuildServiceProvider();
            _allowUnexpectedArgs = allowUnexpectedArgs;
        }

        public void Initialize()
        {
            EnsureStartup();
            _commandLineApp = new CommandLineApplication(_allowUnexpectedArgs);
            
            _startup.ConfigureServices(_services);
            _startup.Configure(new ApplicationBuilder(_services.BuildServiceProvider(), _commandLineApp));
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