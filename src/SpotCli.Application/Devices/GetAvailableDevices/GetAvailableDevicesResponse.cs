using Newtonsoft.Json;

namespace SpotCli.Application.Devices.GetAvailableDevices;

public class GetAvailableDevicesResponse
{
    [JsonProperty("devices")]
    public Device[]? Devices { get; set; }
    public override string ToString()
    {
        if (Devices is null)
        {
            return "No available devices detected.";
        }

        string returnString = "Devices:\n" +
                              "Name\t\t\t\tDevice Id\n" +
                              "================\t\t===============\n";
        foreach (var device in Devices)
        {
            returnString += $"{device.Name}\t\t\t\t{device.Id}\n";
        }
        return returnString;
    }

    public struct Device
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_private_session")]
        public bool IsPrivateSession { get; set; }

        [JsonProperty("is_restricted")]
        public bool IsRestricted { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("volume_percent")]
        public int VolumePercent { get; set; }
    }
}