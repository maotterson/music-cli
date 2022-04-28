using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Exceptions;

public class Response401Exception : ResponseCodeException
{
    private static readonly string RESPONSE_MESSAGE = "Bad or expired token. Claim a new access token with the 'refresh' command or redo authentication for a new refresh token.";
    public Response401Exception(IValidRequest command)
        : base($"{command.Description} unsuccessful. {RESPONSE_MESSAGE}", 401, command)
    {
    }
}
