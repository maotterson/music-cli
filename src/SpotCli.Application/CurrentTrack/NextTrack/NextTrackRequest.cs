using MediatR;
using SpotCli.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.CurrentTrack.NextTrack;

public class NextTrackRequest : IRequest<NextTrackResponse>, IValidRequest
{
    public string Description => "Play next track";
}
