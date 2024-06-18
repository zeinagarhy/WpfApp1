using MongoDB.Bson;
using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class Settings : Window
    {
        private readonly MongoDbConnection _mongoDbConnection;

        public Settings()
        {
            InitializeComponent();
            _mongoDbConnection = new MongoDbConnection("mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/"); // Replace with your actual connection string
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var doctor = new BsonDocument
            {
                { "Name", NameTextBox.Text },
               
                // Add other fields as needed (Address, Email, Image, About, PhoneNumber, etc.)
            };

            _mongoDbConnection.AddDoctor(doctor);
        }
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
        private void home_Click(object sender, RoutedEventArgs e)
        {
            DoctorDashboard ap = new DoctorDashboard();
            ap.Show();
            this.Close();
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
    }
}
