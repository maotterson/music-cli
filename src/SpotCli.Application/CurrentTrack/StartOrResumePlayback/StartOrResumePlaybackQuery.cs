using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.CurrentTrack.Queries;

public record StartOrResumePlaybackQuery
{
    [AliasAs("device_id")]
    public string? DeviceId { get; init; }
}
