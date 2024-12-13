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
    /// Interaction logic for AppointmentRegister.xaml
    /// </summary>
    public partial class AppointmentRegister : Window
    {
        public AppointmentRegister()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Close();
        }

        private void ButtonRegisterNewAppointment_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxPatient.SelectedIndex = 0;
            ComboBoxDoctor.SelectedIndex = 0;
            ComboBoxStatus.SelectedIndex = 0;
            ComboBoxType.SelectedIndex = 0;
            DatePickerData.SelectedDate = DateTime.Now;
            ObservationTextBox.Clear();
        }

        private void ButtonRegisterAppointment_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Salvar dados
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Close();
        }
    }
}
