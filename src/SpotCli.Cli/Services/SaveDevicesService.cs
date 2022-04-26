using SpotCli.Application.Interfaces;
using static SpotCli.Application.Devices.GetAvailableDevices.GetAvailableDevicesResponse;

namespace SpotCli.Cli.Services;

public class SaveDevicesService : ISaveDevicesService
{
    private readonly ISpotifyApiConfiguration _configuration;
    private bool _isRequestingSave = false;
    public SaveDevicesService(ISpotifyApiConfiguration apiConfiguration)
    {
        _configuration = apiConfiguration;
    }
    public string Save(Device[] devices)
    {
        var appDataDirectory = _configuration.AppDataDirectory;
        using (StreamWriter sw = new StreamWriter(File.Create(appDataDirectory + "devices.json")))
        {
            var prefix = "{\"Devices\":{";
            sw.WriteLine(prefix);

            for (int i=0; i<devices.Length; i++)
            {
                var device = devices[i];
                var entry = "\"" + device.Name + "\":\"" + device.Id + "\"";

                if(i != devices.Length - 1)
                {
                    entry += ",";
                }

                sw.WriteLine(entry);
            }

            var suffix = "}\n}";
            sw.WriteLine(suffix);
        }
        return $"Devices saved locally.";
    }

    public void RequestSaveDevices()
    {
        _isRequestingSave = true;
    }

    public bool IsSaving()
    {
        return _isRequestingSave;
    }
}
