using MediatR;
using SpotCli.Cli.Spotify.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Commands;

public class PausePlaybackCommand : IRequest<PausePlaybackResponse>, IValidCommand
{
    public string Description => "Pause playback";
}
