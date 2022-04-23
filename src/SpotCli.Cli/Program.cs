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

var appDataDirectory = GetAppDataDirectoryFromSettings();
var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile(appDataDirectory + "secrets.json")
    .AddJsonFile(appDataDirectory + "token.json")
    .AddJsonFile(appDataDirectory + "devices.json")
    .Build();
var configuration = new SpotifyApiConfiguration(configurationBuilder);

var services = new ServiceCollection();
services.AddRefitApis(configuration);
services.AddSingletonServices(configuration);
services.AddHandlers();

var app = services.BuildServiceProvider()
    .GetRequiredService<IConsoleApplication>();
await app.RunAsync(args);

string GetAppDataDirectoryFromSettings()
{
    return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["AppDataDirectory"] ?? "/AppData";
}

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
