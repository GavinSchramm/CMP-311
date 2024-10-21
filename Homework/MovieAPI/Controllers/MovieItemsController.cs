using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieItemsController : ControllerBase
{
    private readonly MovieContext _context;

    public MovieItemsController(MovieContext context)
    {
        _context = context;
    }

    // GET: api/MovieItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieItemDTO>>> GetMovieItems()
    {
        return await _context.MovieItems
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }

    // GET: api/MovieItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieItemDTO>> GetMovieItem(long id)
    {
        var movieItem = await _context.MovieItems.FindAsync(id);

        if (movieItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(movieItem);
    }
    // </snippet_GetByID>

    // PUT: api/MovieItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMovieItem(long id, MovieItemDTO movieDTO)
    {
        if (id != movieDTO.Id)
        {
            return BadRequest();
        }

        var movieItem = await _context.MovieItems.FindAsync(id);
        if (movieItem == null)
        {
            return NotFound();
        }

        movieItem.Title = movieDTO.Title;
        movieItem.Year = movieDTO.Year;
        movieItem.Rating = movieDTO.Rating;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!MovieItemExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }
    // </snippet_Update>

    // POST: api/MovieItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<MovieItemDTO>> PostMovieItem(MovieItemDTO movieDTO)
    {
        var movieItem = new MovieItem
        {
            Year = movieDTO.Year,
            Title = movieDTO.Title,
            Rating = movieDTO.Rating
        };

        _context.MovieItems.Add(movieItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetMovieItem),
            new { id = movieItem.Id },
            ItemToDTO(movieItem));
    }
    // </snippet_Create>

    // DELETE: api/MovieItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovieItem(long id)
    {
        var movieItem = await _context.MovieItems.FindAsync(id);
        if (movieItem == null)
        {
            return NotFound();
        }

        _context.MovieItems.Remove(movieItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MovieItemExists(long id)
    {
        return _context.MovieItems.Any(e => e.Id == id);
    }

    private static MovieItemDTO ItemToDTO(MovieItem movieItem) =>
       new MovieItemDTO
       {
           Id = movieItem.Id,
           Title = movieItem.Title,
           Year = movieItem.Year,
           Rating = movieItem.Rating
       };
}