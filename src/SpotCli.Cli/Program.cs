using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using SpotCli.Application.Api;
using SpotCli.Application.Interfaces;
using SpotCli.Cli.App;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Factories;
using SpotCli.Cli.Services;
using System.Reflection;

var services = new ServiceCollection();
var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("secrets.json")
    .AddJsonFile("token.json")
    .AddJsonFile("devices.json")
    .Build();
var configuration = new SpotifyApiConfiguration(configurationBuilder);

services.AddRefitApis(configuration);
services.AddSingletonServices(configuration);
services.AddHandlers();

var app = services.BuildServiceProvider()
    .GetRequiredService<IConsoleApplication>();
await app.RunAsync(args);

public static partial class Helpers
{
    public static void AddRefitApis(this IServiceCollection services, ISpotifyApiConfiguration configuration)
    {
        services.AddRefitClient<ISpotifyWebApi>(
            new RefitSettings(
                new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })))
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseAddress);
            client.DefaultRequestHeaders.Add("Authorization", configuration.BearerTokenHeader);
        });
        services.AddRefitClient<ISpotifyOAuthApi>(
            new RefitSettings(
                new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })))
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(configuration.OAuthBaseAddress);
        });
    }
    public static void AddSingletonServices(this IServiceCollection services, ISpotifyApiConfiguration configuration)
    {
        services.AddSingleton<ISaveTokenService, SaveTokenService>();
        services.AddSingleton<IConsoleApplication, ConsoleApplication>();
        services.AddSingleton<IConsoleCommandFactory, ConsoleCommandFactory>();
        services.AddSingleton<ISpotifyApiConfiguration, SpotifyApiConfiguration>(_ =>
        {
            return new(configuration.Configuration);
        }); 
    }
    public static void AddHandlers(this IServiceCollection services)
    {
        var applicationAssembly = Assembly.GetAssembly(typeof(ISpotifyWebApi))!;
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(assembly, applicationAssembly);
    }
}
