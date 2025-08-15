using CommunityToolkit.Mvvm.ComponentModel;

namespace MaBibliotheque.Models
{
    public partial class Bibliotheque : ObservableObject
    {
        [ObservableProperty]
        private List<Book> _books;

        public Bibliotheque()
        {
            Books = new();
        }

        public void AddBook(Book book)
        {
            // on ajoute le livre seulement s'il n'existe pas déja dans le liste
            if (BookExisting(book))
            {
                Books.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (BookExisting(book))
            {
                Books.Remove(book);
            }
        }

        public bool BookExisting(Book book)
        {
            return Books.Contains(book);
        }
    }
}