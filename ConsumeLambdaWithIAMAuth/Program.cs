using ConsumeLambdaWithIAMAuth;
using ConsumeLambdaWithIAMAuth.Apis;
using ConsumeLambdaWithIAMAuth.Credentials;
using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("Token/sessiontoken.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<ICredentialsService, CredentialsService>(_ =>
        {
            var credentials = hostContext.Configuration
                .GetSection("AWSCredentials")
                .Get<AWSCredentials>();
            var sessionToken = hostContext.Configuration
                .GetSection("SessionToken").Value;
            return new CredentialsService(credentials, sessionToken);
        });
        services.AddRefitClient<ILambdaApi>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(hostContext.Configuration
                    .GetSection("BaseAddress").Value);
            });
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
