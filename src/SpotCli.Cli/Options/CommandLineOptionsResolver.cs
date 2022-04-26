using CommandLine;
using SpotCli.Application.CurrentTrack.PausePlayback;
using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Devices.GetAvailableDevices;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.GetNewAccessToken;
using SpotCli.Cli.Devices.GetLocallyRegisteredDevices;
using SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Options.CurrentTrack.PausePlayback;
using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Options.Devices.GetAvailableDevices;
using SpotCli.Cli.Options.Interfaces;
using SpotCli.Cli.Options.OAuth.GetNewAccessToken;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Factories;

public class CommandLineOptionsResolver : ICommandLineOptionsResolver
{
    private readonly IRequestQueue _commandQueue;
    private readonly ISpotifyApiConfiguration _configuration;

    private readonly PausePlaybackOptionsMapper _pausePlaybackOptionsMapper;
    private readonly GetNewAccessTokenOptionsMapper _getNewAccessTokenOptionsMapper;
    private readonly GetAvailableDevicesOptionsMapper _getAvailableDevicesOptionsMapper;
    private readonly GetCurrentlyPlayingOptionsMapper _getCurrentlyPlayingOptionsMapper;
    private readonly StartOrResumePlaybackOptionsMapper _startOrResumePlaybackOptionsMapper;

    public CommandLineOptionsResolver(
        ISpotifyApiConfiguration configuration, 
        IRequestQueue commandQueue,
        PausePlaybackOptionsMapper pausePlaybackOptionsMapper,
        GetNewAccessTokenOptionsMapper getNewAccessTokenOptionsMapper,
        GetAvailableDevicesOptionsMapper getAvailableDevicesOptionsMapper,
        GetCurrentlyPlayingOptionsMapper getCurrentlyPlayingOptionsMapper,
        StartOrResumePlaybackOptionsMapper startOrResumePlaybackOptionsMapper)
    {
        _configuration = configuration;
        _commandQueue = commandQueue;
        _pausePlaybackOptionsMapper = pausePlaybackOptionsMapper;
        _getNewAccessTokenOptionsMapper = getNewAccessTokenOptionsMapper;
        _getAvailableDevicesOptionsMapper = getAvailableDevicesOptionsMapper;
        _getCurrentlyPlayingOptionsMapper = getCurrentlyPlayingOptionsMapper;
        _startOrResumePlaybackOptionsMapper = startOrResumePlaybackOptionsMapper;
    }

    public void ParseOptions(string[] args)
    {
        Parser.Default
            .ParseArguments<
                PausePlaybackOptions,
                GetNewAccessTokenOptions,
                GetCurrentlyPlayingOptions,
                StartOrResumePlaybackOptions,
                GetAvailableDevicesOptions>(args)
            .WithParsed<PausePlaybackOptions>(options =>
            {
                _pausePlaybackOptionsMapper.Map(options);
            })
            .WithParsed<GetCurrentlyPlayingOptions>(options =>
            {
                _getCurrentlyPlayingOptionsMapper.Map(options);
            })
            .WithParsed<GetNewAccessTokenOptions>(options =>
            {
                _getNewAccessTokenOptionsMapper.Map(options);
            })
            .WithParsed<StartOrResumePlaybackOptions>(options =>
            {
                _startOrResumePlaybackOptionsMapper.Map(options);
            })
            .WithParsed<GetAvailableDevicesOptions>(options =>
            {
                _getAvailableDevicesOptionsMapper.Map(options);
                
            })
            .WithNotParsed(_ =>
            {
                throw new Exception($"Unrecognized command: {args[0]}");
            });
    }
}
