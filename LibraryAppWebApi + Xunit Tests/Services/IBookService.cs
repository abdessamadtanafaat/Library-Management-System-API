using LibraryAppWebApi.Models;

namespace LibraryAppWebApi.Services;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book GetBookByTitle(string title);
    void AddBook(Book book);
    void UpdateBook(string isbn, Book Updatedbook);
    void DeleteBook(string isbn); 
}