using SpotCli.Core.Entities;

namespace SpotCli.Application.Playlists.CreatePlaylist;

public class CreatePlaylistResponse
{
    public override string ToString()
    {
        return $"Playlist \"{Playlist.Name}\" created (Id: {Playlist.Id}.";
    }
    public Playlist Playlist { get; set; }

}
