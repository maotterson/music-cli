using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Exceptions;

public abstract class ResponseCodeException : Exception
{
    public int ErrorCode { get; init; }
    public IValidRequest Command { get; init; }

    public ResponseCodeException(string? message, int errorCode, IValidRequest command) : base(message)
    {
        ErrorCode = errorCode;
        Command = command;
    }
}
