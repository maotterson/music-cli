using Refit;

namespace SpotCli.Application.CurrentTrack.PausePlayback;

public class PausePlaybackRequestQuery
{
    [AliasAs("device_id")]
    public string? DeviceId { get; set; }
}
