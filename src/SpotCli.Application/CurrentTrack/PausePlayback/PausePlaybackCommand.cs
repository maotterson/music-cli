using MediatR;
using Newtonsoft.Json;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.CurrentTrack.Commands;

public class PausePlaybackCommand : IRequest<PausePlaybackResponse>, IValidCommand
{
    public string Description => "Pause playback";

    [JsonProperty(PropertyName = "device_id")]
    public string? DeviceId { get; set; }
}
