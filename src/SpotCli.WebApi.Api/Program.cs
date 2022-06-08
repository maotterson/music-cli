using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using SpotCli.WebApi.Api.Auth;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Repositories;
using SpotCli.WebApi.Api.Services;
using SpotCli.WebApi.Api.Settings;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<ILambdaAuthenticator, LambdaAuthenticator>(_ =>
{
    return new LambdaAuthenticator(builder.Configuration["SecretKey"]);
});
builder.Services.AddSingleton<MongoClient>(_ =>
{
    return new MongoClient(builder.Configuration["MongoDb:ConnectionString"]);
});
builder.Services.AddSingleton<RatingCollectionSettings>(_ => {
    return builder.Configuration.GetSection("MongoDB").Get<RatingCollectionSettings>();
});
builder.Services.AddSingleton<IRatingService, RatingService>();
builder.Services.AddSingleton<IRatingRepository, MongoRatingRepository>();

builder.Services.AddControllers();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("auth", new OpenApiSecurityScheme
    {
        Description = "Authorization key",
        In = ParameterLocation.Header,
        Name = "Authorization"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseLambdaAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
