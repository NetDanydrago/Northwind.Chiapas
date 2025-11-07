namespace Domain.Products;
public class ProductDto(int id, string name, string description, int categoryId, bool isActive, string categoryName)
{
    public int Id => id;
    public string Name => name;
    public string Description => description;
    public int CategoryId => categoryId;

    public bool IsActive => isActive;
    public string CategoryName => categoryName;
}
