using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using MaBibliotheque.Services.Interface;
using MaBibliotheque.Views.SubView;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using MaBibliotheque.ViewModels.Interface;

namespace MaBibliotheque.ViewModels
{
    public partial class AddBookViewModel(ILibraryService libraryService, INavigationService navigationService) : ObservableValidator, IParameterReceiver
    {
        #region Variables

        protected Book Book = new
            (
                new Author(string.Empty, string.Empty),
                new Publisher(string.Empty, string.Empty),
                string.Empty,
                string.Empty,
                "0000000000",
                0.0f,
                DateTime.Now.Year
            );

        // Stocke le livre à éditer si on est en mode édition
        protected Book? BookToEdit;

        // Indique si on est en mode édition ou ajout
        private bool _isEditMode;

        private readonly ILibraryService _libraryService = libraryService;
        private readonly INavigationService _navigationService = navigationService;
        
        public ObservableCollection<Author> Authors => _libraryService.Authors;

        [Required(ErrorMessage = "Les informations à propos de l'auteur sont obligatoires")]
        public Author Author
        {
            get => Book.Author;
            set
            {
                SetProperty(Book.Author, value, Book, (b, v) => b.Author = v, true);
            }
        }

        public ObservableCollection<Publisher> Publishers => _libraryService.Publishers;

        [Required(ErrorMessage = "Les informations à propos de l'auteur sont obligatoires")]
        public Publisher Publisher
        {
            get => Book.Publisher;
            set
            {
                SetProperty(Book.Publisher, value, Book, (b, v) => b.Publisher = v, true);
            }
        }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [RegularExpression(@"^(?!\s)([\w]{1,}[\p{Zs}]{0,1}){1,}(?<!\s)$", ErrorMessage = "Le titre ne doit contenir que des lettres.")]
        public string Title
        {
            get => Book.Title;
            set
            {
                SetProperty(Book.Title, value, Book, (b, v) => b.Title = v, true);
            }
        }

        [Required(ErrorMessage = "Le genre est obligatoire.")]
        public string BookType
        {
            get => Book.BookType;
            set
            {
                SetProperty(Book.BookType, value, Book, (b, v) => b.BookType = v, true);
            }
        }

        [StringLength(13, MinimumLength = 10, ErrorMessage = "L'ISBN doit contenir entre 10 et 13 caractères.")]
        [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "L'ISBN doit être composé de 10 ou 13 chiffres.")]
        [Required(ErrorMessage = "L'ISBN est obligatoire.")]
        public string Isbn
        {
            get => Book.Isbn;
            set
            {
                SetProperty(Book.Isbn, value, Book, (b, v) => b.Isbn = v, true);
            }
        }

        [Required(ErrorMessage = "Le prix est obligatoire.")]
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

        #endregion

        #region Methods

        public void Initialize(object parameter)
        {
            switch(parameter)
            {
                case Book bookToEdit:
                    _isEditMode = true;
                    // Copier les valeurs du livre à éditer
                    Author = bookToEdit.Author;
                    BookType = bookToEdit.BookType;
                    Title = bookToEdit.Title;
                    Isbn = bookToEdit.Isbn;
                    Price = bookToEdit.Price;
                    PublishYear = bookToEdit.PublishYear;

                    // Stocker le livre à éditer pour l'utiliser lors de la sauvegarde
                    BookToEdit = bookToEdit;
                    break;

                default:
                    throw new ArgumentException("Le paramètre doit être de type 'Book' ou null.");
            }
        }

        [RelayCommand]
        public void OpenAddAuthorView()
        {
            _navigationService.ShowWindow<AddAuthorView>();
        }

        [RelayCommand]
        public void OpenAddPublisherView()
        {
            _navigationService.ShowWindow<AddPublisherView>();
        }

        [RelayCommand]
        private void Save()
        {
            if (HasErrors) return;

            if (_isEditMode)
            {
                if(BookToEdit == null)
                {
                    MessageBox.Show("Aucun livre à éditer n'a été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if(_libraryService.EditBookAsync(BookToEdit,Book).Result)
                    _navigationService.CloseWindow<AddBookViewModel>();
            }
            else
            {
                if (_libraryService.AddBookAsync(Book).Result)
                    _navigationService.CloseWindow<AddBookViewModel>();
            }
        }

        #endregion
    }
}
