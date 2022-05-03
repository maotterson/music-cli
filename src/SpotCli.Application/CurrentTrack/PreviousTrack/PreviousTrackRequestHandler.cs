using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.PreviousTrack;

public class PreviousTrackRequestHandler : IRequestHandler<PreviousTrackRequest, PreviousTrackResponse>
{
    private readonly ISpotifyWebApi _api;

    public PreviousTrackRequestHandler(ISpotifyWebApi api)
    {
        _api = api;
    }

    public async Task<PreviousTrackResponse> Handle(PreviousTrackRequest request, CancellationToken cancellationToken)
    {
        var response = await _api.PreviousTrack();
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new PreviousTrackResponse();
    }
}
