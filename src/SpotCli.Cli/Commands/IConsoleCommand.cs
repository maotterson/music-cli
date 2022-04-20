using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace SpotCli.Cli.Commands;

public interface IConsoleCommand
{
    public Task<IApiResponse> ExecuteAsync();
}
