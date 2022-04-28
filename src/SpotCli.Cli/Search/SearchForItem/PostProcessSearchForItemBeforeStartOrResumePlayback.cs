using MediatR.Pipeline;
using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Search.SearchForItem;

public class PostProcessSearchForItemBeforeStartOrResumePlayback : IRequestPostProcessor<SearchForItemBeforeStartOrResumePlaybackRequest, SearchForItemResponse>
{
    private readonly IRequestQueue _requestQueue;
    public PostProcessSearchForItemBeforeStartOrResumePlayback(IRequestQueue requestQueue)
    {
        _requestQueue = requestQueue;
    }
    public Task Process(SearchForItemBeforeStartOrResumePlaybackRequest request, SearchForItemResponse response, CancellationToken cancellationToken)
    {
        var query = new StartOrResumePlaybackRequestQuery()
        {
            DeviceId = request.StartOrResumePlaybackOptions!.DeviceId
        };
        var body = new StartOrResumePlaybackRequestBody()
        {
            Uris = new[] { response.Tracks.Items[0].Uri }
        };
        var playRequest = new StartOrResumePlaybackRequest(query, body);
        _requestQueue.Enqueue(playRequest);
        return Task.CompletedTask;
    }
}
