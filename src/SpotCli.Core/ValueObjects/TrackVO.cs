using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Core.ValueObjects;
public class TrackVO
{
    public TrackVO(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception("Invalid track name."); // todo more specific exception object
        }
        Value = value;
    }

    public string Value { get; init; }
}
