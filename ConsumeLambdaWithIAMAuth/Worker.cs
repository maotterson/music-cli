using ConsumeLambdaWithIAMAuth.Apis;
using ConsumeLambdaWithIAMAuth.Credentials;

namespace ConsumeLambdaWithIAMAuth;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ILambdaApi _api;
    private readonly ICredentialsService _credentialsService;

    public Worker(ILogger<Worker> logger, ILambdaApi api, ICredentialsService credentialsService)
    {
        _logger = logger;
        _api = api;
        _credentialsService = credentialsService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var credentials = _credentialsService.GetAuthSignature();
        var ratings = await _api.GetRatings();
        while (!stoppingToken.IsCancellationRequested)
        {
            
            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
