using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.CurrentTrack.NextTrack;

public class NextTrackRequestHandler : IRequestHandler<NextTrackRequest, NextTrackResponse>
{
    private readonly ISpotifyWebApi _api;

    public NextTrackRequestHandler(ISpotifyWebApi api)
    {
        _api = api;
    }

    public async Task<NextTrackResponse> Handle(NextTrackRequest request, CancellationToken cancellationToken)
    {
        var response = await _api.NextTrack();
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new NextTrackResponse();
    }
}
