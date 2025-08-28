using MaBibliotheque.ViewModels;
using MahApps.Metro.Controls;

namespace MaBibliotheque.Views.SubView
{
    /// <summary>
    /// Logique d'interaction pour AddPublisherView.xaml
    /// </summary>
    public partial class AddPublisherView : MetroWindow
    {
        public AddPublisherView(AddPublisherViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
