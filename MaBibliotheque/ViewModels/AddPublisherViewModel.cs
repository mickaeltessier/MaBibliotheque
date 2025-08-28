using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using MaBibliotheque.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.ViewModels
{
    public partial class AddPublisherViewModel(ILibraryService libraryService, INavigationService navigationService) : ObservableValidator
    {
        #region Variables

        protected Publisher Publisher = new (string.Empty, string.Empty);

        private readonly ILibraryService _libraryService = libraryService;
        private readonly INavigationService _navigationService = navigationService;

        [Required(ErrorMessage = "Le nom de l'éditeur est obligatoire.")]
        [RegularExpression(@"^(?!\s)([\w]{1,}[\p{Zs}]{0,1}){1,}(?<!\s)$", ErrorMessage = "Le nom ne doit contenir que des chiffres et des lettres.")]
        [Display(Name = "Nom de l'éditeur")]
        public string PublisherName
        {
            get => Publisher.PublisherName;
            set
            {
                SetProperty(Publisher.PublisherName, value, Publisher, (b, v) => b.PublisherName = v, true);
            }
        }

        [RegularExpression(@"^(?!\s)([\w]{1,}[\p{Zs}]{0,1}){1,}(?<!\s)$", ErrorMessage = "Le texte ne doit contenir que des chiffres et des lettres.")]
        [Display(Name = "Ligne éditoriale")]
        public string EditorLine
        {
            get => Publisher.EditorLine ?? string.Empty;
            set
            {
                SetProperty(Publisher.EditorLine, value, Publisher, (b, v) => b.EditorLine = v, true);
            }
        }

        #endregion

        #region Methods

        [RelayCommand]
        public void AddPublisher()
        {
            // Valider les données avant d'ajouter
            ValidateAllProperties();
            if (HasErrors) return;

            if (_libraryService.AddPublisherAsync(Publisher).Result)
                _navigationService.CloseWindow<AddPublisherViewModel>();
        }

        #endregion
    }
}
