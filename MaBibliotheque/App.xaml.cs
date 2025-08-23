using Microsoft.Extensions.DependencyInjection;
using MaBibliotheque.Services.Interface;
using System.Windows;
using MaBibliotheque.Services;
using MaBibliotheque.Views;
using MaBibliotheque.Views.SubView;
using MaBibliotheque.ViewModels;
using Microsoft.EntityFrameworkCore;
using MaBibliotheque.Data;
using MaBibliotheque.Repository.Interface;
using MaBibliotheque.Models;
using MaBibliotheque.Repository;

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
            ServiceProvider.GetService<INavigationService>()?.ShowWindow<LibraryView>();
            //var mainWindow = ServiceProvider.GetRequiredService<LibraryView>();
            //mainWindow.Show();

            // Ajout de l'événement de fermeture
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Ajout des DataBase Context
            services.AddDbContext<AppDbContext>();

            // Ajout des Repository
            services.AddScoped<IRepository<Book>, Repository<Book>>();
            services.AddScoped<IRepository<Author>, Repository<Author>>();
            services.AddScoped<IBookRepository, BookRepository>();

            // Ajout des services
            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Ajout des ViewModels
            services.AddTransient<LibraryViewModel>();
            services.AddTransient<AddBookViewModel>();
            services.AddTransient<AddAuthorViewModel>();

            // Ajout des vues et des sub views
            services.AddTransient<LibraryView>();
            services.AddTransient<AddAuthorView>();
            services.AddTransient<AddBookView>();

        }
    }
}
