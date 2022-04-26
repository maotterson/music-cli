using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack;

[Verb("resume")]
public class StartOrResumePlaybackRequestOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device id.")]
    public string? DeviceId { get; set; }

    [Option('q', "query", Required = false, HelpText = "Search query for track to play.")]
    public string? Query { get; set; }
}