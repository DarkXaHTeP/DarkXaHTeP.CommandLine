using System;

namespace CommandLine
{
    public interface IApplicationBuilder
    {
        IServiceProvider ApplicationServices { get; }
        
    }
}