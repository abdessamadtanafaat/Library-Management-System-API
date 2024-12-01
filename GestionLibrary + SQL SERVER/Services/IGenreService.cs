using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task<Genre> CreateGenreAsync(Genre genre);
        Task<Genre> UpdateGenreAsync(int id, Genre genre);
        Task DeleteGenreAsync(int id);
    }
}