using Microsoft.Extensions.Configuration;
using Amazon;
using Amazon.Runtime;
using System.Text.Json;
using Amazon.Lambda;
using Amazon.Lambda.Model;

IConfiguration env = new ConfigurationBuilder()
	.SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
	.AddJsonFile("appsettings.development.json", false)
	.Build();

var access = env.GetSection("access").Value;
var secret = env.GetSection("secret").Value;

var credentials = new BasicAWSCredentials(access, secret);
var config = new AmazonLambdaConfig
{
	RegionEndpoint = RegionEndpoint.USEast1
};
var client = new AmazonLambdaClient(credentials, config);

var function = new InvokeRequest
{
	FunctionName = env.GetSection("function").Value,
	InvocationType = InvocationType.RequestResponse,
	Payload = JsonSerializer.Serialize("hello world")
};

try
{
	InvokeResponse response = await client.InvokeAsync(function);
	var payload = response.Payload;
	using(var streamReader = new StreamReader(payload))
    {
        while (!streamReader.EndOfStream)
        {
			var line = streamReader.ReadLine();
			Console.WriteLine(line);
        }
    }
	Console.ReadLine();
}
catch(Exception ex)
{
	Console.WriteLine(ex.Message);
}