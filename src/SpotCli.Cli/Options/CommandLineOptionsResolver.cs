using CommandLine;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Application.CurrentTrack.Queries;
using SpotCli.Application.CurrentTrack.Requests;
using SpotCli.Application.Devices.Commands;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.Commands;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Devices;
using SpotCli.Cli.Options.CurrentTrack;
using SpotCli.Cli.Options.Devices;
using SpotCli.Cli.Options.OAuth;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Factories;

public class CommandLineOptionsResolver : ICommandLineOptionsResolver
{
    private readonly ISpotifyApiConfiguration _configuration;
    private readonly ICommandQueue _commandQueue;
    private readonly GetCurrentlyPlayingOptionsMapper _getCurrentlyPlayingOptionsMapper;
    public CommandLineOptionsResolver(
        ISpotifyApiConfiguration configuration, 
        ICommandQueue commandQueue,
        GetCurrentlyPlayingOptionsMapper getCurrentlyPlayingOptionsMapper)
    {
        _configuration = configuration;
        _commandQueue = commandQueue;
        _getCurrentlyPlayingOptionsMapper = getCurrentlyPlayingOptionsMapper;
    }

    public void ParseOptions(string[] args)
    {
        Parser.Default
            .ParseArguments<
                PausePlaybackRequestOptions,
                GetNewAccessTokenCommandOptions,
                GetCurrentlyPlayingRequestOptions,
                StartOrResumePlaybackRequestOptions,
                GetAvailableDevicesOptions>(args)
            .WithParsed<PausePlaybackRequestOptions>(options =>
            {
                var request = new PausePlaybackRequest
                {
                    DeviceId = options.DeviceId ?? null
                };
                _commandQueue.Enqueue(request);

            })
            .WithParsed<GetCurrentlyPlayingRequestOptions>(options =>
            {
                _getCurrentlyPlayingOptionsMapper.Map(options);
            })
            .WithParsed<GetNewAccessTokenCommandOptions>(_ =>
            {
                var refreshToken = _configuration.RefreshToken;
                var request = new GetNewAccessTokenCommand(refreshToken);
                _commandQueue.Enqueue(request);
            })
            .WithParsed<StartOrResumePlaybackRequestOptions>(options =>
            {
                //todo extract these resolver clauses into separate classses 
                if(options.Query is not null)
                {
                    //todo enqueue look up query
                    //todo pull out the context_uri of the track to play
                }
                var query = new StartOrResumePlaybackRequestQuery
                {
                    DeviceId = options.DeviceId ?? null,
                };
                var body = new StartOrResumePlaybackRequestBody
                {
                    // ContextUri = searchResponse.Context
                };
                var request = new StartOrResumePlaybackRequest(query, body);

                _commandQueue.Enqueue(request);
            })
            .WithParsed<GetAvailableDevicesOptions>(options =>
            {
                IValidRequest request = options.IsLocal ? new GetLocallyRegisteredDevicesCommand() : new GetAvailableDevicesCommand();
                
                _commandQueue.Enqueue(request);
            })
            .WithNotParsed(_ =>
            {
                throw new Exception($"Unrecognized command: {args[0]}");
            });
    }
}
