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
    }
}
