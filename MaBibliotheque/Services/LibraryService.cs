using MaBibliotheque.Models;
using MaBibliotheque.Services.Interface;
using System.Collections.ObjectModel;
using System.Linq;

namespace MaBibliotheque.Services
{
    public class LibraryService : ILibraryService
    {
        public ObservableCollection<Book> Books { get; } = [];
        public ObservableCollection<Author> Authors { get; } = [];

        public bool AddBook(Book book)
        {
            if (book == null || BookExists(book))
                return false;

            Books.Add(book);
            return true;
        }

        public void InitializeLibrary()
        {
            // This method can be used to initialize the library with some default books and authors.
            // For example, you can add some sample books and authors here.
            AddAuthor(new Author(1, "Aucun", "Auteur"));
            AddAuthor(new Author(2, "dqzdjzlfqejfjeqdlqzjdkzqkdjlfqefjklqzkflqzjdfkzqjkdlzj", "djqehdkjqedjkqedjzqnjdkqhdjk"));
        }

        public bool BookExists(Book book)
        {
            return Books.Contains(book);// Books.Any(b => b.Equals(book));
        }

        public bool EditBook(Book oldBook,Book newBook)
        {
            if (BookExists(newBook))
                return false;
            if (oldBook == newBook) return false; // No need to edit if the old book is the same as the new book
            else if (Books.Contains(oldBook))
            {
                int index = Books.IndexOf(oldBook);
                Books[index] = newBook; // Replace the old book with the new book
            }
            else
            {
                return false; // Old book not found in the collection
            }

            return true;
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public bool AddAuthor(Author author)
        {
            if (author == null || AuthorExists(author))
                return false;

            Authors.Add(author);
            return true;
        }

        public bool AuthorExists(Author author)
        {
            return Authors.Any(a => a.Equals(author));
        }

        public void EditAuthor(Author author)
        {
            if (Authors.Contains(author))
            {
                // Logic to edit the author can be added here.
            }
        }

        public void RemoveAuthor(Author author)
        {
            Authors.Remove(author);
        }
    }
}