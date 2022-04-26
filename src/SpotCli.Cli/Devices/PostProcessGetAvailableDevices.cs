using MediatR.Pipeline;
using SpotCli.Application.Devices.GetAvailableDevices;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Devices;

public class PostProcessGetAvailableDevices : IRequestPostProcessor<GetAvailableDevicesRequest, GetAvailableDevicesResponse>
{
    private readonly ISaveDevicesService _saveDevicesService;
    public PostProcessGetAvailableDevices(ISaveDevicesService saveDevicesService)
    {
        _saveDevicesService = saveDevicesService;
    }

    public Task Process(GetAvailableDevicesRequest request, GetAvailableDevicesResponse response, CancellationToken cancellationToken)
    {
        if (!_saveDevicesService.IsSaving())
        {
            return Task.CompletedTask;
        }
        if (response.Devices is null)
        {
            throw new NullReferenceException();
        }

        _saveDevicesService.Save(response.Devices);
        return Task.CompletedTask;
    }
}
