namespace SpotCli.WebApi.Api.Auth;

public interface ILambdaAuthenticator
{
    bool Verify(string secret);
}
