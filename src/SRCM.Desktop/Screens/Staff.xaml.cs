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
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : Window
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void ButtonRegisterStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffRegister staffRegister = new StaffRegister();
            staffRegister.Show();
            this.Close();
        }

        private void ButtonSearchStaff_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
