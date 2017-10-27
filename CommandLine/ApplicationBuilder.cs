using System;
using Microsoft.Extensions.CommandLineUtils;

namespace CommandLine
{
    public class ApplicationBuilder: IApplicationBuilder
    {
        private readonly CommandLineApplication _commandLineApp;

        public ApplicationBuilder(IServiceProvider serviceProvider, CommandLineApplication commandLineApp, IApplicationBuilder parent = null)
        {
            _commandLineApp = commandLineApp;
            ApplicationServices = serviceProvider;
            Parent = parent;
        }
        
        public IServiceProvider ApplicationServices { get; }
        public IApplicationBuilder Parent { get; }
    }
}