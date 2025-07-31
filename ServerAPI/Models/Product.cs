using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models;

[Table("Products")] // not necessary, already defined on the AppDbContext
public class Product
{
    [Key] // not necessary, Id (or ProductId) is already mapped as the primary key by the Pattern
    public int Id { get; set; }
        
    [Required]
    [StringLength(80)]
    public string? Name  { get; set; }
        
    [Required]
    [StringLength(300)]
    public string? Description  { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? ImgUrl  { get; set; } 
    
    public float Stock { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
}