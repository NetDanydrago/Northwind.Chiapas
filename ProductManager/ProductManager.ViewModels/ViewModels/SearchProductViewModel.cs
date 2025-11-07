using ProductManager.Proxy;
using ProductManager.ViewModels.Adapters;
using ProductManager.ViewModels.Models;
using Domain.Products;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace ProductManager.ViewModels.ViewModels;
public class SearchProductViewModel(ProductProxy proxy, ILogger<SearchProductViewModel> logger)
{
    public List<ProductModel> Products { get; set; }

    public EventHandler<string> OnFailure { get; set; }

    public async Task InitializeViewModel()
    {
        await LoadProductsAsync();
    }


    public async Task LoadProductsAsync()
    {
        HandlerRequestResult<IEnumerable<ProductDto>> result;
        result = await proxy.GetAllProductsAsync();
        if (result.Success)
        {
            Products = result.SuccessValue.ToModelList();
        }
        else
        {
            logger.LogError("Failed to load products: {ErrorMessage}", result.ErrorMessage);
            OnFailure?.Invoke(this, result.ErrorMessage);
        }
    }
}
