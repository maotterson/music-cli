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

var function = new InvokeRequest
{
	FunctionName = env.GetSection("function").Value,
	InvocationType = InvocationType.RequestResponse,
	Payload = JsonSerializer.Serialize("hello world")
};
using (var client = new AmazonLambdaClient(credentials, config))
{

	InvokeResponse response = await client.InvokeAsync(function);
	Console.WriteLine(response);
};
Console.ReadLine();