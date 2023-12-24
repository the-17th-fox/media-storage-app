using AutoMapper;
using EntityFrameworkCore.Helpers;
using EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Tags;

namespace UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCasesDependencies(
        this IServiceCollection services)
    {
        services.AddUtilities();

        services.AddScoped<ITagsService, TagsService>();

        return services;
    }

    private static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Profile));

        return services;
    }
}