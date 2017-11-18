# DarkXaHTeP.CommandLine

Allows creating CommandLine applications using Microsoft.Extensions.CommandLineUtils together with DI, Configuration and Logging in a convenient way similar to AspNetCore Hosting.

#### NuGet

[![NuGet Version](https://img.shields.io/nuget/v/DarkXaHTeP.CommandLine.svg)](https://www.nuget.org/packages/DarkXaHTeP.CommandLine/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/DarkXaHTeP.CommandLine.svg)](https://www.nuget.org/packages/DarkXaHTeP.CommandLine/)

#### Build

[![Travis build](https://img.shields.io/travis/DarkXaHTeP/DarkXaHTeP.CommandLine/master.svg)](https://travis-ci.org/DarkXaHTeP/DarkXaHTeP.CommandLine)
[![Coverage report](https://img.shields.io/coveralls/github/DarkXaHTeP/DarkXaHTeP.CommandLine.svg)](https://coveralls.io/github/DarkXaHTeP/DarkXaHTeP.CommandLine)

## Getting Started

To use the library you need to go through 2 simple steps:

Define Startup class similar to Asp.Net Core:

```c#
public class Startup
{   
    public void Configure(IApplicationBuilder builder)
    {
        builder.OnExecute(async () =>
        {
            Console.WriteLine("Hello World")
            return 0;
        });
    }
}
```

Create CommandLine Host using CommandLineHostBuilder and run it:

```c#
static class Program
{
    static int Main(string[] args)
    {
        ICommandLineHost host = new CommandLineHostBuilder()
            .UseStartup<Startup>()
            .Build();

        return host.Run(args);
    }
}
```

The application will print "Hello World" to console output and exit with 0 code.

## Startup class

TBD

## IApplicationBuilder interface

TBD

## App Configuration and Logging

TBD

## Dependency Injection

TBD

## Acknowledgements

This library is highly inspired by [AspNet.Core Hosting](https://github.com/aspnet/Hosting/tree/rel/2.0.0) from Microsoft

## Contribution

Feel free to ask questions and post bugs/ideas in the issues, as well as send pull requests.

[![License](https://img.shields.io/github/license/darkxahtep/DarkXaHTeP.CommandLine.svg)](https://github.com/DarkXaHTeP/DarkXaHTeP.CommandLine/blob/master/LICENSE)