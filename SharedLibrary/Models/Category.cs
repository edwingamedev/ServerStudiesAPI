using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models;

[Table("Categories")] // not necessary, already defined on the AppDbContext
public class Category
{
    [Key] // not necessary, Id (or CategoryId) is already mapped as the primary key by the Pattern
    public int Id { get; set; }
    
    [Required]
    [StringLength(80)]
    public string? Name  { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? ImgUrl  { get; set; }

    public ICollection<Product>? Products { get; set; }

    public Category()
    {
        Products = new Collection<Product>();
    }
}