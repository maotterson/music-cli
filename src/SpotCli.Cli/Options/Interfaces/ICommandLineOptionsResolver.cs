using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Factories;

public interface ICommandLineOptionsResolver
{
    public void ParseOptions(string[] args);
}
