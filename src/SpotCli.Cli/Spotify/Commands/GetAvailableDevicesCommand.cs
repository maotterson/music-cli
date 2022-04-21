using MediatR;
using SpotCli.Cli.Options;
using SpotCli.Cli.Spotify.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Commands;

public class GetAvailableDevicesCommand : IRequest<GetAvailableDevicesResponse>, IValidCommand
{
    public string Description => "Get all available devices";

}
