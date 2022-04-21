﻿using MediatR;
using Refit;
using SpotCli.Cli.Spotify.Responses;

namespace SpotCli.Cli.Spotify.Commands;

public class GetCurrentlyPlayingCommand : IRequest<GetCurrentlyPlayingResponse>, IValidCommand
{
}
