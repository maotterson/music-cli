using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

namespace SpotCli.Cli.Search.Decorators;

public interface IRequestBeforeStartOrResumePlayback
{
    public StartOrResumePlaybackOptions? StartOrResumePlaybackOptions { get; }
}
