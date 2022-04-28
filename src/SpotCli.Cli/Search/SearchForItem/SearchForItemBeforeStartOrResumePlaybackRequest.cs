using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

namespace SpotCli.Cli.Search.SearchForItem;

public class SearchForItemBeforeStartOrResumePlaybackRequest : SearchForItemRequest, IRequestBeforeStartOrResumePlayback
{
    public SearchForItemBeforeStartOrResumePlaybackRequest(SearchForItemRequestQuery query, StartOrResumePlaybackOptions playbackOptions) : base(query)
    {
        StartOrResumePlaybackOptions = playbackOptions;
    }

    public StartOrResumePlaybackOptions? StartOrResumePlaybackOptions { get; init; }
}
