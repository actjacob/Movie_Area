using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Area.Context;
using Movie_Area.Dtos;
using Movie_Area.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Area.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult CreateMovie(MovieDTO model)
        {

            Movie movie = new()
            {
                Director = model.Director,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Revenue = model.Revenue,
                Description = model.Description,
                CategoryId = model.CategoryId,
            };//Mapplemek
            _context.Movies.Add(movie);
            if (_context.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{movieId}")]
        public ActionResult DeleteMovie([FromRoute] Guid movieId)
        {
            Movie movie = _context.Movies.Find(movieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                if (_context.SaveChanges() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetAllMovie()
        {
            List<Movie> categories = _context.Movies.ToList();
            if (categories is not null)
            {
                return Ok(categories);
            }
            return BadRequest();
        }
        [HttpPut("{movieId}")]
        public ActionResult UpdateMovie([FromRoute] Guid movieId, MovieDTO model)
        {
            Movie movie = _context.Movies.Find(movieId);
            if (movie is not null)
            {
                return Ok(movie);
            }
            return BadRequest();
        }


        [HttpGet("{movieId}")]
        public ActionResult GetMovieById([FromRoute] Guid movieId)
        {
            Movie movie = _context.Movies.Find(movieId);
            if (movie is not null)
            {
                return Ok();    
            }
            return NotFound();
        }





        [HttpGet("{categoryId}")]

        public ActionResult GetMovieByCategoryId([FromRoute] Guid categoryId)
        {
            List<Movie> movies = _context.Movies.Where(x => x.CategoryId == categoryId).ToList();
            if (movies is not null)
            {
                return Ok(movies);
            }
            return NotFound();
        }  

    }
}
