using EntityFrameworkCore.Extensions;
using Microsoft.IdentityModel.Tokens;
using Shared.Extensions;
using UseCases.Extensions;

namespace Web.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddEntityFrameworkCore(configuration);

		services.AddUseCasesDependencies();

		return services;
	}

	private static void AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");

		if (connectionString.IsNullOrWhiteSpace())
			throw new ArgumentNullException(nameof(connectionString));

		services.AddEntityFrameworkCoreDependencies(connectionString);
		
		services.ConfigureAppCors(configuration);
    }

	private static void ConfigureAppCors(this IServiceCollection services, IConfiguration configuration)
	{
		var policyName = configuration
			.GetSection($"CorsConfiguration:PolicyName")
			.Get<string>();
		
		var allowedOrigins = configuration
			.GetSection($"CorsConfiguration:AllowedCorsOrigins")
			.Get<string[]>();

		if (policyName.IsNullOrWhiteSpace() || allowedOrigins.IsNullOrEmpty())
		{
			Console.WriteLine("Missing CORS policy name or empty allowed origins list");
		}
		
		services.AddCors(options =>
		{
			options.AddPolicy(name: policyName!,
				policy  =>
				{
					policy
						.WithOrigins(allowedOrigins!)
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowAnyOrigin();
				});
		});
	}
}