using CommunityToolkit.Mvvm.Input;
using MaBibliotheque.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MaBibliotheque.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MaBibliotheque.ViewModels
{
    public partial class LibraryViewModel : ObservableObject
    {
        private AddBookView addBookView;

        [ObservableProperty]
        private List<Book> _books;

        [ObservableProperty]
        private List<Author> _authors;

        [ObservableProperty]
        private Book? _selectedBook;
        public LibraryViewModel()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
        }

        [RelayCommand]
        public void OpenAddBookView()
        {
            if(addBookView != null && addBookView.IsVisible)
            {
                // Si la fenêtre est déjà ouverte, on l'affiche au premier plan
                addBookView.Activate();
                return;
            }

            addBookView = new AddBookView()
            {
                DataContext = App.ServiceProvider.GetRequiredService<AddBookViewModel>()
            };
            addBookView.Show();
        }

        [RelayCommand]
        private void DeleteBook()
        {
            Books.Remove(SelectedBook);
        }

        private void EditBook()
        {
            // On ouvre à nouveau la page de nouveau book et on rempli avec les valeurs que l'on connais du book
            return;
        }

    }
}
