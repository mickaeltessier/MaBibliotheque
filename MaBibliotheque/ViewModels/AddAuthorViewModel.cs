using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using MaBibliotheque.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.ViewModels
{
    public partial class AddAuthorViewModel(ILibraryService libraryService, INavigationService navigationService) : ObservableValidator
    {
        #region Variables

        protected Author Author = new (0, string.Empty, string.Empty);

        private readonly ILibraryService _libraryService = libraryService;
        private readonly INavigationService _navigationService = navigationService;

        [Required(ErrorMessage = "Le nom de l'auteur est obligatoire.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Le nom ne doit contenir que des lettres.")]
        [Display(Name = "Nom de l'auteur")]
        public string FirstName
        {
            get => Author.FirstName;
            set
            {
                SetProperty(Author.FirstName, value, Author, (b, v) => b.FirstName = v, true);
            }
        }

        [Required(ErrorMessage = "Le prénom de l'auteur est obligatoire.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Le prénom ne doit contenir que des lettres.")]
        [Display(Name = "Prénom de l'auteur")]
        public string LastName
        {
            get => Author.LastName;
            set
            {
                SetProperty(Author.LastName, value, Author, (b, v) => b.LastName = v, true);
            }
        }

        #endregion

        #region Methods

        [RelayCommand]
        public void AddAuthor()
        {
            // Valider les données avant d'ajouter
            ValidateAllProperties();
            if (HasErrors) return;

            if (_libraryService.AddAuthor(Author))
                _navigationService.CloseWindow <AddAuthorViewModel>();
        }

        #endregion
    }
}
