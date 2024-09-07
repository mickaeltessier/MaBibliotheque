using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque.Models
{
    public class Book
    {
        private Author? _author;
        private string _title;
        private float _price;
        private int _publishYear;
        private string _genre;
        private string _isbn; // L'ISBN est un numéro international normalisé permettant l'identification d'un livre dans une édition donnée

        public Book(Author? author, string bookType, string title, float price, int publishYear)
        {
            _author = author;
            _title = title;
            _price = price;
            _publishYear = publishYear;
            _bookType = bookType;
        }

        public Author Author { get { return _author ??= new Author(0,"Auteur vide","Auteur vide"); } }

        public string Title => _title;

        public float Price => _price;

        public int PublishYear => _publishYear;

        public string BookType => _bookType;
    }
}
