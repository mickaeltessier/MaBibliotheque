using MaBibliotheque.Models;
using System.Collections.ObjectModel;

namespace MaBibliotheque.Services.Interface
{
    public interface ILibraryService
    {
        ObservableCollection<Book> Books { get; }
        ObservableCollection<Author> Authors { get; }

        // TODO : Delete InitializeLibrary method if not needed
        void InitializeLibrary();


        bool AddBook(Book book);
        void EditBook(Book book);
        bool BookExists(Book book);
        void RemoveBook(Book book);
        bool AddAuthor(Author author);
        void EditAuthor(Author author);
        void RemoveAuthor(Author author);
    }
}