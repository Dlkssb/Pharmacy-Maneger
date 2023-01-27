using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy_Maneger.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmacy_Maneger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    {
        
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            // ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)

        {
            services.AddSingleton<MyService>();
            services.AddSingleton<DependncyInjection>();
            
            services.AddDbContext<AppDbContext>(options =>
            {

                options.UseSqlite("Data Source = Pharmacy_Maneger.db");
                if (options.IsConfigured)
                {
                    MessageBox.Show("Configred Sucssefully");
                }

                else
                    MessageBox.Show("somthing went wrong");
            });
        }

        /*  protected override void OnStartup(StartupEventArgs e)
          {
              base.OnStartup(e);
              var mainWindow = serviceProvider.GetService<MainWindow>();
              mainWindow.Show();
          }
        */
      /*  protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow(serviceProvider);
            mainWindow.Show();
        */

        private  void OnStartup(object sender, StartupEventArgs e)
        {
            
            var mainWindow =new MainWindow(serviceProvider.GetService<MyService>()) ;
            mainWindow.Show();
        }
    }
}
