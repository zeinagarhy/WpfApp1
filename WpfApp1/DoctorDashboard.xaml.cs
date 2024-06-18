using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class DoctorDashboard : Window
    {
        private readonly IMongoCollection<AppointmentInfo> _appointmentsCollection;

        public DoctorDashboard()
        {
            InitializeComponent();

            string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("HealthcareSystemDB"); // Replace with your database name
            _appointmentsCollection = database.GetCollection<AppointmentInfo>("Appointments"); // Replace with your collection name

            // Fetch appointments and display in UI
            DisplayAppointments();
        }

        private void DisplayAppointments()
        {
            var filter = Builders<AppointmentInfo>.Filter.Empty; // Fetch all appointments
            var appointments = _appointmentsCollection.Find(filter).ToList();

            // Clear existing content in panels
            patientPanel.Children.Clear();
            timePanel.Children.Clear();
            detailsPanel.Children.Clear();

            // Populate UI with appointment data
            foreach (var appointment in appointments)
            {
                // Patient Panel
                var patientTextBlock = new TextBlock();
                patientTextBlock.Text = appointment.PatientName;
                patientTextBlock.TextAlignment = TextAlignment.Center;
                patientTextBlock.FontFamily = new FontFamily("Inter");
                patientTextBlock.FontSize = 15;
                patientTextBlock.FontWeight = FontWeights.Medium;
                patientTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#54382f"));
                patientPanel.Children.Add(patientTextBlock);

                // Time Panel
                var timeTextBlock = new TextBlock();
                timeTextBlock.Text = appointment.AppointmentTime.ToString("HH:mm");
                timeTextBlock.TextAlignment = TextAlignment.Center;
                timeTextBlock.FontFamily = new FontFamily("Inter");
                timeTextBlock.FontSize = 15;
                timeTextBlock.FontWeight = FontWeights.Medium;
                timeTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#54382f"));
                timePanel.Children.Add(timeTextBlock);

                // Details Panel (Placeholder, adjust as per your application)
                var detailsTextBlock = new TextBlock();
                detailsTextBlock.Text = "Details Placeholder";
                detailsTextBlock.TextAlignment = TextAlignment.Center;
                detailsTextBlock.FontFamily = new FontFamily("Inter");
                detailsTextBlock.FontSize = 15;
                detailsTextBlock.FontWeight = FontWeights.Medium;
                detailsTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#54382f"));
                detailsPanel.Children.Add(detailsTextBlock);
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            DoctorDashboard ap = new DoctorDashboard();
            ap.Show();
            this.Close();
        }

        private void appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments ap = new Appointments();
            ap.Show();
            this.Close();
        }

        private void patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
            ap.Show();
            this.Close();
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings ap = new Settings();
            ap.Show();
            this.Close();
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
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_finance.Visibility = Visibility.Collapsed;
                tt_patients.Visibility = Visibility.Collapsed;
                tt_appointements.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_finance.Visibility = Visibility.Visible;
                tt_patients.Visibility = Visibility.Visible;
                tt_appointements.Visibility = Visibility.Visible;
            }
        }
        private void shortcut_patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
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
        private void shortcut_appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments ap = new Appointments();
            ap.Show();
            this.Close();
        }


    }

    public class AppointmentInfo
    {
        public string PatientName { get; set; }
        public string PatientID { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
