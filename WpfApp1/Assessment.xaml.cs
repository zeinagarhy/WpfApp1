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
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Assessment.xaml
    /// </summary>
    public partial class Assessment : Page
    {
        private readonly MongoDbConnection _mongoDbConnection;
        private IMongoCollection<AssessmentData> _assessmentCollection;
        private IMongoDatabase _database;
        public Assessment()
        {
            InitializeComponent();
            string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
            _mongoDbConnection = new MongoDbConnection(connectionString);



        }
        public class AssessmentData
        {
            public string SleepQuality { get; set; }
            public int HoursOfSleep { get; set; }


            public int AnxietyLevel { get; set; }
            public int Anxiety { get; set; }
            public string MoodOverall { get; set; }
            public string MoodTime { get; set; }
        }
        public async Task SaveAssessmentDataAsync(AssessmentData assessmentData)
        {
            try
            {
                // Simulate saving data (replace with actual MongoDB code as needed)
                await Task.Delay(1000); // Simulate delay for asynchronous operation
                MessageBox.Show("Assessment data saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving assessment data: {ex.Message}");
            }
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            AssessmentData assessmentData = new AssessmentData
            {
                SleepQuality = SleepQuality.SelectedItem?.ToString(),
                HoursOfSleep = HoursOfSleep.SelectedIndex + 1,
                AnxietyLevel = AnxietyLevel.SelectedIndex + 1,
                Anxiety = Anxiety.SelectedIndex + 1,
                MoodOverall = MoodOverall.SelectedItem?.ToString(),
                MoodTime = MoodTime.SelectedItem?.ToString(),
            };

            // Save assessment data (simulated)
            await SaveAssessmentDataAsync(assessmentData);
        }

    }
}