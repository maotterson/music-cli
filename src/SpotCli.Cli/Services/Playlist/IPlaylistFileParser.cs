namespace SpotCli.Cli.Services.Playlist;

public interface IPlaylistFileParser
{
    public IList<ParsedTrack> ParseFile(string file);
}
