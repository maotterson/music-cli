using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Core.Exceptions;
public class TrackNotFoundException : Exception
{
    public TrackNotFoundException(string id) : base($"Track {id} not found.")
    {

    }
    public TrackNotFoundException() : base($"Track not found.")
    {

    }
}
