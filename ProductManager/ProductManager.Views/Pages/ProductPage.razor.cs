using ProductManager.ViewModels.Models;
using ProductManager.ViewModels.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
namespace ProductManager.Views.Pages;

public partial class ProductPage : IDisposable
{
    [Inject]
    public SearchProductViewModel ViewModel { get; set; }

    [Inject]
    public ActionProductViewModel ActionProductViewModel { get; set; }

    [Inject]
    public ILogger<ProductPage> Logger { get; set; }


    private bool IsLoading;
    private bool ShowDesactivateConfirm;
    private int PendingDesactivateId;
    private bool ShowCreateModal;
    private bool ShowEditModal;

    // Toast properties
    private bool ShowToast;
    private string ToastMessage;
    private string ToastType = "success";

    protected override async Task OnInitializedAsync()
    {
        ViewModel.OnFailure += HandleFailure;
        ActionProductViewModel.OnFailure += HandleFailure;
        await ViewModel.InitializeViewModel();
        await ActionProductViewModel.InitializeViewModel();
    }


    private async Task OpenCreateModal()
    {
        ShowCreateModal = true;
    }

    private void OpenEditModal(ProductModel product)
    {
        ActionProductViewModel.LoadProductToEdit(product);
        ShowEditModal = true;
    }


    private async Task CreateAsync()
    {
        try
        {
            IsLoading = true;
            var result = await ActionProductViewModel.CreateProductAsync();
            if (result)
            {
                ShowCreateModal = false;
                await ViewModel.LoadProductsAsync();
                ActionProductViewModel.Product = new();
                ShowSuccessToast("✨ Producto creado exitosamente");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error al crear producto.");
            ShowErrorToast("❌ Error al crear el producto");
        }
        finally
        {
            IsLoading = false;
        }
    }
    private async Task UpdateAsync()
    {
        try
        {
            IsLoading = true;
            var result = await ActionProductViewModel.UpdateProductAsync();
            if (result)
            {
                ShowEditModal = false;
                await ViewModel.LoadProductsAsync();
                ShowSuccessToast("💾 Producto actualizado exitosamente");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error al actualizar producto.");
            ShowErrorToast("❌ Error al actualizar el producto");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async void HandleFailure(object? sender, string errorMessage)
    {
        ShowErrorToast(errorMessage);
    }

    public void Dispose()
    {
        ViewModel.OnFailure -= HandleFailure;
        ActionProductViewModel.OnFailure -= HandleFailure;
    }



    private async Task ConfirmDesactivateAsync()
    {
        try
        {
            IsLoading = true;
            ShowDesactivateConfirm = false;
            var result = await ActionProductViewModel.DesactivateProductAsync(PendingDesactivateId);
            if (result)
            {
                await ViewModel.LoadProductsAsync();
                ShowSuccessToast("🕯️ Producto desactivado exitosamente");
            }

        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error al desactivar producto.");
            ShowErrorToast("❌ Error al desactivar el producto");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async void ShowSuccessToast(string message)
    {
        DisplayToast(message, "success");
    }

    private async void ShowErrorToast(string message)
    {
        DisplayToast(message, "error");
    }

    private async void DisplayToast(string message, string type)
    {
        ToastMessage = message;
        ToastType = type;
        ShowToast = true;
        StateHasChanged();
        await Task.Delay(3000);
        ShowToast = false;
        StateHasChanged();
    }

}
