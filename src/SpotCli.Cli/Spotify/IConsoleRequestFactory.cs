using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify;

internal interface IConsoleRequestFactory
{
    public IConsoleRequest GetRequestObject(string[] args);
}
