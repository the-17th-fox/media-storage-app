using EntityFrameworkCore.Helpers;
using EntityFrameworkCore.Infrastructure;
using EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddEntityFrameworkCoreDependencies(
		this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<MediaStorageDbContext>(opt => opt.UseSqlServer(connectionString));
			
		services.AddScoped<IUserIdResolver, UserIdResolver>();

		services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

		return services;
	}
}