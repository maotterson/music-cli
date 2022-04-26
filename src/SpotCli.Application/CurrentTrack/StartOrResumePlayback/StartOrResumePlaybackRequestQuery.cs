using Refit;

namespace SpotCli.Application.CurrentTrack.StartOrResumePlayback;

public record StartOrResumePlaybackRequestQuery
{
    [AliasAs("device_id")]
    public string? DeviceId { get; init; }
}
