using SpotCli.Application.CurrentTrack.PreviousTrack;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.PreviousTrack;

public class PreviousTrackOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    public PreviousTrackOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(PreviousTrackOptions options)
    {
        var request = new PreviousTrackRequest();
        _commandQueue.Enqueue(request);
    }
}
