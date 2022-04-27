using static SpotCli.Application.Devices.GetAvailableDevices.GetAvailableDevicesResponse;

namespace SpotCli.Cli.Services;

public interface ISaveDevicesService
{
    public string Save(Device[] devices);
    public void RequestSaveDevices();
    public bool IsSaving();
}
