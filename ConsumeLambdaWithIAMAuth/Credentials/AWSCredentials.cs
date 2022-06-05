using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeLambdaWithIAMAuth.Credentials;
public class AWSCredentials
{
    public string AccessKeyId { get; init; }
    public string SecretAccessKey { get; init; }
    public string AwsRegion { get; init; }
    public string ServiceName { get; init; }
}
