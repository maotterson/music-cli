using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;
using SpotCli.Application.Search.SearchForItem;

namespace SpotCli.Cli.Search.SearchForItem.BeforeAddToPlaylist;

public class SearchBeforeAddToPlaylistRequestHandler: IRequestHandler<SearchBeforeAddToPlaylistRequest, SearchForItemResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public SearchBeforeAddToPlaylistRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<SearchForItemResponse> Handle(SearchBeforeAddToPlaylistRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.SearchForItem(request.Query);

        if (response is null)
        {
            throw new NullReferenceException(nameof(request));
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
