using System.ComponentModel.DataAnnotations;

namespace ProductManager.ViewModels.Models;
public class ProductModel
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    [Required, StringLength(500)]
    public string Description { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public bool IsActive { get; set; }
    public string CategoryName { get; set; }
}
