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
    /// Interaction logic for PatientRegister.xaml
    /// </summary>
    public partial class PatientRegister : Window
    {
        private readonly IAPIService _apiService;
        public PatientRegister(IAPIService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }


        private void ButtonRegisterNewPatient_Click(object sender, RoutedEventArgs e)
        {
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

        private void ButtonRegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient(_apiService);
            patient.Show();
            this.Close();
        }
    }
}
