using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Area.Context;
using Movie_Area.Dtos;
using Movie_Area.Entities;

namespace Movie_Area.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {  
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public  ActionResult CreateCategory(CategoryDTO model)
        {

            Category category = new()
            {
                CategoryName = model.CategoryName,
                CategoryDescription = model.CategoryDescription,
         
            };//Mapplemek
            _context.Categories.Add(category);
            if(_context.SaveChanges()>0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory([FromRoute] Guid categoryId)
        {
            Category category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                if (_context.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            if (categories is not null)
            {
                return Ok(categories);
            }
            return BadRequest();
        }

        [HttpPut("{categoryId}")]

        public ActionResult UpdateCategory([FromRoute]Guid categoryId,CategoryDTO model)
        {
            Category category = _context.Categories.Find(categoryId);
            if (category is not null)
            {
                return Ok(category);
            }
            return BadRequest();
        } 
    }
}
