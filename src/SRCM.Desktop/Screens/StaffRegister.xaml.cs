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
    /// Interaction logic for StaffRegister.xaml
    /// </summary>
    public partial class StaffRegister : Window
    {
        public StaffRegister()
        {
            InitializeComponent();
        }

        private void ButtonRegisterStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Close();
        }

        private void ButtonRegisterNewStaff_Click(object sender, RoutedEventArgs e)
        {
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

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Close();
        }
    }
}
