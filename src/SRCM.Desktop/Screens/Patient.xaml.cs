﻿using System;
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
        public Patient()
        {
            InitializeComponent();
        }


        private void ButtonRegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientRegister patientRegister = new PatientRegister();
            patientRegister.Show();
            this.Close();
        }

        private void ButtonSearchPatient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
