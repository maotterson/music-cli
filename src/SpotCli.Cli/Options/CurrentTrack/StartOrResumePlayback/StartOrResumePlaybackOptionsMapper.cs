﻿using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    public StartOrResumePlaybackOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(StartOrResumePlaybackOptions options)
    {
        if(options.Query is not null)
        {
            // todo look up query for track
        }

        var query = new StartOrResumePlaybackRequestQuery
        {
            DeviceId = options.DeviceId
        };
        var body = new StartOrResumePlaybackRequestBody
        {
            // todo receive potential body options
        };

        var request = new StartOrResumePlaybackRequest(query, body);
        _commandQueue.Enqueue(request);
    }
}

