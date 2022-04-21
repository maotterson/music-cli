﻿using MediatR;
using CommandLine;
using SpotCli.Cli.Options;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Configuration;
using Refit;

namespace SpotCli.Cli.Spotify.Factories;

public class ConsoleCommandFactory : IConsoleCommandFactory 
{
    private readonly ISpotifyApiConfiguration _configuration;
    public ConsoleCommandFactory(ISpotifyApiConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IValidCommand? BuildFromArgs(string[] args)
    {
        var command = BuildCommand(args);
        return command;
    }

    private IValidCommand? BuildCommand(string[] args)
    {
        IValidCommand? command = null;
        Parser.Default.ParseArguments<GetCurrentlyPlayingCommandOptions,GetNewAccessTokenCommandOptions>(args)
            .WithParsed<GetCurrentlyPlayingCommandOptions>(_ =>
            {
                command = new GetCurrentlyPlayingCommand();
            })
            .WithParsed<GetNewAccessTokenCommandOptions>(_ =>
            {
                var refreshToken = _configuration.RefreshToken;
                command = new GetNewAccessTokenCommand(refreshToken);
            })
            .WithNotParsed(_ =>
            {
                command = null;
            });
        return command;
    }
}
