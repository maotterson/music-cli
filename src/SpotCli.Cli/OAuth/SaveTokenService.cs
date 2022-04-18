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
        using (FileStream fs = File.Create("token.txt"))
        {
            var sw = new StreamWriter(fs);
            sw.Write(token);
        }
        return $"New token saved.";
    }
}
