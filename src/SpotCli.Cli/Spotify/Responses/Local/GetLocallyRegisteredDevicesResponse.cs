using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Responses.Local;

public class GetLocallyRegisteredDevicesResponse
{
    public override string ToString()
    {
        if (Devices is null)
        {
            return "No locally registered devices.";
        }

        string returnString = "Locally Registered Devices:\n" +
                              "Name\t\tDeviceId" +
                              "=======================================================\n";
        foreach (var device in Devices)
        {
            returnString += $"{device.Name}\t\t{device.Id}";
        }
        return returnString;
    }

    public Device[]? Devices { get; set; }

    public struct Device
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
