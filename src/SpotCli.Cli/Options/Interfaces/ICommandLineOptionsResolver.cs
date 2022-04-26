namespace SpotCli.Cli.Options.Interfaces;

public interface ICommandLineOptionsResolver
{
    public void ParseOptions(string[] args);
}
