using MediatR;
using SpotCli.Cli.Spotify.Responses.Local;

namespace SpotCli.Cli.Spotify.Commands.Local;

public class GetLocallyRegisteredDevicesCommand : IRequest<GetLocallyRegisteredDevicesResponse>, IValidCommand
{
    public string Description => "Get locally registered devices";
}
