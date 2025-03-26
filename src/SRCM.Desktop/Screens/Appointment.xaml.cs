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

        private async void ButtonSearchAppointment_Click(object sender, RoutedEventArgs e)
        {
            DateTime? date = null;
            DateTime dateAux;
            string? name = null;
            if (DateTime.TryParse(SearchTextBoxAppointment.Text, out dateAux))
            {
                date = dateAux;
            }
            else
            {
                name = SearchTextBoxAppointment.Text;
            }
            var appointments = await _apiService.GetExibitionSchedules(date, null);
            DataGridAppointment.ItemsSource = appointments;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var appointments = await _apiService.GetExibitionSchedules(null, null);
            DataGridAppointment.ItemsSource = appointments;

        }
    }
}
