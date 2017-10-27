namespace CommandLine
{
    public interface ICommandLineEnvironment
    {
        string EnvironmentName { get; set; }
        string ApplicationName { get; set; }
        string ContentRootPath { get; set; }
    }
}