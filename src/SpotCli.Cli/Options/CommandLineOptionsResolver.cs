﻿using CommandLine;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Queries;
using SpotCli.Application.CurrentTrack.Requests;
using SpotCli.Application.Devices.Commands;
using SpotCli.Application.Interfaces;
using SpotCli.Application.OAuth.Commands;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Devices;
using SpotCli.Cli.Options.CurrentTrack;
using SpotCli.Cli.Options.Devices;
using SpotCli.Cli.Options.OAuth;
using SpotCli.Cli.Services;

namespace SpotCli.Cli.Factories;

public class CommandLineOptionsResolver : ICommandLineOptionsResolver
{
    private readonly ISpotifyApiConfiguration _configuration;
    private readonly ICommandQueue _commandQueue;
    public CommandLineOptionsResolver(ISpotifyApiConfiguration configuration, ICommandQueue commandQueue)
    {
        _configuration = configuration;
        _commandQueue = commandQueue;
    }

    public void ParseOptions(string[] args)
    {
        IValidCommand? command = null;
        Parser.Default
            .ParseArguments<
                PausePlaybackCommandOptions,
                GetNewAccessTokenCommandOptions,
                GetCurrentlyPlayingCommandOptions,
                StartOrResumePlaybackCommandOptions,
                GetAvailableDevicesOptions>(args)
            .WithParsed<PausePlaybackCommandOptions>(options =>
            {
                command = new PausePlaybackCommand
                {
                    DeviceId = options.DeviceId ?? null
                };
                _commandQueue.Enqueue(command);

            })
            .WithParsed<GetCurrentlyPlayingCommandOptions>(options =>
            {
                command = new GetCurrentlyPlayingCommand();
                _commandQueue.Enqueue(command);
            })
            .WithParsed<GetNewAccessTokenCommandOptions>(_ =>
            {
                var refreshToken = _configuration.RefreshToken;
                command = new GetNewAccessTokenCommand(refreshToken);
                _commandQueue.Enqueue(command);
            })
            .WithParsed<StartOrResumePlaybackCommandOptions>(options =>
            {
                //todo extract these resolver clauses into separate classses 
                if(options.Query is not null)
                {
                    //todo enqueue look up query
                    //todo pull out the context_uri of the track to play
                }
                var query = new StartOrResumePlaybackQuery
                {
                    DeviceId = options.DeviceId ?? null,
                };
                var body = new StartOrResumePlaybackBody
                {
                    // ContextUri = searchResponse.Context
                };
                var request = new StartOrResumePlaybackRequest(query, body);

                _commandQueue.Enqueue(request);
            })
            .WithParsed<GetAvailableDevicesOptions>(options =>
            {
                command = options.IsLocal ? new GetLocallyRegisteredDevicesCommand() : new GetAvailableDevicesCommand();
                
                
                _commandQueue.Enqueue(command);
            })
            .WithNotParsed(_ =>
            {
                throw new Exception($"Unrecognized command: {args[0]}");
            });
    }
}
