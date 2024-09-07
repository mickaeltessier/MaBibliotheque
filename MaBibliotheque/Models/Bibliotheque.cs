using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MaBibliotheque.Models
{
    public class Bibliotheque
    {
        private List<Book> books;

        public Bibliotheque()
        {
            this.books = new();
        }

        public void AddBook(Book book)
        {
            // on ajoute le livre seulement s'il n'existe pas déja dans le liste
            if (BookExisting(book))
            {
                books.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (BookExisting(book))
            {
                books.Remove(book);
            }
        }

        public List<Book> ListOfBook => books;

        public bool BookExisting(Book book)
        {
            return books.Contains(book);
        }
    }
}