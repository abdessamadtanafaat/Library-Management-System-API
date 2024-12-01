using LibraryAppWebApi.Models;
using LibraryAppWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAppWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService; 
    }

    // Action pour récupérer tous les livres.
    [HttpGet]
    public IEnumerable<Book> GetAllBooks() => _bookService.GetAllBooks();

    // Action pour rechercher un livre par titre.
    [HttpGet("{title}")]
    public ActionResult<Book> GetBookByTitle(string title)
    {
        var book = _bookService.GetBookByTitle(title);
        if (book == null) return NotFound("Book not found");
        return Ok(book); 
    }

    // Action pour ajouter un nouveau livre.
    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        try
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookByTitle), new { title = book.Title }, book);  // Return the 'book' object
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message); 
        }
    }


    // Action pour mettre à jour un livre existant par son ISBN.
    [HttpPut("{isbn}")]
    public IActionResult UpdateBook(string isbn, Book book)
    {
        try
        {
            _bookService.UpdateBook(isbn, book);
            return NoContent(); 
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }
    // Action pour supprimer un livre par son ISBN.
    [HttpDelete("{isbn}")]
    public IActionResult DeleteBook(string isbn)
    {
        try
        {
            _bookService.DeleteBook(isbn);
            return NoContent(); 
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}