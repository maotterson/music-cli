using Refit;
using SpotCli.Application.Interfaces;
using System.Net;

namespace SpotCli.Application.Exceptions;

public static class ExceptionHelpers
{
    public static ResponseCodeException AsException(this HttpStatusCode code, IValidRequest command)
        => (int)code switch
    {
        401 => new Response401Exception(command),
        403 => new Response403Exception(command),
        429 => new Response429Exception(command),
        _ => new ResponseGeneralException(command)
    };

    public static void CheckForErrorStatusCode(this IApiResponse response, IValidRequest command)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw response.StatusCode.AsException(command);
        }
    }
}
