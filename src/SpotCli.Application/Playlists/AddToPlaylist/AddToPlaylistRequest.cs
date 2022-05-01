using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Playlists.AddToPlaylist;

public class AddToPlaylistRequest : IRequest<AddToPlaylistResponse>, IValidRequest
{
    public AddToPlaylistRequest(AddToPlaylistRequestBody body)
    {
        Body = body;
    }
    public AddToPlaylistRequestBody Body { get; set; }

    public string Description => "Add to playlist";
}
