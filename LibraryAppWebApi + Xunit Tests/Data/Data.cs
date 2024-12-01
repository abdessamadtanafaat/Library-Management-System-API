using LibraryAppWebApi.Models;

namespace LibraryAppWebApi.Data;

public static class Data
{
    public static List<Book> books { get; } = new List<Book>
    {
        new Book("book1", "978089985324", 22.99, "author1", 5),
        new Book("book2", "878489958531", 222.99, "author2", 6),
        new Book("book3", "653748365973", 24.99, "author3", 8),
        new Book("book4", "885879243523", 12.99, "author4", 12),
        new Book("book5", "746383084643", 52.99, "author5", 3),
    };
}