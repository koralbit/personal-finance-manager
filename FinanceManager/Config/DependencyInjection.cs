using Auth0.AspNetCore.Authentication;
using FinanceManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

namespace FinanceManager.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogger();

        services.AddAuth0(configuration);
        return services;
    }

    private static void AddLogger(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information ()
            .MinimumLevel.Override("Default", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            .WriteTo.Console(new CompactJsonFormatter())
            .WriteTo.File(new CompactJsonFormatter(), "Logs/log.txt", rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithProperty("Application", "FinanceManager")
            .CreateLogger();
        services.AddSerilog(Log.Logger);
    }

    private static void AddAuth0(this IServiceCollection services, IConfiguration configuration)
    {
        Auth0Credentials? auth0Credentials = new();
        auth0Credentials = configuration.GetSection("Auth0").Get<Auth0Credentials>();

        if (auth0Credentials == null)
        {
            throw new Exception("Auth0 credentials not found");
        }
        Auth0CredentialsValidator auth0Validator = new();
        var validationResult = auth0Validator.Validate(auth0Credentials);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                Log.Logger.Error(error.ErrorMessage);
            }
            throw new Exception("Auth0 credentials are invalid");
        }
        Log.Logger.Debug("Auth0 credentials are valid, Auth0Credentials : {@Credentialsn}", auth0Credentials);
        services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = auth0Credentials.Domain;
                options.ClientId = auth0Credentials.ClientId;
                options.Scope = ("openid profile email");
            });
    }
    
}
