using SpotCli.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Core.ValueObjects;
public class SpotifyIdVO : ValueObject
{
    public SpotifyIdVO(string id)
    {
        if (string.IsNullOrEmpty(id) || !IsValidSpotifyIdFormat(id))
        {
            throw new Exception("Invalid Spotify Id"); // todo custom exception
        }
        Value = id;
    }
    public string Value { get; set; }
    private bool IsValidSpotifyIdFormat(string id)
    {
        // todo can check if a base 62 string (per spotify docs)
        return true;
    }


}
