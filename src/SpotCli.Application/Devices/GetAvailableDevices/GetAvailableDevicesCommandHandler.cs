using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.Devices.GetAvailableDevices;

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
        if(response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
