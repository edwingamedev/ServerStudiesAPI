using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Context;
using SharedLibrary.Models;

namespace MyFirstAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ActionResult<IEnumerable<Category>> GetProductCategories()
    {
        //return _context.Categories.AsNoTracking().Include(p => p.Products).ToList();
        return _context.Categories.AsNoTracking().Include(p => p.Products).Where(c=>c.Id <= 5).ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        try
        {
            return _context.Categories.AsNoTracking().Take(10).ToList();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error when processing your request");
        }
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public ActionResult<Category> Get(int id)
    {
        try
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);

            if (category is null)
            {
                return NotFound("Category not found");
            }

            return category;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error when processing your request");
        }
    }

    [HttpPost]
    public ActionResult Post(Category category)
    {
        if (category is null)
        {
            return BadRequest();
        }

        _context.Categories.Add(category);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetCategory",
            new
            {
                id = category.Id
            }, category);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Category> Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category is null)
        {
            return NotFound("Product not found");
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return Ok(category); // just Ok() is fine.
    }
}