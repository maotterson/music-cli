namespace SpotCli.Cli.Services;

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
