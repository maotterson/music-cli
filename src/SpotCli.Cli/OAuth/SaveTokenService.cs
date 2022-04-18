using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotCli.Cli.OAuth;

public class SaveTokenService : ISaveTokenService
{
    public string Save(string token)
    {
        using (StreamWriter sw = new StreamWriter(File.Create("token.json")))
        {
            var tokenJson = "{\"BearerToken\":\"" + token + "\"}";
            sw.WriteLine(tokenJson);
        }
        return $"New token saved.";
    }
}
