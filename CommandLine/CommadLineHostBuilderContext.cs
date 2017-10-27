using Microsoft.Extensions.Configuration;

namespace CommandLine
{
    public class CommandLineHostBuilderContext
    {
        public ICommandLineEnvironment CommandLineEnvironment { get; set; }
        public IConfiguration Configuration { get; set; }
    }
}