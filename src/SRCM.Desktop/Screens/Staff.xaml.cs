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
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : Window
    {
        private readonly IAPIService _apiService;
        public Staff(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonRegisterStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffRegister staffRegister = new StaffRegister(_apiService);
            staffRegister.Show();
            this.Close();
        }

        private void ButtonSearchStaff_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var staff = await _apiService.GetStaffs();
            DataGridStaff.ItemsSource = staff;
        }
    }
}
