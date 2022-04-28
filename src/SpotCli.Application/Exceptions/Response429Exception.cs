using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Exceptions;

public class Response429Exception : ResponseCodeException
{
    private static readonly string RESPONSE_MESSAGE = "Rate limit exceeded, try waiting before performing additional commands.";
    public Response429Exception(IValidRequest command)
        : base($"{command.Description} unsuccessful. {RESPONSE_MESSAGE}", 429, command)
    {
    }
}
