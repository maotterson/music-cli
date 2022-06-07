using SpotCli.WebApi.Api.Auth;

namespace SpotCli.WebApi.Api.Common;

public static class AuthMiddleware
{
    public static IApplicationBuilder UseLambdaAuthentication(this IApplicationBuilder builder)
    {
        builder.Use(async (httpContext, next) =>
        {
            var authenticator = builder.ApplicationServices.GetRequiredService<ILambdaAuthenticator>();
            var secret = httpContext.Request.Headers.Authorization;
            var isVerified = authenticator.Verify(secret);

            if (!isVerified)
            {
                httpContext.Response.StatusCode = 403;
                return;
            }
            await next(httpContext);
        });
        return builder;
    }
}
