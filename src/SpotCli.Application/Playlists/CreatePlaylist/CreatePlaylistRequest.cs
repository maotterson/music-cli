using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Playlists.CreatePlaylist;

public class CreatePlaylistRequest : IRequest<CreatePlaylistResponse>, IValidRequest
{
    public CreatePlaylistRequest(string userId, CreatePlaylistRequestBody body)
    {
        UserId = userId;
        Body = body;
    }
    public string Description => "Create playlist";
    public string UserId { get; set; }
    public CreatePlaylistRequestBody Body { get; set; }
}
