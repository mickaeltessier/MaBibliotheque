using MaBibliotheque.Models;
using System.Collections.ObjectModel;

namespace MaBibliotheque.Services.Interface
{
    public interface ILibraryService
    {
        ObservableCollection<Book> Books { get; }
        ObservableCollection<Author> Authors { get; }

        ObservableCollection<Publisher> Publishers { get; }

        // TODO : Delete InitializeLibrary method if not needed
        void InitializeLibrary();

        #region Book Management
        Task<bool> AddBookAsync(Book book);
        Task<bool> EditBookAsync(Book oldBook,Book newBook);
        bool BookExists(Book book);
        void RemoveBook(Book book);
        #endregion

        #region Author Management
        bool AddAuthor(Author author);
        void EditAuthor(Author author);
        void RemoveAuthor(Author author);
        #endregion

        #region Publisher Management
        Task<bool> AddPublisherAsync(Publisher publisher);
        bool PublisherExists(Publisher publisher);
        #endregion
    }
}