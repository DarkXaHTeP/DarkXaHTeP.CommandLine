using Microsoft.Extensions.CommandLineUtils;

namespace DarkXaHTeP.CommandLine.Internal
{
    internal static class CommandOptionTypeConverterExtensions
    {
        public static CommandOptionType ToCommandOptionType(this CommandLineOptionType optionType)
        {
            CommandOptionType type = CommandOptionType.NoValue;
            
            switch (optionType)
            {
                    case CommandLineOptionType.MultipleValue:
                        type = CommandOptionType.MultipleValue;
                        break;
                    case CommandLineOptionType.SingleValue:
                        type = CommandOptionType.SingleValue;
                        break;
                    case CommandLineOptionType.NoValue:
                        type = CommandOptionType.NoValue;
                        break;
            }

            return type;
        }
        
        public static CommandLineOptionType ToCommandLineOptionType(this CommandOptionType optionType)
        {
            CommandLineOptionType type = CommandLineOptionType.NoValue;
            
            switch (optionType)
            {
                case CommandOptionType.MultipleValue:
                    type = CommandLineOptionType.MultipleValue;
                    break;
                case CommandOptionType.SingleValue:
                    type = CommandLineOptionType.SingleValue;
                    break;
                case CommandOptionType.NoValue:
                    type = CommandLineOptionType.NoValue;
                    break;
            }

            return type;
        }
    }
}