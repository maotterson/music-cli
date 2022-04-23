using MediatR;
using SpotCli.Application.Interfaces;

namespace SpotCli.Application.Exceptions;

public abstract class ResponseCodeException : Exception
{
    public int ErrorCode { get; init; }
    public IValidCommand Command { get; init; }

    public ResponseCodeException(string? message, int errorCode, IValidCommand command) : base(message)
    {
        ErrorCode = errorCode;
        Command = command;
    }
}
