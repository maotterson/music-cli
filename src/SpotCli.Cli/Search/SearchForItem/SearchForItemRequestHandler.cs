using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;
using SpotCli.Application.Search.SearchForItem;

namespace SpotCli.Cli.Search.SearchForItem;

public class SearchForItemRequestExtendedHandler : IRequestHandler<SearchForItemBeforeStartOrResumePlaybackRequest, SearchForItemResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public SearchForItemRequestExtendedHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<SearchForItemResponse> Handle(SearchForItemBeforeStartOrResumePlaybackRequest request, CancellationToken cancellationToken)
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
