using CommandLine;

namespace SpotCli.Cli.Options;

[Verb("devices")]
public class GetAvailableDevicesOptions
{
    [Option('l', "local", Required = false, HelpText = "View locally registered devices.")]
    public bool IsLocal { get; set; }

}
