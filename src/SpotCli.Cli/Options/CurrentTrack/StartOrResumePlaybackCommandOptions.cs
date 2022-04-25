using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack;

[Verb("resume")]
public class StartOrResumePlaybackCommandOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device id.")]
    public string? DeviceId { get; set; }
}
