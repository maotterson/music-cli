using CommandLine;

namespace SpotCli.Cli.Options.Devices.GetAvailableDevices;

[Verb("devices")]
public class GetAvailableDevicesOptions
{
    [Option('l', "local", Required = false, HelpText = "View locally registered devices.")]
    public bool IsLocal { get; set; }
    [Option('s', "save", Required = false, HelpText = "Save available devices locally.")]
    public bool IsRequestingSave { get; set; }
}
