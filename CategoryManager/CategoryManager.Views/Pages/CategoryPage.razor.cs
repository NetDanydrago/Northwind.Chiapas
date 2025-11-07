using CategoryManager.ViewModels.Models;
using CategoryManager.ViewModels.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
namespace CategoryManager.Views.Pages;

public partial class CategoryPage : IDisposable
{
    [Inject]
    public SearchCategoryViewModel ViewModel { get; set; }

    [Inject]
    public ActionCategoryViewModel ActionCategoryViewModel { get; set; }

    [Inject]
    public ILogger<CategoryPage> Logger { get; set; }


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
        ActionCategoryViewModel.OnFailure += HandleFailure;
        await ViewModel.InitializeViewModel();
        await ActionCategoryViewModel.InitializeViewModel();
    }


    private async Task OpenCreateModal()
    {
        ShowCreateModal = true;
    }

    private void OpenEditModal(CategoryModel category)
    {
        ActionCategoryViewModel.LoadCategoryToEdit(category);
        ShowEditModal = true;
    }


    private async Task CreateAsync()
    {
        try
        {
            IsLoading = true;
            var result = await ActionCategoryViewModel.CreateCategoryAsync();
            if (result)
            {
                ShowCreateModal = false;
                await ViewModel.LoadCategoriesAsync();
                ActionCategoryViewModel.Category  = new();
                ShowSuccessToast("✨ Categoría creada exitosamente");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error al crear categoría.");
            ShowErrorToast("❌ Error al crear la categoría");
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
            var result = await ActionCategoryViewModel.UpdateCategoryAsync();
            if (result)
            {
                ShowEditModal = false;
                await ViewModel.LoadCategoriesAsync();
                ShowSuccessToast("💾 Categoría actualizada exitosamente");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error al actualizar categoría.");
            ShowErrorToast("❌ Error al actualizar la categoría");
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
        ActionCategoryViewModel.OnFailure -= HandleFailure;
    }



    private async Task ConfirmDesactivateAsync()
    {
        try
        {
            IsLoading = true;
            ShowDesactivateConfirm = false;
            var result = await ActionCategoryViewModel.DesactivateCategoryAsync(PendingDesactivateId);
            if (result)
            {
                await ViewModel.LoadCategoriesAsync();
                ShowSuccessToast("🕯️ Categoría desactivada exitosamente");
            }

        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error al desactivar categoría.");
            ShowErrorToast("❌ Error al desactivar la categoría");
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
