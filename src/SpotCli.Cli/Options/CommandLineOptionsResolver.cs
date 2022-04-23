using CommandLine;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.Devices.Commands;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.Commands;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Devices;
using SpotCli.Cli.Options.CurrentTrack;
using SpotCli.Cli.Options.Devices;
using SpotCli.Cli.Options.OAuth;

namespace SpotCli.Cli.Factories;

public class CommandLineOptionsResolver : ICommandLineOptionsResolver
{
    private readonly ISpotifyApiConfiguration _configuration;
    public CommandLineOptionsResolver(ISpotifyApiConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IValidCommand? PopulateCommandQueue(string[] args)
    {
        var command = BuildCommand(args);
        return command;
    }

    private IValidCommand? BuildCommand(string[] args)
    {
        IValidCommand? command = null;
        Parser.Default
            .ParseArguments<
                PausePlaybackCommandOptions,
                GetNewAccessTokenCommandOptions,
                GetCurrentlyPlayingCommandOptions,
                StartOrResumePlaybackCommandOptions,
                GetAvailableDevicesOptions>(args)
            .WithParsed<PausePlaybackCommandOptions>(_ =>
            {
                command = new PausePlaybackCommand();
            })
            .WithParsed<GetCurrentlyPlayingCommandOptions>(_ =>
            {
                command = new GetCurrentlyPlayingCommand();
            })
            .WithParsed<GetNewAccessTokenCommandOptions>(_ =>
            {
                var refreshToken = _configuration.RefreshToken;
                command = new GetNewAccessTokenCommand(refreshToken);
            })
            .WithParsed<StartOrResumePlaybackCommandOptions>(_ =>
            {
                command = new StartOrResumePlaybackCommand();
            })
            .WithParsed<GetAvailableDevicesOptions>(options =>
            {
                command = options.IsLocal ? new GetLocallyRegisteredDevicesCommand() : new GetAvailableDevicesCommand();
            })
            .WithNotParsed(_ =>
            {
                command = null;
            });
        return command;
    }
}
