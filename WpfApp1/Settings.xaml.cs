using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows;
using System.Windows.Input;

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
            //_database = _mongoDbConnection.GetDatabase("YourDatabaseName"); // Replace with your actual database name
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
                ChangeUsername(currentUsername, newUsername, "Users"); // Assuming "Users" is your collection name
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

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = PasswordTextBox.Password.Trim();
            string newPassword = NewPasswordTextBox.Password.Trim();

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Both current and new passwords are required.");
                return;
            }

            try
            {
                ChangePassword(currentPassword, newPassword, "Users"); // Assuming "Users" is your collection name
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ChangePassword(string currentPassword, string newPassword, string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Password", currentPassword);
                var update = Builders<BsonDocument>.Update.Set("Password", newPassword);

                var result = collection.UpdateOne(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Password updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update password. User not found or new password is the same as the current one.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update password: {ex.Message}");
            }
        }

        // Other existing event handlers...

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
            // Your code here...
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
