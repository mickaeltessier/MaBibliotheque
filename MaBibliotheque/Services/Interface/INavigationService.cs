using System.Windows;

namespace MaBibliotheque.Services.Interface
{
    public interface INavigationService
    {
        void CloseWindow<T>() where T : class;
        void ShowWindow<T>() where T : Window;
    }
}