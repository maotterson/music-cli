using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.Devices.GetAvailableDevices;

public class GetAvailableDevicesRequestHandler : IRequestHandler<GetAvailableDevicesRequest, GetAvailableDevicesResponse>
{
    private readonly ISpotifyWebApi _api;
    public GetAvailableDevicesRequestHandler(ISpotifyWebApi api)
    {
        _api = api;
    }
    public async Task<GetAvailableDevicesResponse> Handle(GetAvailableDevicesRequest request, CancellationToken cancellationToken)
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
