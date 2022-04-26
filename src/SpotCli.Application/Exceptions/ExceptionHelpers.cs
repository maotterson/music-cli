using Refit;
using SpotCli.Application.Interfaces;
using System.Net;

namespace SpotCli.Application.Exceptions;

public static class ExceptionHelpers
{
    public static ResponseCodeException AsException(this HttpStatusCode code, IValidRequest request)
        => (int)code switch
    {
        401 => new Response401Exception(request),
        403 => new Response403Exception(request),
        429 => new Response429Exception(request),
        _ => new ResponseGeneralException(request)
    };

    public static void CheckForErrorStatusCode(this IApiResponse response, IValidRequest request)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw response.StatusCode.AsException(request);
        }
    }
}
