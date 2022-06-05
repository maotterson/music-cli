using ConsumeLambdaWithIAMAuth;
using ConsumeLambdaWithIAMAuth.Apis;
using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddRefitClient<ILambdaApi>()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(hostContext.Configuration.GetSection("BaseAddress").Value);
        });
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
