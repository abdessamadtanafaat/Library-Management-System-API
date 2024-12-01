using LibraryAppWebApi.Models;

namespace LibraryAppWebApi.Services;

public class BookService : IBookService
{
    // Retrieves all books from the data source.
    public IEnumerable<Book> GetAllBooks() => Data.Data.books;

    // Retrieves a book by its title, ignoring case sensitivity.
    public Book GetBookByTitle(string title)
    {
        return Data.Data.books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase)); 
    }

    // Adds a new book to the data source after validation.
    public void AddBook(Book book)
    {
        ValidateBook(book); 
        Data.Data.books.Add(book);
    }

    // Updates an existing book's details based on its ISBN.
    public void UpdateBook(string isbn, Book updatedBook)
    {
        var existingBook = Data.Data.books.FirstOrDefault(b => b.ISBN == isbn);
        if (existingBook == null) throw new Exception("Book Not Found");

        ValidateBook(updatedBook);

        // Updates the fields of the existing book.
        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.Price = updatedBook.Price;
        existingBook.CopiesAvailable = updatedBook.CopiesAvailable; 
    }

    // Deletes a book from the data source based on its ISBN.
    public void DeleteBook(string isbn)
    {
        var book = Data.Data.books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null) throw new Exception();
        Data.Data.books.Remove(book); 
    }

    // Validates a book's fields to ensure they meet certain criteria.
    private void ValidateBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title)) throw new ArgumentException("Title cannot be empty.");
        if (string.IsNullOrWhiteSpace(book.ISBN)) throw new ArgumentException("ISBN cannot be null.");
        if (book.Price <= 0) throw new ArgumentException("Price Must be greater than 0");
        if (book.CopiesAvailable < 0) throw new ArgumentException("Copies available must be positive"); 
    }
}
