using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MaBibliotheque.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using MaBibliotheque.Views.SubView;

namespace MaBibliotheque.ViewModels
{
    public partial class LibraryViewModel : ObservableObject
    {
        private readonly ILibraryService _libraryService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Book> Books => _libraryService.Books;

        [ObservableProperty]
        private Book? _selectedBook;

        public LibraryViewModel(ILibraryService libraryService, INavigationService navigationService)
        {
            _libraryService = libraryService;
            _navigationService = navigationService;
            _libraryService.InitializeLibrary();
        }

        // Remplacement de la méthode OpenAddBookView pour corriger CS0120
        [RelayCommand]
        public void OpenAddBookView()
        {
            _navigationService.ShowWindow<AddBookView>();
        }

        [RelayCommand]
        private void DeleteBook()
        {
            if (SelectedBook != null)
                _libraryService.RemoveBook(SelectedBook);
        }

        [RelayCommand]
        private static void EditBook()
        {
            // On ouvre à nouveau la page de nouveau book et on rempli avec les valeurs que l'on connais du book
            return;
        }
    }
}
