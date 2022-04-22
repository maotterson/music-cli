using MediatR;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Commands;

public class GetCurrentlyPlayingCommand : IRequest<GetCurrentlyPlayingResponse>, IValidCommand
{
    public string Description => "Get currently playing track";
}
