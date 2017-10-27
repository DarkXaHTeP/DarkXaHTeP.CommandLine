using System;

namespace CommandLine
{
    public interface IApplicationBuilder
    {
        IServiceProvider ApplicationServices { get; }
        string Description { get; set; }
    }
}