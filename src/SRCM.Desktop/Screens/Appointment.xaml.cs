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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void ButtonRegisterAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentRegister appointmentRegister = new AppointmentRegister();
            appointmentRegister.Show();
            this.Close();
        }

        private void ButtonSearchAppointment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
