using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Commands;

public interface ICommandFactory<T>
{
    public IConsoleCommand CreateCommand(string[] args);
}
