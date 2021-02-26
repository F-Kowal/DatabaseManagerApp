using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseManagerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        /// <summary>
        /// App constructor configuring services and adding database connection.
        /// Change sql connection string if necessary
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<NorthwindContext>(option =>
            {
                option.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Northwind");
            });

            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();
        }


        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }   
    }
}
