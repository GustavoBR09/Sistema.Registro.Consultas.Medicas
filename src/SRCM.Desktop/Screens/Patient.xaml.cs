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
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        private readonly IAPIService _apiService;
        public Patient(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }


        private void ButtonRegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientRegister patientRegister = new PatientRegister(_apiService);
            patientRegister.Show();
            this.Close();
        }

        private void ButtonSearchPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var patient = await _apiService.GetPatients();
            DataGridPatients.ItemsSource = patient;
        }
    }
}
