using CommunityToolkit.Mvvm.ComponentModel;
using MaBibliotheque.Data;
using MaBibliotheque.Models;
using MaBibliotheque.Repository;
using MaBibliotheque.Repository.Interface;
using MaBibliotheque.Services.Interface;
using System.Collections.ObjectModel;

namespace MaBibliotheque.Services
{
    public partial class LibraryService(AppDbContext dbContext, IBookRepository bookFullRepository, IRepository<Book> bookRepository, IRepository<Author> authorRepository, IRepository<Publisher> publisherRepository) : ObservableObject, ILibraryService
    {
        private readonly Repository<Book> _bookRepository = (Repository<Book>)bookRepository;
        private readonly Repository<Author> _authorRepository = (Repository<Author>)authorRepository;
        private readonly Repository<Publisher> _publisherRepository = (Repository<Publisher>)publisherRepository;

        private readonly AppDbContext _dbContext = dbContext;

        private readonly IBookRepository _bookFullRepository = bookFullRepository;

        public ObservableCollection<Book> Books { get; set; } = [];

        public ObservableCollection<Author> Authors { get; private set; } = [];

        public ObservableCollection<Publisher> Publishers { get; private set; } = [];

        public async void InitializeLibrary()
        {
            await LoadBooksAsync();
            await LoadAuthorsAsync();
            await LoadPublishersAsync();
        }

        private async Task LoadPublishersAsync()
        {
            var publisherList = _publisherRepository.GetAll();
            Publishers = new ObservableCollection<Publisher>(publisherList);

            Publishers.Clear();
            foreach (var publisher in publisherList)
            {
                Publishers.Add(publisher);
            }
        }

        private async Task LoadAuthorsAsync()
        {
            var authorsList = _authorRepository.GetAll();
            Authors = new ObservableCollection<Author>(authorsList);

            Authors.Clear();
            foreach (var author in authorsList)
            {
                Authors.Add(author);
            }
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            if (book == null || BookExists(book))
                return false;

            _dbContext.Books.Add(book); // Add the book to the database
            _dbContext.SaveChanges(); // Save changes to the database

            await LoadBooksAsync();

            return true;
        }

        public bool BookExists(Book book)
        {
            return _bookRepository.GetAll().Any(b => b.Equals(book));
        }

        public async Task<bool> EditBookAsync(Book oldBook,Book newBook)
        {
            if (BookExists(newBook))
                return false;

            if (oldBook == newBook) return false; // No need to edit if the old book is the same as the new book
            else if (Books.Contains(oldBook))
            {
                newBook.Id = oldBook.Id;
                _bookRepository.Update(newBook);
            }
            else
            {
                return false; // Old book not found in the collection
            }

            await LoadBooksAsync();

            return true;
        }

        public async Task LoadBooksAsync()
        {
            var booksFromDb = _bookFullRepository.GetBooksWithAuthorsAndPublisher();

            Books.Clear();
            foreach (var book in booksFromDb)
                Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            LoadBooksAsync();
        }

        public bool AddAuthor(Author author)
        {
            if (author == null || AuthorExists(author))
                return false;

            _dbContext.Authors.Add(author); // Add the new author to the database
            _dbContext.SaveChanges(); // Save changes to the database

            LoadAuthorsAsync();
            return true;
        }

        public bool AuthorExists(Author author)
        {
            return _authorRepository.GetAll().Any(a => a.Equals(author));
        }

        // Methode pas encore implémenter
        public void EditAuthor(Author author)
        {
            if (Authors.Contains(author))
            {
                // Logic to edit the author can be added here.
            }
        }

        public void RemoveAuthor(Author author)
        {
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();

            LoadAuthorsAsync();
        }

        public async Task<bool> AddPublisherAsync(Publisher publisher)
        {
            if (publisher == null || PublisherExists(publisher))
                return false;
            _dbContext.Publishers.Add(publisher); // Add the new publisher to the database
            _dbContext.SaveChanges(); // Save changes to the database
            await LoadPublishersAsync();
            return true;
        }

        public bool PublisherExists(Publisher publisher)
        {
            return _publisherRepository.GetAll().Any(p => p.Equals(publisher));
        }
    }
}