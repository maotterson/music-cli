using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;

[Verb("rating")]
public class RatingOptions : IConsoleOptions
{
    [Option('n', "new", Required = false, HelpText = "Rate the current track.")]
    public int NewRating { get; set; }
}
