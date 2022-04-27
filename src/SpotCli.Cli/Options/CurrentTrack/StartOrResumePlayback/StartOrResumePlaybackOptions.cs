using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

[Verb("play")]
public class StartOrResumePlaybackOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device id.")]
    public string? DeviceId { get; set; }

    [Option('q', "query", Required = false, HelpText = "Search query for track to play.")]
    public string? Query { get; set; }
    [Option("id", Required = false, HelpText = "Manually provide the track id of the track to play.")]
    public string? TrackId { get; set; }
}