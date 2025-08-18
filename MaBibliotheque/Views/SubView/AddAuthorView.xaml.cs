using MaBibliotheque.ViewModels;
using MahApps.Metro.Controls;

namespace MaBibliotheque.Views.SubView
{
    /// <summary>
    /// Logique d'interaction pour AddAuthorView.xaml
    /// </summary>
    public partial class AddAuthorView : MetroWindow
    {
        public AddAuthorView(AddAuthorViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
