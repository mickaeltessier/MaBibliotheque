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


        Task<bool> AddBookAsync(Book book);
        Task<bool> EditBookAsync(Book oldBook,Book newBook);
        bool BookExists(Book book);
        void RemoveBook(Book book);
        bool AddAuthor(Author author);
        void EditAuthor(Author author);
        void RemoveAuthor(Author author);
    }
}