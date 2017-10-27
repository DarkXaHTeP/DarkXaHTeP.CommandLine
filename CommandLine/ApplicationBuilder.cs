using System;
using Microsoft.Extensions.CommandLineUtils;

namespace CommandLine
{
    public class ApplicationBuilder: IApplicationBuilder
    {
        public ApplicationBuilder(IServiceProvider serviceProvider, CommandLineApplication commandLineApp)
        {
            ApplicationServices = serviceProvider;
        }
        
        public IServiceProvider ApplicationServices { get; }
        public string Description { get; set; }
    }
}