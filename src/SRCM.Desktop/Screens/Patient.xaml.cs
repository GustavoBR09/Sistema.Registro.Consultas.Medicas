using SRCM.Core.Utils;
using SRCM.Desktop.Interfaces;
using SRCM.Desktop.Utils;
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
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        private readonly IAPIService _apiService;
        public Patient(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }


        private void ButtonRegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientRegister patientRegister = new PatientRegister(_apiService);
            patientRegister.Show();
            this.Close();
        }

        private void ButtonSearchPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private async void Load()
        {
            var patients = await _apiService.GetPatients();
            DataGridPatients.ItemsSource = patients;
        }

        private void DataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Verifiquei se existe um item selecionado
            if (DataGridPatients.SelectedItem != null)
            {
                //Peguei o item selecionado e fiz uma converção explícita para um PatientModel já que ele tem exatamente as propriedades de um
                var patientModel = DataGridPatients.SelectedItem as PatientModel;
                if (patientModel != null)
                {
                    var messageBox = new CustomMessageBox($"Deseja editar ou excluir o paciente: {patientModel.Name}");
                    var result = messageBox.ShowDialog();
                    if (result == true)
                    {
                        switch (messageBox.Result)
                        {
                            case CustomMessageBoxResult.Editar:
                                //Chamo o form de registro mas agora passando o id do paciente para que ele possa abrir com os dados

                                PatientRegister patientRegister = new PatientRegister(_apiService, patientModel.Id);

                                patientRegister.Show();
                                break;
                            case CustomMessageBoxResult.Excluir:
                                _apiService.DeletePatient(patientModel.Id);
                                Load();
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um paciente válido");
                }
            }
        }
    }
}
