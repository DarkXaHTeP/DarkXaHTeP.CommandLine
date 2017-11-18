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

Same as Asp.Net Core Startup, CommandLine Startup can have two methods:

`void Configure(IApplicationBuilder app)` is required. This is where application
arguments and commands configuration happens using IApplicationBuilder.

`void ConfigureServices(IServiceCollection services)` is optional. Allows configuring Dependency Injection
by providing access to application's IServiceCollection. This method is invoked prior to `Configure`

## IApplicationBuilder interface

This interface provides a set of methods for configuring application. These methods are similar to provided by
Microsoft.Extensions.CommandLineUtils (actually this library uses CommandLineUtils internally,
however this may change in future due to the fact that CommandLineUtils is no longer supported).

```c#
IServiceProvider ApplicationServices { get; }
```
gives access to services registered in application

```c#
IApplicationBuilder Parent { get; }
```
contains link to parent IApplicationBuilder. Is null for the root builder

```c#
CommandArgument Argument(string name, string description, bool multipleValues = false);
```
allows to define command argument

```c#
IApplicationBuilder Command (string name, Action<IApplicationBuilder> configure, bool throwOnUnexpectedArg = true);
```
allows to define command

```c#
void OnExecute (Func<System.Threading.Tasks.Task<int>> invoke);
void OnExecute (Func<int> invoke);
```
allows to define root or command execution callback

```c#
CommandOption Option (string template, string description, CommandOptionType optionType);
```
allows to define option

```c#
void ShowHelp (string commandName = null);
```
shows help for the particular command or a whole app. Could be used in execute callbacks

## CommandLineHostBuilder class

TBD

## Dependency Injection

TBD

## Acknowledgements

This library is highly inspired by [AspNet.Core Hosting](https://github.com/aspnet/Hosting/tree/rel/2.0.0) from Microsoft

## Contribution

Feel free to ask questions and post bugs/ideas in the issues, as well as send pull requests.

[![License](https://img.shields.io/github/license/darkxahtep/DarkXaHTeP.CommandLine.svg)](https://github.com/DarkXaHTeP/DarkXaHTeP.CommandLine/blob/master/LICENSE)