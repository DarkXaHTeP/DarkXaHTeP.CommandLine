﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace DarkXaHTeP.CommandLine.Internal
{
    internal class ApplicationBuilder: IApplicationBuilder
    {
        private readonly CommandLineApplication _commandLineApp;

        public ApplicationBuilder(IServiceProvider serviceProvider, CommandLineApplication commandLineApp, IApplicationBuilder parent = null)
        {
            _commandLineApp = commandLineApp;
            ApplicationServices = serviceProvider;
            Parent = parent;
        }
        
        public IServiceProvider ApplicationServices { get; }
        public IApplicationBuilder Parent { get; }

        public ICommandArgument Argument(string name, string description, bool multipleValues = false)
        {
            return new CommandLineArgument(_commandLineApp.Argument(name, description, multipleValues));
        }

        public IApplicationBuilder Command(
            string name,
            Action<IApplicationBuilder> configure,
            bool throwOnUnexpectedArg = true)
        {
            Action<CommandLineApplication> configureAction = commandLineApp =>
                configure(new ApplicationBuilder(ApplicationServices, commandLineApp, this));
            var command = _commandLineApp.Command(name, configureAction, throwOnUnexpectedArg);

            return new ApplicationBuilder(ApplicationServices, command, this);
        }

        public void OnExecute(Func<Task<int>> invoke)
        {
            _commandLineApp.OnExecute(invoke);
        }

        public void OnExecute(Func<int> invoke)
        {
            _commandLineApp.OnExecute(invoke);
        }

        public ICommandOption Option(string template, string description, CommandLineOptionType optionType)
        {
            return new CommandLineOption(_commandLineApp.Option(template, description, optionType.ToCommandOptionType()));
        }

        public void ShowHelp(string commandName = null)
        {
            _commandLineApp.ShowHelp(commandName);
        }
    }
}