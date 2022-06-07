namespace SpotCli.WebApi.Api.Auth;

public class LambdaAuthenticator : ILambdaAuthenticator
{
    private readonly string _secretKey;
    public LambdaAuthenticator(string secretKey)
    {
        _secretKey = secretKey;
    }
    public bool Verify(string secret)
    {
        return secret == _secretKey;
    }
}
