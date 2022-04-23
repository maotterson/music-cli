using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Factories;

public interface ICommandLineOptionsResolver
{
    public IValidCommand? BuildFromArgs(string[] args);
}
