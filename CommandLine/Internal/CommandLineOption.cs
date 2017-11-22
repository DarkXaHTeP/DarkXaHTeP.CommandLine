using System.Collections.Generic;
using Microsoft.Extensions.CommandLineUtils;

namespace DarkXaHTeP.CommandLine.Internal
{
    internal class CommandLineOption: ICommandOption
    {
        private readonly CommandOption _commandOption;

        internal CommandLineOption(CommandOption commandOption)
        {
            _commandOption = commandOption;
        }

        public string Template
        {
            get => _commandOption.Template;
            set => _commandOption.Template = value;
        }

        public string ShortName
        {
            get => _commandOption.ShortName;
            set => _commandOption.ShortName = value;
        }
        
        public string LongName
        {
            get => _commandOption.LongName;
            set => _commandOption.LongName = value;
        }
        
        public string SymbolName
        {
            get => _commandOption.SymbolName;
            set => _commandOption.SymbolName = value;
        }
        
        public string ValueName
        {
            get => _commandOption.ValueName;
            set => _commandOption.ValueName = value;
        }
        
        public string Description
        {
            get => _commandOption.Description;
            set => _commandOption.Description = value;
        }
        
        public CommandLineOptionType OptionType => _commandOption.OptionType.ToCommandLineOptionType();

        public List<string> Values => _commandOption.Values;
        
        public bool HasValue()
        {
            return _commandOption.HasValue();
        }

        public string Value()
        {
            return _commandOption.Value();
        }
    }
}