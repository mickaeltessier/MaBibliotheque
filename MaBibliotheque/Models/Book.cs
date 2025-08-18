using CommunityToolkit.Mvvm.ComponentModel;

namespace MaBibliotheque.Models
{
    public partial class Book : ObservableObject
    {
        [ObservableProperty]
        private Author _author;

        [ObservableProperty]
        private string _bookType; // Le type de livre peut être "Roman", "BD", "Magazine", etc.

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _isbn; // L'ISBN est un numéro international normalisé permettant l'identification d'un livre dans une édition donnée

        [ObservableProperty]
        private float _price;

        [ObservableProperty]
        public int _publishYear;

        public Book(Author author, string bookType, string title, string isbn, float price, int publishYear)
        {
            Author = author;
            BookType = bookType;
            Title = title;
            Isbn = isbn;
            Price = price;
            PublishYear = publishYear;
        }

        public override string ToString()
        {
            return $"{Title} -  {Author.FirstName} {Author.LastName} - ({PublishYear})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Book book)
            {
                return Author.Equals(book.Author) &&
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
