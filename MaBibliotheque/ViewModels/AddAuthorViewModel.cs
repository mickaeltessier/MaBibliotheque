using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using MaBibliotheque.Services.Interface;
using MaBibliotheque.Views.SubView;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.ViewModels
{
    public partial class AddAuthorViewModel(ILibraryService libraryService) : ObservableValidator
    {
        #region Variables

        protected Author Author = new (0, string.Empty, string.Empty);

        private readonly ILibraryService _libraryService = libraryService;

        [Required(ErrorMessage = "Le nom de l'auteur est obligatoire.")]
        public string FirstName
        {
            get => Author.FirstName;
            set
            {
                SetProperty(Author.FirstName, value, Author, (b, v) => b.FirstName = v, true);
            }
        }

        [Required(ErrorMessage = "Le prénom de l'auteur est obligatoire.")]
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
            _libraryService.AddAuthor(Author);
        }

        #endregion
    }
}
