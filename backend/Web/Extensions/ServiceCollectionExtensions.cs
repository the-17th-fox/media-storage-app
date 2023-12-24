using EntityFrameworkCore.Extensions;
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
    }
}