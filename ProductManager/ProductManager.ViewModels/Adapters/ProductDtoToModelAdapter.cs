using ProductManager.ViewModels.Models;
using Domain.Products;

namespace ProductManager.ViewModels.Adapters;
internal static class ProductDtoToModelAdapter
{
    public static ProductModel ToModel(this ProductDto dto)
    {
        return new ProductModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName,
            IsActive = dto.IsActive
        };
    }

    public static List<ProductModel> ToModelList(this IEnumerable<ProductDto> dtoList)
    {
        List<ProductModel> products = new List<ProductModel>();
        if (dtoList != null)
        {
            products = dtoList.Select(dto => dto.ToModel()).ToList();
        }
        return products;
    }

    public static ProductDto ToDto(this ProductModel model)
    {
        return new ProductDto(
            id: model.Id,
            name: model.Name,
            description: model.Description,
            categoryId: model.CategoryId,
            isActive: model.IsActive,
            categoryName: model.CategoryName
        );
    }
}
