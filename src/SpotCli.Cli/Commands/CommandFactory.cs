using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Commands;

public class CommandFactory
{
    private static readonly IDictionary<string, IConsoleCommand> CommandDictionary = new Dictionary()
    {
        { "playing", new GetCurrentlyPlayingCommand() }
    };
    public IConsoleCommand BuildCommand(string[] args)
    {
        var commandArg = args[0].ToLower();
        var command = CommandDictionary[commandArg];
        return command;
    }
}
