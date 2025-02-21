using SRCM.Desktop.Interfaces;
using SRCM.Domain.Shared;
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
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        private readonly IAPIService _apiService;
        public Doctor(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonRegisterDoctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorRegister doctorRegister = new DoctorRegister(_apiService);
            doctorRegister.Show();
            this.Close();
        }

        private void ButtonSearchDoctor_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var doctors = await _apiService.GetDoctors();
            DataGridDoctor.ItemsSource = doctors;
        }

        private void DataGridDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridDoctor.SelectedItem != null)
            {
                var doctorModel = DataGridDoctor.SelectedItem as DoctorModel;
                if (doctorModel != null) { 
                    DoctorRegister doctorRegister = new DoctorRegister(_apiService, doctorModel.Id);
                    doctorRegister.Show();
                }
            }
        }
    }
}
