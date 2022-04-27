using CommandLine;
using SpotCli.Cli.Options.Interfaces;

namespace SpotCli.Cli.Options.Search;

[Verb("search")]
public class SearchForItemOptions : IConsoleOptions
{
    [Option('q', "query", Required = false, HelpText = "Search query.")]
    public string? Query { get; set; }
}
