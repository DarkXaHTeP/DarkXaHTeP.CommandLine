using System.IO;
using System.Reflection;

namespace CommandLine
{
    public class CommandLineEnvironment: ICommandLineEnvironment
    {
        public CommandLineEnvironment(string environment)
        {
            if (environment == CommandLine.EnvironmentName.Development ||
                environment == CommandLine.EnvironmentName.Staging)
            {
                EnvironmentName = environment;
            }
            else
            {
                EnvironmentName = CommandLine.EnvironmentName.Production;
            }

            ApplicationName = Assembly.GetEntryAssembly()?.GetName().Name;

            // TODO Add ability to override content root
            ContentRootPath = Directory.GetCurrentDirectory();
        }

        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string ContentRootPath { get; set; }
    }
}