using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly LibraryDbContext _context;

        public GenreService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> UpdateGenreAsync(int id, Genre genre)
        {
            var existingGenre = await _context.Genres.FindAsync(id);
            if (existingGenre == null) return null;

            existingGenre.Name = genre.Name;

            await _context.SaveChangesAsync();
            return existingGenre;
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return;

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}