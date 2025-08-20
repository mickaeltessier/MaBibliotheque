using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using MaBibliotheque.Services.Interface;
using MaBibliotheque.ViewModels.Interface;

namespace MaBibliotheque.Services
{
    public class NavigationService(IServiceProvider serviceProvider) : INavigationService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public void ShowWindow<T>() where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            if(window == null) return;

            window.Show();
        }

        public void ShowWindow<T>(object parameter) where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            if (window.DataContext is IParameterReceiver parameterReceiver)
            {
                parameterReceiver.Initialize(parameter);
            }
            window.Show();
        }

        public void CloseWindow<T>() where T : class
        {
            var window = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.DataContext?.GetType() == typeof(T));

            window?.Close();
        }
    }
}
