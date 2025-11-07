using ProductManager.Proxy;
using ProductManager.ViewModels.Adapters;
using ProductManager.ViewModels.Models;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace ProductManager.ViewModels.ViewModels;

public class ActionProductViewModel(ProductProxy proxy, ILogger<ActionProductViewModel> logger)
{
    public ProductModel Product { get; set; }

    public event EventHandler<string>? OnFailure;

    public Task InitializeViewModel()
    {
        Product = new();
        return Task.CompletedTask;
    }

    public void LoadProductToEdit(ProductModel product)
    {
        Product = product;
    }

    public async Task<bool> CreateProductAsync()
    {
        HandlerRequestResult result = await proxy.AddProductAsync(Product.ToDto());
        if (!result.Success)
        {
            logger.LogError("Failed to save product: {ErrorMessage}", result.ErrorMessage);
            OnFailure?.Invoke(this, result.ErrorMessage);
        }
        return result.Success;
    }

    public async Task<bool> UpdateProductAsync()
    {
        HandlerRequestResult result = await proxy.UpdateProductAsync(Product.ToDto());
        if (!result.Success)
        {
            logger.LogError("Failed to update product {Id}: {ErrorMessage}", Product.Id, result.ErrorMessage);
            OnFailure?.Invoke(this, result.ErrorMessage);
        }
        return result.Success;
    }

    public async Task<bool> DesactivateProductAsync(int id)
    {
        HandlerRequestResult result = await proxy.DesactivateProductAsync(id);
        if (!result.Success)
        {
            logger.LogError("Failed to delete product {Id}: {ErrorMessage}", id, result.ErrorMessage);
            OnFailure?.Invoke(this, result.ErrorMessage);
        }
        return result.Success;
    }
}
