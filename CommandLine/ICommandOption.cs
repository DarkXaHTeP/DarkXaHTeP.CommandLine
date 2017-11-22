using System.Collections.Generic;

namespace DarkXaHTeP.CommandLine
{
    public interface ICommandOption
    {
        string Template { get; set; }

        string ShortName { get; set; }

        string LongName { get; set; }

        string SymbolName { get; set; }

        string ValueName { get; set; }

        string Description { get; set; }
        
        CommandLineOptionType OptionType { get; }
        
        List<string> Values { get; }
        
        bool HasValue();
        
        string Value { get; }
    }
}