using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify;

public class ConsoleRequestFactory : IConsoleRequestFactory
{
    private readonly Dictionary<string, IConsoleRequest> _dictionary;
    public ConsoleRequestFactory()
    {
        _dictionary = InitializeDictionaryUsingActivator();
    }

    public IConsoleRequest GetRequestObject(string[] args)
    {
        string argument = args[0].ToLower();
        var request = _dictionary[argument];
        return request;
    }

    private Dictionary<string, IConsoleRequest> InitializeDictionaryUsingActivator()
    {
        var commandInterfaceType = typeof(IConsoleRequest);
        var dict = commandInterfaceType.Assembly.ExportedTypes
            .Where(type => commandInterfaceType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(type =>
            {
                return Activator.CreateInstance(type);
            })
            .Cast<IConsoleRequest>()
            .ToDictionary(request => request.ConsoleArgument, command => command);
        return dict;
    }
}
