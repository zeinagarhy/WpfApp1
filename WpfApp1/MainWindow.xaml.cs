﻿using WpfApp1.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //new DB();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            /*Page1 page1 = new Page1();
            this.Content = page1;*/
            if (txtUser.Text == "5" && txtPass.Password == "0000")
            {
                DoctorDashboard ap = new DoctorDashboard();
                ap.Show();
                this.Close();
            }
            else
                MessageBox.Show("Wrong username or password");
        }

      
        }
    
}
