using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

namespace SpotCli.Cli.Search.Decorators;

public interface ISearchRequestBeforePlayback
{
    public StartOrResumePlaybackOptions? StartOrResumePlaybackOptions { get; }
}
