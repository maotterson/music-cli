using CommandLine;
using SpotCli.Cli.Options.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Options.CurrentTrack;

[Verb("playing")]
public class GetCurrentlyPlayingCommandOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device name.")]
    public string? Device { get; set; }
}
