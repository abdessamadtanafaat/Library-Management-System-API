using System.Collections.Generic;
using LibraryAppWebApi.Controllers;
using LibraryAppWebApi.Models;
using LibraryAppWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace LibraryAPI.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { ISBN = "123", Title = "Book 1", Author = "Author 1", Price = 10.99, CopiesAvailable = 5 },
                new Book { ISBN = "456", Title = "Book 2", Author = "Author 2", Price = 15.49, CopiesAvailable = 3 }
            };
            _mockBookService.Setup(service => service.GetAllBooks()).Returns(books);

            // Act
            var result = _controller.GetAllBooks();

            // Assert
            var actionResult = Assert.IsType<List<Book>>(result);
            Assert.Equal(2, actionResult.Count);
        }

        [Fact]
        public void GetBookByTitle_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var book = new Book { ISBN = "123", Title = "Book 1", Author = "Author 1", Price = 10.99, CopiesAvailable = 5 };
            _mockBookService.Setup(service => service.GetBookByTitle("Book 1")).Returns(book);

            // Act
            var result = _controller.GetBookByTitle("Book 1");

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBook = Assert.IsType<Book>(actionResult.Value);
            Assert.Equal("Book 1", returnedBook.Title);
        }

        [Fact]
        public void GetBookByTitle_ShouldReturnNotFound_WhenBookDoesNotExist()
        {
            // Arrange
            _mockBookService.Setup(service => service.GetBookByTitle("Nonexistent Book")).Returns((Book)null);

            // Act
            var result = _controller.GetBookByTitle("Nonexistent Book");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void AddBook_ShouldReturnCreatedAtActionResult_WhenBookIsAdded()
        {
            // Arrange
            var newBook = new Book { ISBN = "789", Title = "New Book", Author = "New Author", Price = 12.99, CopiesAvailable = 10 };

            // Act
            var result = _controller.AddBook(newBook);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedBook = Assert.IsType<Book>(actionResult.Value);
            Assert.Equal("New Book", returnedBook.Title);
        }

        [Fact]
        public void UpdateBook_ShouldReturnNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var updatedBook = new Book { ISBN = "123", Title = "Updated Title", Author = "Updated Author", Price = 20.99, CopiesAvailable = 8 };
            _mockBookService.Setup(service => service.UpdateBook("123", updatedBook));

            // Act
            var result = _controller.UpdateBook("123", updatedBook);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateBook_ShouldReturnBadRequest_WhenBookDoesNotExist()
        {
            // Arrange
            var updatedBook = new Book { ISBN = "999", Title = "Nonexistent Book", Author = "Unknown Author", Price = 19.99, CopiesAvailable = 0 };
            _mockBookService.Setup(service => service.UpdateBook("999", updatedBook))
                            .Throws(new System.Exception("Book not found."));

            // Act
            var result = _controller.UpdateBook("999", updatedBook);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Book not found.", actionResult.Value);
        }

        [Fact]
        public void DeleteBook_ShouldReturnNoContent_WhenDeletionIsSuccessful()
        {
            // Arrange
            _mockBookService.Setup(service => service.DeleteBook("123"));

            // Act
            var result = _controller.DeleteBook("123");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteBook_ShouldReturnBadRequest_WhenBookDoesNotExist()
        {
            // Arrange
            _mockBookService.Setup(service => service.DeleteBook("999"))
                            .Throws(new System.Exception("Book not found."));

            // Act
            var result = _controller.DeleteBook("999");

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Book not found.", actionResult.Value);
        }
    }
}
