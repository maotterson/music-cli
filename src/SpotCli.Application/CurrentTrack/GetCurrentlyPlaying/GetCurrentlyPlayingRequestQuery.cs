using Refit;

namespace SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;

public record GetCurrentlyPlayingRequestQuery
{

    [AliasAs("additional_types")]
    public string[]? AdditionalTypes { get; init; }

    [AliasAs("market")]
    public string? Market { get; init; }
}
