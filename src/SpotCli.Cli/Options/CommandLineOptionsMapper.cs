using CommandLine;
using SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Options.CurrentTrack.NextTrack;
using SpotCli.Cli.Options.CurrentTrack.PausePlayback;
using SpotCli.Cli.Options.CurrentTrack.PreviousTrack;
using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Options.Devices.GetAvailableDevices;
using SpotCli.Cli.Options.Interfaces;
using SpotCli.Cli.Options.OAuth.GetNewAccessToken;
using SpotCli.Cli.Options.Playlists.CreatePlaylist;
using SpotCli.Cli.Options.Search;

namespace SpotCli.Cli.Factories;

public class CommandLineOptionsMapper : ICommandLineOptionsResolver
{
    private readonly PausePlaybackOptionsMapper _pausePlaybackOptionsMapper;
    private readonly GetNewAccessTokenOptionsMapper _getNewAccessTokenOptionsMapper;
    private readonly GetAvailableDevicesOptionsMapper _getAvailableDevicesOptionsMapper;
    private readonly GetCurrentlyPlayingOptionsMapper _getCurrentlyPlayingOptionsMapper;
    private readonly StartOrResumePlaybackOptionsMapper _startOrResumePlaybackOptionsMapper;
    private readonly SearchForItemOptionsMapper _searchForItemOptionsMapper;
    private readonly CreatePlaylistOptionsMapper _createPlaylistOptionsMapper;
    private readonly NextTrackOptionsMapper _nextTrackOptionsMapper;
    private readonly PreviousTrackOptionsMapper _previousTrackOptionsMapper;

    public CommandLineOptionsMapper(
        PausePlaybackOptionsMapper pausePlaybackOptionsMapper,
        GetNewAccessTokenOptionsMapper getNewAccessTokenOptionsMapper,
        GetAvailableDevicesOptionsMapper getAvailableDevicesOptionsMapper,
        GetCurrentlyPlayingOptionsMapper getCurrentlyPlayingOptionsMapper,
        StartOrResumePlaybackOptionsMapper startOrResumePlaybackOptionsMapper,
        SearchForItemOptionsMapper searchForItemOptionsMapper,
        CreatePlaylistOptionsMapper createPlaylistOptionsMapper,
        NextTrackOptionsMapper nextTrackOptionsMapper,
        PreviousTrackOptionsMapper previousTrackOptionsMapper)
    {
        _pausePlaybackOptionsMapper = pausePlaybackOptionsMapper;
        _getNewAccessTokenOptionsMapper = getNewAccessTokenOptionsMapper;
        _getAvailableDevicesOptionsMapper = getAvailableDevicesOptionsMapper;
        _getCurrentlyPlayingOptionsMapper = getCurrentlyPlayingOptionsMapper;
        _startOrResumePlaybackOptionsMapper = startOrResumePlaybackOptionsMapper;
        _searchForItemOptionsMapper = searchForItemOptionsMapper;
        _createPlaylistOptionsMapper = createPlaylistOptionsMapper;
        _nextTrackOptionsMapper = nextTrackOptionsMapper;
        _previousTrackOptionsMapper = previousTrackOptionsMapper;
    }

    public void ParseOptions(string[] args)
    {
        Parser.Default
            .ParseArguments<
                PausePlaybackOptions,
                GetNewAccessTokenOptions,
                GetCurrentlyPlayingOptions,
                StartOrResumePlaybackOptions,
                GetAvailableDevicesOptions,
                SearchForItemOptions,
                CreatePlaylistOptions,
                NextTrackOptions,
                PreviousTrackOptions>(args)
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
            .WithParsed<SearchForItemOptions>(options =>
            {
                _searchForItemOptionsMapper.Map(options);
            })
            .WithParsed<CreatePlaylistOptions>(options =>
            {
                _createPlaylistOptionsMapper.Map(options);
            })
            .WithParsed<NextTrackOptions>(options =>
            {
                _nextTrackOptionsMapper.Map(options);
            })
            .WithParsed<PreviousTrackOptions>(options =>
            {
                _previousTrackOptionsMapper.Map(options);
            })
            .WithNotParsed(_ =>
            {
                throw new Exception($"Unrecognized command: {args[0]}");
            });
    }
}
