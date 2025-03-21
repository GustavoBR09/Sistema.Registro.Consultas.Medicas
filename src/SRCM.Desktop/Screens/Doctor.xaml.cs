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
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        private readonly IAPIService _apiService;
        public Doctor(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private void ButtonRegisterDoctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorRegister doctorRegister = new DoctorRegister(_apiService);
            doctorRegister.Show();
            this.Close();
        }

        private async void ButtonSearchDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBoxDoctor.Text))
            {
                Load();
            }
            else
            {
                var doctors = await _apiService.GetDoctorUsingFilter(SearchTextBoxDoctor.Text);
                DataGridDoctor.ItemsSource = doctors;
                this.DataContext = this;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private async void Load()
        {
            var doctors = await _apiService.GetDoctors();
            DataGridDoctor.ItemsSource = doctors;
        }

        private void DataGridDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridDoctor.SelectedItem != null)
            {
                var doctorModel = DataGridDoctor.SelectedItem as DoctorModel;
                if (doctorModel != null)
                {
                    var messageBox = new CustomMessageBox($"Deseja editar ou excluir o médico: {doctorModel.Name}");
                    var result = messageBox.ShowDialog();
                    if (result == true)
                    {
                        switch (messageBox.Result)
                        {
                            case CustomMessageBoxResult.Editar:

                                DoctorRegister doctorRegister = new DoctorRegister(_apiService, doctorModel.Id);

                                doctorRegister.Show();
                                break;
                            case CustomMessageBoxResult.Excluir:
                                _apiService.DeleteDoctor(doctorModel.Id);
                                Load();
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um médico válido");
                }
            }
        }
    }
}
