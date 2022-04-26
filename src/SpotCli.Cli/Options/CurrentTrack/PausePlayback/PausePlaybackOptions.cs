using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack.PausePlayback;

[Verb("pause")]
public class PausePlaybackOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device ID.")]
    public string? DeviceId { get; set; }
}
