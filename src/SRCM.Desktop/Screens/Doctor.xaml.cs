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
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        public Doctor()
        {
            InitializeComponent();
        }

        private void ButtonRegisterDoctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorRegister doctorRegister = new DoctorRegister();
            doctorRegister.Show();
            this.Close();
        }

        private void ButtonSearchDoctor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
