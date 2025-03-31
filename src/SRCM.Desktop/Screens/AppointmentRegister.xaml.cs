using SRCM.Core.Utils;
using SRCM.Desktop.Interfaces;
using SRCM.Domain.Shared.Enums;
using SRCM.Domain.Shared.ViewModel;
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
        private readonly IAPIService _apiService;
        public AppointmentRegister(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment(_apiService);
            appointment.Show();
            this.Close();
        }

        private void ButtonRegisterNewAppointment_Click(object sender, RoutedEventArgs e)
        {
            SaveAppointmentScheduling();
            ComboBoxPatient.SelectedIndex = 0;
            ComboBoxDoctor.SelectedIndex = 0;
            ComboBoxStatus.SelectedIndex = 0;
            ComboBoxType.SelectedIndex = 0;
            DatePickerData.SelectedDate = DateTime.Now;
            ObservationTextBox.Clear();
        }

        private void ButtonRegisterAppointment_Click(object sender, RoutedEventArgs e)
        {
            SaveAppointmentScheduling();
            Appointment appointment = new Appointment(_apiService);
            appointment.Show();
            this.Close();
        }

        private async void SaveAppointmentScheduling()
        {
            if (DatePickerData.SelectedDate == null)
            {
                MessageBox.Show("A data é obrigatória.");
                return;
            }

            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.IdPatient = (Guid)ComboBoxPatient.SelectedValue;
            appointmentViewModel.IdDoctor = (Guid)ComboBoxDoctor.SelectedValue;
            appointmentViewModel.Type = (int)ComboBoxType.SelectedValue;
            appointmentViewModel.Observation = ObservationTextBox.Text;

            appointmentViewModel = await _apiService.AddAppointment(appointmentViewModel);

            AppointmentSchedulingViewModel appointmentSchedulingViewModel = new AppointmentSchedulingViewModel();
            appointmentSchedulingViewModel.IdAppointment = appointmentViewModel.Id;
            appointmentSchedulingViewModel.Status = appointmentSchedulingViewModel.Status;
            appointmentSchedulingViewModel.Date = appointmentSchedulingViewModel.Date;

            appointmentSchedulingViewModel = await _apiService.AddAppointmentScheduling(appointmentSchedulingViewModel);
        }
        private async Task LoadData()
        {
            var doctors = await _apiService.GetDoctors();
            ComboBoxDoctor.ItemsSource = doctors;
            ComboBoxDoctor.DisplayMemberPath = "Name";
            ComboBoxDoctor.SelectedValuePath = "Id";

            var patients = await _apiService.GetPatients();
            ComboBoxPatient.ItemsSource = patients;
            ComboBoxPatient.DisplayMemberPath = "Name";
            ComboBoxPatient.SelectedValuePath = "Id";

            ComboBoxStatus.ItemsSource = EnumHelp.EnumToList<AppointmentStatus>();
            ComboBoxType.ItemsSource = EnumHelp.EnumToList<AppointmentType>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
