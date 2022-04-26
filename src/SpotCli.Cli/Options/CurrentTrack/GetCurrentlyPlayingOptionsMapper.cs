using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Options.CurrentTrack;

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
