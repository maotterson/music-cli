using ConsumeLambdaWithIAMAuth.Apis;

namespace ConsumeLambdaWithIAMAuth;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ILambdaApi _api;

    public Worker(ILogger<Worker> logger, ILambdaApi api)
    {
        _logger = logger;
        _api = api;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var ratings = await _api.GetRatings();
        while (!stoppingToken.IsCancellationRequested)
        {
            
            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
