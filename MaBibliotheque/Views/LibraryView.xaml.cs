using MaBibliotheque.ViewModels;
using System.Windows;

namespace MaBibliotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour LibraryView.xaml
    /// </summary>
    public partial class LibraryView : Window
    {
        public LibraryView(LibraryViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
