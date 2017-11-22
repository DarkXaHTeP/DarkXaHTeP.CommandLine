using System;
using Microsoft.Extensions.CommandLineUtils;

namespace DarkXaHTeP.CommandLine
{
    public interface IApplicationBuilder
    {
        IServiceProvider ApplicationServices { get; }
        IApplicationBuilder Parent { get; }
        CommandArgument Argument(string name, string description, bool multipleValues = false);
        IApplicationBuilder Command (string name, Action<IApplicationBuilder> configure, bool throwOnUnexpectedArg = true);
        void OnExecute (Func<System.Threading.Tasks.Task<int>> invoke);
        void OnExecute (Func<int> invoke);
        ICommandOption Option (string template, string description, CommandLineOptionType optionType);
        void ShowHelp (string commandName = null);
    }
}