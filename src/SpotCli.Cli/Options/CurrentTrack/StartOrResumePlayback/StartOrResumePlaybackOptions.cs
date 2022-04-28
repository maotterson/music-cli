using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

[Verb("play")]
public class StartOrResumePlaybackOptions : IConsoleOptions
{
    [Option('d', "device", Required = false, HelpText = "Device id.")]
    public string? DeviceId { get; set; }

    [Option('s', "song", Required = false, HelpText = "Search query for track to play.")]
    public string? SongQuery { get; set; }

    [Option('r', "record", Required = false, HelpText = "Search query for record/album to play.")]
    public string? AlbumQuery { get; set; }

    [Option('a', "artist", Required = false, HelpText = "Search query for artist to play.")]
    public string? ArtistQuery { get; set; }

    [Option("id", Required = false, HelpText = "Manually provide the track id of the track to play.")]
    public string? TrackId { get; set; }
}