using SpotCli.Application.CurrentTrack.PausePlayback;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.PausePlayback;

public class PausePlaybackOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    public PausePlaybackOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(PausePlaybackOptions options)
    {
        var query = new PausePlaybackRequestQuery
        {
            DeviceId = options.DeviceId
        };
        var request = new PausePlaybackRequest(query);
        _commandQueue.Enqueue(request);
    }
}
