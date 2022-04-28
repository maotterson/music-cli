using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

public interface IRequestBeforeStartOrResumePlayback
{
    public StartOrResumePlaybackOptions? StartOrResumePlaybackOptions { get; }
}
