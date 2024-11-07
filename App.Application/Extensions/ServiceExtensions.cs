

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using App.Application.Features.Products;
using App.Application.Features.Categories;


namespace App.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddExceptionHandler<CriticalExceptionHandler>();
        //services.AddExceptionHandler<GlobalExceptionHandler>();
        return services;
    }


}
