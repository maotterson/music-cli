using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Core.ValueObjects;
public class ArtistVO
{
    public ArtistVO(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception("Invalid artist name."); // todo more specific exception class
        }
        Value = value;
    }

    public string Value { get; set; }
}
