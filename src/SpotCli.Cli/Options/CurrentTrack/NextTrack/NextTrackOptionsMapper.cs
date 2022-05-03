using SpotCli.Application.CurrentTrack.NextTrack;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.NextTrack;

public class NextTrackOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    public NextTrackOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(NextTrackOptions options)
    {
        var request = new NextTrackRequest();
        _commandQueue.Enqueue(request);
    }
}
