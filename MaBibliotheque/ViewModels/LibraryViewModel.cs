using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MaBibliotheque.Services.Interface;
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
        private void EditBook()
        {
            if (SelectedBook != null)
            {
                _navigationService.ShowWindow<AddBookView>(SelectedBook);
            }
        }
    }
}
