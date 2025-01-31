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
    /// Interaction logic for DoctorRegister.xaml
    /// </summary>
    public partial class DoctorRegister : Window
    {
        private readonly IAPIService _apiService;
        public DoctorRegister(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor(_apiService);
            doctor.Show();
            this.Close();
        }

        private async void ButtonRegisterNewDoctor_Click(object sender, RoutedEventArgs e)
        {
            await NewDoctor();

            NameTextBoxDoctor.Clear();
            DatePickerData.SelectedDate = DateTime.Now;
            EmailTextBoxDoctor.Clear();
            PasswordDoctor.Clear();
            CPFTextBoxDoctor.Clear();
            CRMTextBoxDoctor.Clear();
            ComboBoxSpecialty.SelectedIndex = 0;
            StreetTextBoxDoctor.Clear();
            NeighborhoodTextBoxDoctor.Clear();
            ComplementTextBoxDoctor.Clear();
            NumberTextBoxDoctor.Clear();
            CEPTextBoxDoctor.Clear();
            CityTextBoxDoctor.Clear();
        }

        private async void ButtonRegisterDoctor_Click(object sender, RoutedEventArgs e)
        {
            await NewDoctor();

            Doctor doctor = new Doctor(_apiService);
            doctor.Show();
            this.Close();
        }

        private async Task NewDoctor()
        {
            if (DatePickerData.SelectedDate == null)
            {
                MessageBox.Show("A data de nascimento é obrigatória.");
                return;
            }
                
            AddressViewModel addressViewModel = new AddressViewModel();
            addressViewModel.City = CityTextBoxDoctor.Text;
            addressViewModel.State = EstadoTextBoxDoctor.Text;
            addressViewModel.Street = StreetTextBoxDoctor.Text;
            addressViewModel.Number = NumberTextBoxDoctor.Text;
            addressViewModel.Complement = ComplementTextBoxDoctor.Text;
            addressViewModel.Neighborhood = NeighborhoodTextBoxDoctor.Text;
            addressViewModel.PostalCode = CEPTextBoxDoctor.Text;

            addressViewModel = await _apiService.AddAddress(addressViewModel);

            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.Name = NameTextBoxDoctor.Text;
            doctorViewModel.Email = EmailTextBoxDoctor.Text;
            
            doctorViewModel.Birthday = DatePickerData.SelectedDate!.Value;
            doctorViewModel.Cpf = CPFTextBoxDoctor.Text;
            doctorViewModel.Crm = CRMTextBoxDoctor.Text;
            doctorViewModel.Specialty = (int)ComboBoxSpecialty.SelectedValue;
            doctorViewModel.AddressId = addressViewModel.Id;

            doctorViewModel = await _apiService.AddDoctor(doctorViewModel);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSpecialty.ItemsSource = EnumHelp.EnumToList<Specialties>();
        }
    }
}
