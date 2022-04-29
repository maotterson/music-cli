using CommandLine;

namespace SpotCli.Cli.Options.Playlists.CreatePlaylist;

[Verb("playlist")]
public class CreatePlaylistOptions
{
    [Option('n', "Name", Required = true, HelpText = "Playlist name.")]
    public string? Name { get; set; }
    [Option('t', "Tracklist", Required = false, HelpText = "File path to external tracklist.")]
    public string? Tracklist { get; set; }
}
