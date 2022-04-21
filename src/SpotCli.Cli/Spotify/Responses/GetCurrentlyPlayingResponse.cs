﻿using Newtonsoft.Json;

namespace SpotCli.Cli.Spotify.Responses;

public record GetCurrentlyPlayingResponse
{
    [JsonProperty("item")]
    public ResponseItem Item { get; set; }

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
    public struct Album
    {
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public struct Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
