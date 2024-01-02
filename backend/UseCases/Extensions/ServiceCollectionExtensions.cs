using System.Reflection;
using AutoMapper;
using EntityFrameworkCore.Helpers;
using EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Media;
using UseCases.Tags;
using UseCases.Tags.Helpers;

namespace UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCasesDependencies(
        this IServiceCollection services)
    {
        services.AddUtilities();

        services.AddScoped<ITagsService, TagsService>();
        services.AddScoped<IImagesService, ImagesService>();

        return services;
    }

    private static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}