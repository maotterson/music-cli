namespace SpotCli.Cli.Services.Playlist;

public interface IPlaylistFileParser
{
    public Queue<ParsedTrack> ParseFile(string file);
}
