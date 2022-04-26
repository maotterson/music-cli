using MediatR;
using Newtonsoft.Json;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.PausePlayback;

public class PausePlaybackRequest : IRequest<PausePlaybackResponse>, IValidRequest
{
    public string Description => "Pause playback";

    [JsonProperty(PropertyName = "device_id")]
    public string? DeviceId { get; set; }
}
