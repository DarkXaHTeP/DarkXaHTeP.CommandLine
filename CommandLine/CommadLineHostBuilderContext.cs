using Microsoft.Extensions.Configuration;

namespace DarkXaHTeP.CommandLine
{
    public class CommandLineHostBuilderContext
    {
        internal CommandLineHostBuilderContext() {}
        
        public ICommandLineEnvironment CommandLineEnvironment { get; set; }
        public IConfiguration Configuration { get; set; }
    }
}