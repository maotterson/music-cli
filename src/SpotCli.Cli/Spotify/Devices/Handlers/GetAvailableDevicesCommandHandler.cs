using MediatR;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Handlers;

public class GetAvailableDevicesCommandHandler : IRequestHandler<GetAvailableDevicesCommand, GetAvailableDevicesResponse>
{
    private readonly ISpotifyWebApi _api;
    public GetAvailableDevicesCommandHandler(ISpotifyWebApi api)
    {
        _api = api;
    }
    public async Task<GetAvailableDevicesResponse> Handle(GetAvailableDevicesCommand request, CancellationToken cancellationToken)
    {
        var response = await _api.GetAvailableDevices();
        if (!response.IsSuccessStatusCode || response.Content is null)
        {
            throw new Exception();
        }

        return response.Content;
    }
}
