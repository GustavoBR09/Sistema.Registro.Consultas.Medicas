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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private readonly IAPIService _apiService;
        public Main(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonAppointments_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
        }

        private void ButtonPatients_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
        }

        private void ButtonDoctors_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor(_apiService);
            doctor.Show();
        }

        private void ButtonStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void ButtonReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(_apiService);
            login.Show();
            this.Close();
        }
    }
}
