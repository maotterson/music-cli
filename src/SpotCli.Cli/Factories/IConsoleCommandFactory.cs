using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Factories;

public interface IConsoleCommandFactory
{
    public IValidCommand? BuildFromArgs(string[] args);
}
