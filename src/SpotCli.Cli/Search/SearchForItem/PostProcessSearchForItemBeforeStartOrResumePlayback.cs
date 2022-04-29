using MediatR.Pipeline;
using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Search.SearchForItem;

public class PostProcessSearchForItemBeforeStartOrResumePlayback : IRequestPostProcessor<SearchForItemBeforeStartOrResumePlaybackRequest, SearchForItemResponse>
{
    private readonly IRequestQueue _requestQueue;
    public PostProcessSearchForItemBeforeStartOrResumePlayback(IRequestQueue requestQueue)
    {
        _requestQueue = requestQueue;
    }
    public Task Process(
        SearchForItemBeforeStartOrResumePlaybackRequest request,
        SearchForItemResponse response,
        CancellationToken cancellationToken)
    {
        var query = new StartOrResumePlaybackRequestQuery()
        {
            DeviceId = request.StartOrResumePlaybackOptions!.DeviceId
        };
        var body = request.SearchMethod switch
        {
            Enums.SearchMethod.Track => new StartOrResumePlaybackRequestBody()
            {
                Uris = new[] { response.Tracks.Items[0].Uri }
            },
            Enums.SearchMethod.Album => new StartOrResumePlaybackRequestBody()
            {
                ContextUri = response.Albums // todo implement return object contexturi
            },
            Enums.SearchMethod.Artist => new StartOrResumePlaybackRequestBody()
            {
                ContextUri = response.Artists // todo implement return object contexturi
            },
            _ => throw new NotImplementedException()
        };
        var playRequest = new StartOrResumePlaybackRequest(query, body);
        _requestQueue.Enqueue(playRequest);
        return Task.CompletedTask;
    }
}
