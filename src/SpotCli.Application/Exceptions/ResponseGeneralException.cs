using SpotCli.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Application.Exceptions;

public class ResponseGeneralException : ResponseCodeException
{
    private static readonly string RESPONSE_MESSAGE = "An unexpected error was returned by the server. Please try again later.";
    public ResponseGeneralException(IValidRequest command)
        : base($"{command.Description} unsuccessful. {RESPONSE_MESSAGE}", -1, command)
    {
    }
}
