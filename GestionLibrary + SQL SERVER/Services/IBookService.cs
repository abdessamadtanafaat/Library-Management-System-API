using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book book);
        Task DeleteBookAsync(int id);
    }
}