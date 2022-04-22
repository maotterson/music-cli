using System.Text;

namespace SpotCli.Application.OAuth.Utils;

public record Base64ClientSecretAuthHeader
{
    private string _clientSecret;
    private string _clientId;

    public Base64ClientSecretAuthHeader(string clientSecret, string clientId)
    {
        _clientSecret = clientSecret;
        _clientId = clientId;
    }

    public string Get()
    {
        var base64 = Base64Encode($"{_clientId}:{_clientSecret}");
        return $"Basic {base64}";
    }
    private static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
}
