using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Search.Enums;

namespace SpotCli.Cli.Search.SearchForItem;

public class SearchForItemBeforeStartOrResumePlaybackRequest : SearchForItemRequest, IRequestBeforeStartOrResumePlayback
{
    public SearchForItemBeforeStartOrResumePlaybackRequest(SearchForItemRequestQuery query, StartOrResumePlaybackOptions playbackOptions) : base(query)
    {
        StartOrResumePlaybackOptions = playbackOptions;
    }
    internal SearchMethod SearchMethod { get; init; }
    public StartOrResumePlaybackOptions? StartOrResumePlaybackOptions { get; init; }
}
