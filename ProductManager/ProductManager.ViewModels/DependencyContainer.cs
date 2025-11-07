using ProductManager.ViewModels.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ProductManager.ViewModels;
public static class DependencyContainer
{
    public static IServiceCollection AddProductManagerViewModels(this IServiceCollection services)
    {
        services.AddScoped<SearchProductViewModel>();
        services.AddScoped<ActionProductViewModel>();
        return services;
    }

}
