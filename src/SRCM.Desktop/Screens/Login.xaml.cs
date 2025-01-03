using Refit;
using SRCM.Desktop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SRCM.Desktop.Screens
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAPIService _apiService;
        public Login(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main(_apiService);
            main.Show();
            this.Close();
        }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
