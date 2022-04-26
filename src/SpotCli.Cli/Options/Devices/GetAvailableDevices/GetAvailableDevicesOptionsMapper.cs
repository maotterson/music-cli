using SpotCli.Application.Devices.GetAvailableDevices;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Options.Devices.GetAvailableDevices;

public class GetAvailableDevicesOptionsMapper
{
    private readonly IRequestQueue _commandQueue;
    public GetAvailableDevicesOptionsMapper(IRequestQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }
    public void Map(GetAvailableDevicesOptions options)
    {
        var request = new GetAvailableDevicesRequest();
        _commandQueue.Enqueue(request);
    }
}
