using Microsoft.Extensions.Configuration;
using Amazon;
using Amazon.Runtime;
using Amazon.Lambda;
using Amazon.Lambda.Model;

IConfiguration env = new ConfigurationBuilder()
	.SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
	.AddJsonFile("appsettings.json", false)
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
	InvocationType = InvocationType.Event
};
var response = await client.InvokeAsync(function);
Console.WriteLine(response);
Console.ReadLine();