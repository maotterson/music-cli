using SpotCli.Cli.Spotify.Commands;

namespace SpotCli.Cli.Spotify;

public class ConsoleCommandFactory : IConsoleCommandFactory
{
    private readonly Dictionary<string, IConsoleCommand> _dictionary;
    public ConsoleCommandFactory()
    {
        _dictionary = InitializeDictionaryUsingActivator();
    }

    public IConsoleCommand GetRequestObject(string[] args)
    {
        string argument = args[0].ToLower();
        var request = _dictionary[argument];
        return request;
    }

    private Dictionary<string, IConsoleCommand> InitializeDictionaryUsingActivator()
    {
        var commandInterfaceType = typeof(IConsoleCommand);
        var dict = commandInterfaceType.Assembly.ExportedTypes
            .Where(type => commandInterfaceType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(type =>
            {
                return Activator.CreateInstance(type);
            })
            .Cast<IConsoleCommand>()
            .ToDictionary(request => request.ConsoleArgument, command => command);
        return dict;
    }
}
