using MongoDB.Driver.Core.Configuration;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PatientList.xaml
    /// </summary>
    public partial class PatientList : Window
    {
        private readonly MongoDbConnection _mongoDbConnection;
        public PatientList()
        {
            InitializeComponent();
           
        string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
        _mongoDbConnection = new MongoDbConnection(connectionString);

    }
        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
            ap.Show();
            this.Close();
        }

        private void shortcut_Patients_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
            this.Close();
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic here for handling the Home button click
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_finance.Visibility = Visibility.Collapsed;

                tt_patients.Visibility = Visibility.Collapsed;
                //tt_settings.Visibility = Visibility.Collapsed;
                tt_appointements.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_finance.Visibility = Visibility.Visible;

                tt_patients.Visibility = Visibility.Visible;
                //tt_settings.Visibility = Visibility.Visible;
                tt_appointements.Visibility = Visibility.Visible;
            }
        }
        // Event handler for the Appointments button click
        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void chatbot_Click(object sender, RoutedEventArgs e)
        {
            Chatbot ap = new Chatbot();
            ap.Show();
            this.Close();
        }
        private void finance_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
            this.Close();
        }

        private void shortcut_finance_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
            this.Close();
        }
        private void shortcut_chatbot_Click(object sender, RoutedEventArgs e)
        {
            Chatbot ap = new Chatbot();
            ap.Show();
            this.Close();

        }
        private void prescription_Click(object sender, RoutedEventArgs e)
        {
            Prescriptions ap = new Prescriptions();
            ap.Show();
            this.Close();

        }
        private void shortcut_prescription_Click(object sender, RoutedEventArgs e)
        {
            Prescriptions ap = new Prescriptions();
            ap.Show();
            this.Close();

        }
        private void patientsFile_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }

        private void shortcut_patientsFile_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void appointments_Click(object sender, RoutedEventArgs e)
        {
            //AddAppointment doctorDashboard = new AddAppointment();
            //doctorDashboard.Show();
            this.Close();
        }

        private void patients_Click(object sender, RoutedEventArgs e)
        {
            //PatientList doctorDashboard = new PatientList();
            //doctorDashboard.Show();
            this.Close();
        }





        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings doctorDashboard = new Settings();
            doctorDashboard.Show();
            this.Close();
        }
    }
}
 