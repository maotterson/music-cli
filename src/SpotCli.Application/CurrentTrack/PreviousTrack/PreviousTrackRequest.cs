using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.PreviousTrack;

public class PreviousTrackRequest : IRequest<PreviousTrackResponse>, IValidRequest
{
    public string Description => "Play previous track";
}

