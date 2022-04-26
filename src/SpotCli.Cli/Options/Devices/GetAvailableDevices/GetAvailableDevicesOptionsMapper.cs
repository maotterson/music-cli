using SpotCli.Application.Devices.GetAvailableDevices;
using SpotCli.Application.Interfaces;
using SpotCli.Cli.Devices.GetLocallyRegisteredDevices;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.Devices.GetAvailableDevices;

public class GetAvailableDevicesOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    private readonly ISaveDevicesService _saveDevicesService;
    public GetAvailableDevicesOptionsMapper(IRequestQueue commandQueue, ISaveDevicesService saveDevicesService)
    {
        _commandQueue = commandQueue;
        _saveDevicesService = saveDevicesService;
    }
    public void Map(GetAvailableDevicesOptions options)
    {
        IValidRequest request = options.IsLocal ? 
            GetLocallyRegisteredDevicesRequest() : 
            GetAvailableDevicesRequest();

        if (options.IsRequestingSave)
        {
            _saveDevicesService.RequestSaveDevices();
        }

        _commandQueue.Enqueue(request);
    }

    private IValidRequest GetLocallyRegisteredDevicesRequest()
    {
        return new GetLocallyRegisteredDevicesRequest();
    }
    private IValidRequest GetAvailableDevicesRequest()
    {
        return new GetAvailableDevicesRequest();
    }
}
