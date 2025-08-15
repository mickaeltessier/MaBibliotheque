using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MaBibliotheque
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure the service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

            // Show the main window
            var mainWindow = ServiceProvider.GetRequiredService<Views.LibraryView>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<ViewModels.LibraryViewModel>();
            services.AddTransient<ViewModels.AddBookViewModel>();
            services.AddTransient<Views.LibraryView>();
        }
    }
}
