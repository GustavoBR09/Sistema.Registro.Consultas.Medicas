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
        public DoctorRegister()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.Show();
            this.Close();
        }

        private void ButtonRegisterNewDoctor_Click(object sender, RoutedEventArgs e)
        {
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

        private void ButtonRegisterDoctor_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.Show();
            this.Close();
        }
    }
}
