using System.Collections.Generic;
using Microsoft.Extensions.CommandLineUtils;

namespace DarkXaHTeP.CommandLine.Internal
{
    internal class CommandLineArgument: ICommandArgument
    {
        private readonly CommandArgument _argument;

        internal CommandLineArgument(CommandArgument argument)
        {
            _argument = argument;
        }

        public string Name
        {
            get => _argument.Name;
            set => _argument.Name = value;
        }
        
        public string Description
        {
            get => _argument.Description;
            set => _argument.Description = value;
        }
        
        public bool MultipleValues
        {
            get => _argument.MultipleValues;
            set => _argument.MultipleValues = value;
        }
        
        public List<string> Values => _argument.Values;

        public string Value => _argument.Value;
    }
}