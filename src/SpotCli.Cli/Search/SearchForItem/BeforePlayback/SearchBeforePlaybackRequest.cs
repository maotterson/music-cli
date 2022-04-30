using SpotCli.Application.Search.SearchForItem;
using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Search.Decorators;
using SpotCli.Cli.Search.Enums;

namespace SpotCli.Cli.Search.SearchForItem;

public class SearchBeforePlaybackRequest : SearchForItemRequest, ISearchRequestBeforePlayback
{
    public SearchBeforePlaybackRequest(SearchMethod method, SearchForItemRequestQuery query, StartOrResumePlaybackOptions playbackOptions) : base(query)
    {
        SearchMethod = method;
        StartOrResumePlaybackOptions = playbackOptions;
    }
    public SearchMethod SearchMethod { get; init; }
    public StartOrResumePlaybackOptions? StartOrResumePlaybackOptions { get; init; }
}
