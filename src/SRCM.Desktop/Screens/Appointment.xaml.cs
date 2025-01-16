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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        private readonly IAPIService _apiService;
        public Appointment(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonRegisterAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentRegister appointmentRegister = new AppointmentRegister(_apiService);
            appointmentRegister.Show();
            this.Close();
        }

        private void ButtonSearchAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var appointments = await _apiService.GetAppointments();
            DataGridAppointment.ItemsSource = appointments;
        }
    }
}
