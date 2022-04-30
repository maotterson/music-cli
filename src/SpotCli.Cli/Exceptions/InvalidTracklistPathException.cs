namespace SpotCli.Cli.Exceptions;

internal class InvalidTracklistPathException : Exception
{
    public InvalidTracklistPathException() : base("Invalid playlist provided, please try again.") { }
}
