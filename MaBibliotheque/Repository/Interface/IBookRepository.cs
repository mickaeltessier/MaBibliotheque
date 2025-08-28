using MaBibliotheque.Models;

namespace MaBibliotheque.Repository.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksWithAuthors();

        IEnumerable<Book> GetBooksWithAuthorsAndPublisher();
    }
}
