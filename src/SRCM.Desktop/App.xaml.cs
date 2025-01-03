using Microsoft.Extensions.DependencyInjection;
using Refit;
using SRCM.Desktop.Interfaces;
using SRCM.Desktop.Screens;
using System.Windows;

namespace SRCM.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceColection = new ServiceCollection();
            
            //configure o refit com a url base da api
            serviceColection.AddRefitClient<IAPIService>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7294"));

            serviceColection.AddTransient<Login>();

            ServiceProvider = serviceColection.BuildServiceProvider();
            base.OnStartup(e);
            var loginWindow = ServiceProvider.GetRequiredService<Login>();
            loginWindow.Show();
        }
    }

}
