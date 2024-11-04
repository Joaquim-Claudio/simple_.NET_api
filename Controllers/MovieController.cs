
using System.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace empty.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("/api/movies/")]
public class MovieController : Controller
{

    private readonly MovieDataContext _context;

    public MovieController(MovieDataContext context) => _context = context;
    
    [HttpGet("")]
    public ActionResult<List<Movie>> GetAll()
    {
        var movies = _context.Movies.ToList();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Movie> GetById(int id)
    {
        var movie = _context.Movies.Where(m => m.Id == id);
        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddMovie([FromBody]Movie movie)
    {
        movie.ReleaseDate = DateOnly.FromDateTime(DateTime.Now);
        
        _context.Add(movie);
        _context.SaveChanges();
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateMovie([FromBody] Movie updatedMovie, int id)
    {
        updatedMovie.UpdateDate = DateOnly.FromDateTime(DateTime.Now);

        _context.Update(updatedMovie);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteMovie(int id)
    {
        Movie movie = new Movie() {Id = id};
        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }

}