using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeLambdaWithIAMAuth.Credentials;
public class CredentialsService : ICredentialsService
{
    private readonly AWSCredentials _credentials;
    private readonly string _sessionToken;

    public CredentialsService(AWSCredentials credentials, string sessionToken)
    {
        _credentials = credentials;
        _sessionToken = sessionToken;
    }

    public AWSCredentials GetAuthSignature()
    {
        return _credentials;
    }
}
