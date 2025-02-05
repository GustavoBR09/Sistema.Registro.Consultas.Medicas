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
    /// Interaction logic for StaffRegister.xaml
    /// </summary>
    public partial class StaffRegister : Window
    {
        private readonly IAPIService _apiService;
        private readonly Guid? _id = null;
        private Guid _addressId;
        public StaffRegister(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }
        public StaffRegister(IAPIService apiService, Guid id)
        {
            InitializeComponent();
            _apiService = apiService;
            _id = id;
            UpdateMode();
        }
        private async void ButtonRegisterStaff_Click(object sender, RoutedEventArgs e)
        {
            await NewStaff();

            Staff staff = new Staff(_apiService);
            staff.Show();
            this.Close();
        }

        private async void ButtonRegisterNewStaff_Click(object sender, RoutedEventArgs e)
        {
            await NewStaff();

            NameTextBoxStaff.Clear();
            EmailTextBoxStaff.Clear();
            PasswordStaff.Clear();
            DatePickerData.SelectedDate = DateTime.Now;
            CPFTextBoxStaff.Clear();
            WorkCardTextBoxStaff.Clear();
            ComboBoxStaff.SelectedIndex = 0;
            StreetTextBoxStaff.Clear();
            NumberTextBoxStaff.Clear();
            NeighborhoodTextBoxStaff.Clear();
            ComplementTextBoxStaff.Clear();
            CEPTextBoxStaff.Clear();
            CityTextBoxStaff.Clear();
            EstadoTextBoxStaff.Clear();
        }

        private async Task NewStaff()
        {
            if (DatePickerData.SelectedDate == null)
            {
                MessageBox.Show("A data de nascimento é obrigatória.");
                return;
            }

            AddressViewModel addressViewModel = new AddressViewModel();
            addressViewModel.City = CityTextBoxStaff.Text;
            addressViewModel.State = EstadoTextBoxStaff.Text;
            addressViewModel.Street = StreetTextBoxStaff.Text;
            addressViewModel.Number = NumberTextBoxStaff.Text;
            addressViewModel.Complement = ComplementTextBoxStaff.Text;
            addressViewModel.Neighborhood = NeighborhoodTextBoxStaff.Text;
            addressViewModel.PostalCode = CEPTextBoxStaff.Text;

            addressViewModel = await _apiService.AddAddress(addressViewModel);

            StaffViewModel staffViewModel = new StaffViewModel();
            staffViewModel.Name = NameTextBoxStaff.Text;
            staffViewModel.Email = EmailTextBoxStaff.Text;

            staffViewModel.Birthday = DatePickerData.SelectedDate!.Value;
            staffViewModel.Cpf = CPFTextBoxStaff.Text;
            staffViewModel.CarteiraTrabalho = WorkCardTextBoxStaff.Text;
            staffViewModel.Position = (int)ComboBoxStaff.SelectedValue;
            staffViewModel.AddressId = addressViewModel.Id;

            staffViewModel = await _apiService.AddStaff(staffViewModel);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff(_apiService);
            staff.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxStaff.ItemsSource = EnumHelp.EnumToList<Positions>();
        }

        private async void UpdateMode()
        {
            //TODO 1. Buscar informações do banco4
            var Staff = await _apiService.GetStaffById(_id.Value);
            // 2. Inserir informações nos campos
            NameTextBoxStaff.Text = Staff.Name;
            DatePickerData.SelectedDate = Staff.Birthday;
            EmailTextBoxStaff.Text = Staff.Email;
            CPFTextBoxStaff.Text = Staff.Cpf;
            WorkCardTextBoxStaff.Text = Staff.CarteiraTrabalho;
            ComboBoxStaff.SelectedValue = Staff.Position;
            StreetTextBoxStaff.Text = Staff.Address.Street;
            ComplementTextBoxStaff.Text = Staff.Address.Complement;
            NumberTextBoxStaff.Text = Staff.Address.Number;
            NeighborhoodTextBoxStaff.Text = Staff.Address.Neighborhood;
            CEPTextBoxStaff.Text = Staff.Address.PostalCode;
            CityTextBoxStaff.Text = Staff.Address.City;
            EstadoTextBoxStaff.Text = Staff.Address.State;

            _addressId = Staff.AddressId;
        }
    }
}
