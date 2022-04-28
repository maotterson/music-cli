﻿using Newtonsoft.Json;
using SpotCli.Core.ValueObjects;

namespace SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;

public record GetCurrentlyPlayingResponse
{
    [JsonProperty("item")]
    public ResponseItem Item { get; set; }
    public override string ToString()
    {
        return $"Now playing: {Item.Artists.First().Name} - {Item.Name} (Album: {Item.Album.Name})";
    }

    public struct ResponseItem
    {
        [JsonProperty("album")]
        public Album Album { get; set; }
        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }
    }
}
