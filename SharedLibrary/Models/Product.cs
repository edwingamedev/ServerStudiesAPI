namespace SharedLibrary.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name  { get; set; }
    public string? Description  { get; set; }
    public decimal Price { get; set; }
    public string? ImgUrl  { get; set; }    
    public float Stock { get; set; }
    public DateTime CreatedAt { get; set; }
}