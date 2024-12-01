using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(int id, Author author);
        Task DeleteAuthorAsync(int id);
    }
}