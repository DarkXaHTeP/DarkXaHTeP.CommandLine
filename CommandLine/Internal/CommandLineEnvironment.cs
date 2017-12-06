using System.IO;
using System.Reflection;

namespace DarkXaHTeP.CommandLine.Internal
{
    internal class CommandLineEnvironment: ICommandLineEnvironment
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

            ContentRootPath = Directory.GetCurrentDirectory();
        }

        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string ContentRootPath { get; set; }
        public bool IsDevelopment()
        {
            return EnvironmentName == CommandLine.EnvironmentName.Development;
        }

        public bool IsStaging()
        {
            return EnvironmentName == CommandLine.EnvironmentName.Staging;
        }

        public bool IsProduction()
        {
            return EnvironmentName == CommandLine.EnvironmentName.Production;
        }
    }
}
