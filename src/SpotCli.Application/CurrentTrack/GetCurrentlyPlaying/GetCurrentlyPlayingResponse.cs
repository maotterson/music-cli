using Newtonsoft.Json;
using SpotCli.Application.Dto;

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
        public AlbumDto Album { get; set; }
        [JsonProperty("artists")]
        public ArtistDto[] Artists { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }
    }
}
