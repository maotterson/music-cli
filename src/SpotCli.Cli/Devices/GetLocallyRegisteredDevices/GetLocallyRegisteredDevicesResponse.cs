namespace SpotCli.Cli.Devices.GetLocallyRegisteredDevices;

public class GetLocallyRegisteredDevicesResponse
{
    public override string ToString()
    {
        if (Devices is null)
        {
            return "No locally registered devices.";
        }

        string returnString = "Locally Registered Devices:\n" +
                              "Name\t\t\t\tDevice Id\n" +
                              "================\t\t===============\n";
        foreach (var device in Devices)
        {
            returnString += $"{device.Name}\t\t\t\t{device.Id}\n";
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
