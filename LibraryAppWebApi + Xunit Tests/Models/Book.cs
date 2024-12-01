namespace LibraryAppWebApi.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set;  }
        public double Price { get; set; }
        public string Author { get; set; }
        public int CopiesAvailable { get; set; }

        // Constructeur par défaut
        public Book()
        {
        }
        // Constructeur avec paramètres
        public Book(string title, string isbn, double price, string author, int copiesAvailable)
        {
            Title = title;
            ISBN = isbn;
            Price = price;
            Author = author;
            CopiesAvailable = copiesAvailable; 
        }
    }
}



