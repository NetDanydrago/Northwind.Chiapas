
using Microsoft.Extensions.DependencyInjection;

namespace ProductManager.Proxy;
public static class DependencyContainer
{
    public static IServiceCollection AddProductManagerProxies(this IServiceCollection services, Action<HttpClient> configureProxy)
    {
        services.AddHttpClient<ProductProxy>(configureProxy);

        return services;
    } 
}
