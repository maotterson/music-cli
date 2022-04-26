using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;

[Verb("playing")]
public class GetCurrentlyPlayingRequestOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device name.")]
    public string? Device { get; set; }
}
