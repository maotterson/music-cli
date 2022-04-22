using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Options;

[Verb("playing")]
public class GetCurrentlyPlayingCommandOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device name.")]
    public string? Device { get; set; }
}
