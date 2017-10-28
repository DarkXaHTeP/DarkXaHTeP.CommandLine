namespace DarkXaHTeP.CommandLine
{
    public interface ICommandLineEnvironment
    {
        string EnvironmentName { get; }
        string ApplicationName { get; }
        string ContentRootPath { get; }
    }
}