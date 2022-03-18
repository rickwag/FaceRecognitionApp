using System.Windows;

using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace FaceRecognitionApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=app.db";
        private IDBService dBService;
        private ApplicationDbContextFactory dbContextFactory;

        public App()
        {
            dbContextFactory = new ApplicationDbContextFactory(CONNECTION_STRING);

            dBService = new DBService(dbContextFactory);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            //database migration
            var options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            //mainwindow initialization
            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel(dBService);

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
    }
}
