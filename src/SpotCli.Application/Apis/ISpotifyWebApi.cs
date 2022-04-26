using Refit;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Application.CurrentTrack.PausePlayback;
using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Devices.GetAvailableDevices;

namespace SpotCli.Application.Apis;

public interface ISpotifyWebApi
{
    [Get("/me/player/currently-playing")]
    Task<IApiResponse<GetCurrentlyPlayingResponse>> GetCurrentlyPlaying();

    [Put("/me/player/play")]
    Task<IApiResponse<StartOrResumePlaybackResponse>> StartOrResumePlayback(
        StartOrResumePlaybackRequestQuery query,
        [Body(BodySerializationMethod.Serialized)] StartOrResumePlaybackRequestBody body);

    [Put("/me/player/pause")]
    Task<IApiResponse<PausePlaybackResponse>> PausePlayback(
        PausePlaybackRequestQuery query);

    [Get("/me/player/devices")]
    Task<IApiResponse<GetAvailableDevicesResponse>> GetAvailableDevices();

}
