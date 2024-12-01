using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound(); 
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            var createdGenre = await _genreService.CreateGenreAsync(genre);
            return CreatedAtAction(nameof(GetGenre), new { id = createdGenre.Id }, createdGenre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            var updatedGenre = await _genreService.UpdateGenreAsync(id, genre);
            if (updatedGenre == null)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }

        // DELETE: api/genres/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent(); 
        }
    }
}
