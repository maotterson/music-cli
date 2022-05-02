using MediatR;

namespace SpotCli.Application.Playlists.AddToPlaylist;

public class AddToPlaylistRequestHandler : IRequestHandler<AddToPlaylistRequest, AddToPlaylistResponse>
{
    public Task<AddToPlaylistResponse> Handle(AddToPlaylistRequest request, CancellationToken cancellationToken)
    {
        // call to api
        return Task.FromResult(new AddToPlaylistResponse());
    }
}
