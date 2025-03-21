using SRCM.Core.Utils;
using SRCM.Desktop.Interfaces;
using SRCM.Desktop.Utils;
using SRCM.Domain.Shared;
using SRCM.Domain.Shared.Models;
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
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : Window
    {
        private readonly IAPIService _apiService;
        public Staff(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonRegisterStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffRegister staffRegister = new StaffRegister(_apiService);
            staffRegister.Show();
            this.Close();
        }

        private async void ButtonSearchStaff_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBoxStaff.Text))
            {
                Load();
            }
            else
            {
                var staff = await _apiService.GetStaffUsingFilter(SearchTextBoxStaff.Text);
                DataGridStaff.ItemsSource = staff;
                this.DataContext = this;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private async void Load()
        {
            var staff = await _apiService.GetStaffs();
            DataGridStaff.ItemsSource = staff;
        }

        private void DataGridStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridStaff.SelectedItem != null)
            {
                var staffModel = DataGridStaff.SelectedItem as StaffModel;

                if (staffModel != null)
                {
                    CustomMessageBox messageBox = new CustomMessageBox($"Deseja editar ou excluir o funcionário: {staffModel.Name}");
                    var result = messageBox.ShowDialog();
                    if (result == true)
                    {
                        switch (messageBox.Result)
                        {
                            case CustomMessageBoxResult.Editar:

                                StaffRegister staffRegister = new StaffRegister(_apiService, staffModel.Id);

                                staffRegister.Show();
                                break;
                            case CustomMessageBoxResult.Excluir:
                                _apiService.DeleteStaff(staffModel.Id);
                                Load();
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um funcionário válido");
                }
            };
        }
    }
}
