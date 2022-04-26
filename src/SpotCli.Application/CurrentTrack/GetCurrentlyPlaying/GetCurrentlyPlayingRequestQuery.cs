using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;

public record GetCurrentlyPlayingRequestQuery
{

    [AliasAs("additional_types")]
    public string[]? AdditionalTypes { get; init; }

    [AliasAs("market")]
    public string? Market { get; init; }
}
