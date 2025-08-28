using MaBibliotheque.Data;
using MaBibliotheque.Models;
using MaBibliotheque.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MaBibliotheque.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooksWithAuthors()
        {
            return _context.Books.Include(b => b.Author).ToList();
        }

        public IEnumerable<Book> GetBooksWithAuthorsAndPublisher()
        {
            return _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }
    }

}
