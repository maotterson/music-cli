using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.NextTrack;

public class NextTrackRequest : IRequest<NextTrackResponse>, IValidRequest
{
    public string Description => "Play next track";
}
