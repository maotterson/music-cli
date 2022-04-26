using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;

public class GetCurrentlyPlayingOptionsMapper
{
    private readonly ICommandQueue _commandQueue;
    public GetCurrentlyPlayingOptionsMapper(ICommandQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(GetCurrentlyPlayingRequestOptions options)
    {
        var query = new GetCurrentlyPlayingRequestQuery
        {
            // todo receive potential query options
        };
        var request = new GetCurrentlyPlayingRequest(query);
        _commandQueue.Enqueue(request);
    }
}
