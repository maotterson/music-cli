using Refit;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Queries;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Devices.Responses;

namespace SpotCli.Application.Api;

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
        [Body(BodySerializationMethod.Serialized)] PausePlaybackRequest command);

    [Get("/me/player/devices")]
    Task<IApiResponse<GetAvailableDevicesResponse>> GetAvailableDevices();

}
