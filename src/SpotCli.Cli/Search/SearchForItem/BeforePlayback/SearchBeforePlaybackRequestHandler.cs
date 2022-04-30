using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;
using SpotCli.Application.Search.SearchForItem;

namespace SpotCli.Cli.Search.SearchForItem;

public class SearchBeforePlaybackRequestHandler : IRequestHandler<SearchBeforePlaybackRequest, SearchForItemResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public SearchBeforePlaybackRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<SearchForItemResponse> Handle(SearchBeforePlaybackRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.SearchForItem(request.Query);

        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
