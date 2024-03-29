﻿using Refit;
using SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Application.CurrentTrack.NextTrack;
using SpotCli.Application.CurrentTrack.PausePlayback;
using SpotCli.Application.CurrentTrack.PreviousTrack;
using SpotCli.Application.CurrentTrack.StartOrResumePlayback;
using SpotCli.Application.Devices.GetAvailableDevices;
using SpotCli.Application.Playlists.AddToPlaylist;
using SpotCli.Application.Playlists.CreatePlaylist;
using SpotCli.Application.Search.SearchForItem;

namespace SpotCli.Application.Apis;

public interface ISpotifyWebApi
{
    [Get("/me/player/currently-playing")]
    Task<IApiResponse<GetCurrentlyPlayingResponse>> GetCurrentlyPlaying(
        GetCurrentlyPlayingRequestQuery query);

    [Put("/me/player/play")]
    Task<IApiResponse<StartOrResumePlaybackResponse>> StartOrResumePlayback(
        StartOrResumePlaybackRequestQuery query,
        [Body(BodySerializationMethod.Serialized)] StartOrResumePlaybackRequestBody body);

    [Put("/me/player/pause")]
    Task<IApiResponse<PausePlaybackResponse>> PausePlayback(
        PausePlaybackRequestQuery query);

    [Get("/me/player/devices")]
    Task<IApiResponse<GetAvailableDevicesResponse>> GetAvailableDevices();

    [Get("/search")]
    Task<IApiResponse<SearchForItemResponse>> SearchForItem(
        SearchForItemRequestQuery query);

    [Post("/users/{id}/playlists")]
    Task<IApiResponse<CreatePlaylistResponse>> CreatePlaylist(
        string id,
        [Body(BodySerializationMethod.Serialized)] CreatePlaylistRequestBody body);

    [Post("/playlists/{id}/tracks")]
    Task<IApiResponse<AddToPlaylistResponse>> AddToPlaylist(
        string id,
        [Body(BodySerializationMethod.Serialized)] AddToPlaylistRequestBody body);

    [Post("/me/player/next")]
    Task<IApiResponse<NextTrackResponse>> NextTrack();

    [Post("/me/player/previous")]
    Task<IApiResponse<PreviousTrackResponse>> PreviousTrack();
}
