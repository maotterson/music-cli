using MediatR;
using SpotCli.Application.Apis;

namespace SpotCli.Application.Search.SearchForItem;

public class SearchForItemRequestHandler : IRequestHandler<SearchForItemRequest, SearchForItemResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public SearchForItemRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<SearchForItemResponse> Handle(SearchForItemRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.SearchForItem(request.Query);
    }
}
