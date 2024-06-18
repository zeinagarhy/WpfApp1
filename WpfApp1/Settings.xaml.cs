using MongoDB.Bson;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
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
   
    public partial class Settings : Window
    {
        private readonly MongoDbConnection _mongoDbConnection;
        private IMongoDatabase _database;

        public Settings()
        {
            InitializeComponent();
            string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
            _mongoDbConnection = new MongoDbConnection(connectionString);

        }


        private void ChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            string currentUsername = UsernameTextBox.Text.Trim();
            string newUsername = NewUsernameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(currentUsername) || string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Both current and new usernames are required.");
                return;
            }

            try
            {
                _mongoDbConnection.ChangeUsername(currentUsername, newUsername, "Users"); // Assuming "Users" is your collection name
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ChangeUsername(string currentUsername, string newUsername, string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Username", currentUsername);
                var update = Builders<BsonDocument>.Update.Set("Username", newUsername);

                var result = collection.UpdateOne(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Username updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update username. User not found or new username is the same as the current one.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update username: {ex.Message}");
            }
        }






        private void patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
            ap.Show();
            this.Close();

        }
        private void shortcut_patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
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

        /*private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }*/

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

        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow doctorDashboard = new MainWindow();
            doctorDashboard.Show();
            this.Close();
        }

        private void appointments_Click(object sender, RoutedEventArgs e)
        {
            //AddAppointment doctorDashboard = new AddAppointment();
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
