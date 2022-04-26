using SpotCli.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.Exceptions;

public class Response403Exception : ResponseCodeException
{
    private static readonly string RESPONSE_MESSAGE = "Bad OAuth request. Potentially malformed request header or body.";
    public Response403Exception(IValidRequest command)
        : base($"{command.Description} unsuccessful. {RESPONSE_MESSAGE}.", 403, command)
    {
    }
}
