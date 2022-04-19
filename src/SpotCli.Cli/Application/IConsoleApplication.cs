using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Application;

public interface IConsoleApplication
{
    public Task RunAsync(string[] args);
}
