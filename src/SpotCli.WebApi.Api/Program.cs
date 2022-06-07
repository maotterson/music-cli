using SpotCli.WebApi.Api.Auth;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRatingRepository, LocalRatingRepository>();
builder.Services.AddSingleton<ILambdaAuthenticator, LambdaAuthenticator>(_ =>
{
    return new LambdaAuthenticator(builder.Configuration["SecretKey"]);
});

builder.Services.AddControllers();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
