using System.Collections.Generic;

namespace DarkXaHTeP.CommandLine
{
    public interface ICommandArgument
    {
        string Name { get; set; }
        
        string Description { get; set; }

        List<string> Values { get; }

        bool MultipleValues { get; set; }

        string Value { get; }
    }
}