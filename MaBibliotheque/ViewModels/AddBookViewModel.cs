using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.ViewModels
{
    public partial class AddBookViewModel : ObservableValidator
    {
        protected Book Book;


        [Required(ErrorMessage = "Les informations à propos de l'auteur sont obligatoires")]
        public Author Author
        {
            get => Book.Author;
            set
            {
                SetProperty(Book.Author, value, Book, (b, v) => b.Author = v, true);
            }
        }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        public string Title
        {
            get => Book.Title;
            set
            {
                SetProperty(Book.Title, value, Book, (b, v) => b.Title = v, true);
            }
        }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        public string BookType
        {
            get => Book.BookType;
            set
            {
                SetProperty(Book.BookType, value, Book, (b, v) => b.BookType = v, true);
            }
        }


        [AllowedValues(typeof(string))]
        public string Isbn
        {
            get => Book.Isbn;
            set
            {
                SetProperty(Book.Isbn, value, Book, (b, v) => b.Isbn = v, true);
            }
        }

        [Range(0, int.MaxValue)]
        public float Price
        {
            get => Book.Price;
            set
            {
                SetProperty(Book.Price, value, Book, (b, v) => b.Price = v, true);
            }
        }

        [Required(ErrorMessage = "L'année de publication est obligatoire")]
        [Range(1000, 2100)]
        public int PublishYear
        {
            get => Book.PublishYear;
            set
            {
                SetProperty(Book.PublishYear, value, Book, (b, v) => b.PublishYear = v, true);
            }
        }

        private readonly LibraryViewModel _libraryViewModel;

        public AddBookViewModel(LibraryViewModel libraryViewModel)
        {
            _libraryViewModel = libraryViewModel;
            Book = new Book
            (
                new Author(0, string.Empty, string.Empty),
                string.Empty,
                string.Empty,
                string.Empty,
                0.0f,
                DateTime.Now.Year
            );
        }

        [RelayCommand]
        public void AddBook()
        {
            _libraryViewModel.AddBook(Book);
        }
    }
}
