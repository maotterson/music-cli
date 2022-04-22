using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Commands;

public interface IValidCommand
{
    public string Description { get; }
}
