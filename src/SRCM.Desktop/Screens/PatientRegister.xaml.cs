using SRCM.Core.Utils;
using SRCM.Desktop.Interfaces;
using SRCM.Domain.Shared.Enums;
using SRCM.Domain.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for PatientRegister.xaml
    /// </summary>
    public partial class PatientRegister : Window
    {
        private readonly IAPIService _apiService;
        private readonly Guid? _id = null;
        private Guid _addressId;
        public PatientRegister(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        public PatientRegister(IAPIService apiService, Guid id)
        {
            InitializeComponent();
            _apiService = apiService;
            _id = id;
            UpdateMode();
        }


        private async void ButtonRegisterNewPatient_Click(object sender, RoutedEventArgs e)
        {
            await NewPatient();

            NameTextBoxPatient.Clear();
            DatePickerData.SelectedDate = DateTime.Now;
            EmailTextBoxPatient.Clear();
            CPFTextBoxPatient.Clear();
            StreetTextBoxPatient.Clear();
            NeighborTextBoxPatient.Clear();
            NumberTextBoxPatient.Clear();
            CEPTextBoxPatient.Clear();
            ComplementTextBoxPatient.Clear();
            CityTextBoxPatient.Clear();
            StateTextBoxPatient.Clear();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient(_apiService);
            patient.Show();
            this.Close();
        }

        private async void ButtonRegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            await NewPatient();

            Patient patient = new Patient(_apiService);
            patient.Show();
            this.Close();
        }

        private async Task NewPatient()
        {
            if (DatePickerData.SelectedDate == null)
            {
                MessageBox.Show("A data de nascimento é obrigatória.");
                return;
            }

            AddressViewModel addressViewModel = new AddressViewModel();
            addressViewModel.City = CityTextBoxPatient.Text;
            addressViewModel.State = StateTextBoxPatient.Text;
            addressViewModel.Street = StreetTextBoxPatient.Text;
            addressViewModel.Number = NumberTextBoxPatient.Text;
            addressViewModel.Complement = ComplementTextBoxPatient.Text;
            addressViewModel.Neighborhood = NeighborTextBoxPatient.Text;
            addressViewModel.PostalCode = CEPTextBoxPatient.Text;

            addressViewModel = await _apiService.AddAddress(addressViewModel);

            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Name = NameTextBoxPatient.Text;
            patientViewModel.Email = EmailTextBoxPatient.Text;

            patientViewModel.Birthday = DatePickerData.SelectedDate!.Value;
            patientViewModel.CPF = CPFTextBoxPatient.Text;
            patientViewModel.AddressId = addressViewModel.Id;

            if (_id != null)
            {
                patientViewModel.Id = _id.Value;
                patientViewModel = await _apiService.UpdatePatient(patientViewModel);
            }
            else
            {
                patientViewModel = await _apiService.AddPatient(patientViewModel);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void UpdateMode()
        {
            //TODO 1. Buscar informações do banco4
            var patient = await _apiService.GetPatientById(_id.Value);
            // 2. Inserir informações nos campos
            NameTextBoxPatient.Text = patient.Name;
            DatePickerData.SelectedDate = patient.Birthday;
            EmailTextBoxPatient.Text = patient.Email;
            CPFTextBoxPatient.Text = patient.CPF;
            StreetTextBoxPatient.Text = patient.Address.Street;
            ComplementTextBoxPatient.Text = patient.Address.Complement;
            NumberTextBoxPatient.Text = patient.Address.Number;
            NeighborTextBoxPatient.Text = patient.Address.Neighborhood;
            CEPTextBoxPatient.Text = patient.Address.PostalCode;
            CityTextBoxPatient.Text = patient.Address.City;
            StateTextBoxPatient.Text = patient.Address.State;

            _addressId = patient.AddressId;

            ButtonRegisterNewPatient.Visibility = Visibility.Hidden;
            ButtonRegisterPatient.Content = "Salvar";
        }
    }
}
