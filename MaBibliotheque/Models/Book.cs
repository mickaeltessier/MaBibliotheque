using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.Models
{
    public partial class Book
    {
        #region Variables

        #region Gestion ID et Classe dépendante
        [Key]
        public int Id { get; set; }

        public int AuthorId {  get; set; }

        [Required]
        public Author Author { get; set; }

        public int PublisherId { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        #endregion

        [Required]
        public string BookType { get; set; } // "Roman", "BD", etc.

        [Required]
        public string Title { get; set; }

        public string Isbn { get; set; }

        public float Price { get; set; }

        public int PublishYear { get; set; }

        #endregion

        private Book() { } // Constructeur par défaut pour Entity Framework ou d'autres usages

        public Book(Author author, Publisher publisher, string bookType, string title, string isbn, float price, int publishYear)
        {
            this.Author = author;
            this.Publisher = publisher;
            this.BookType = bookType;
            this.Title = title;
            this.Isbn = isbn;
            this.Price = price;
            this.PublishYear = publishYear;
        }

        public override string ToString()
        {
            return $"{Title} -  {this.Author.FirstName} {this.Author.LastName} - ({PublishYear})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Book book)
            {
                return Author.Equals(book.Author) &&
                    Publisher.Equals(book.Publisher) &&
                       BookType == book.BookType &&
                       Title == book.Title &&
                       Isbn == book.Isbn &&
                       Price == book.Price &&
                       PublishYear == book.PublishYear;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Author, BookType, Title, Isbn, Price, PublishYear);
        }
    }
}
