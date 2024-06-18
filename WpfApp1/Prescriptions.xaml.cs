using MongoDB.Bson;
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
using WpfApp1;


namespace WpfApp1
{
    public partial class Prescriptions : Window
    {
        private readonly MongoDbConnection _mongoDbConnection;

        private int _patientID;
        public Prescriptions()
        {

            InitializeComponent();
            string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
            _mongoDbConnection.UseDatabase("HealthcareSystemDB");
            _mongoDbConnection.AddPrescriptionsCollection();
            _mongoDbConnection = new MongoDbConnection(connectionString);


        }



        private void home_Click(object sender, RoutedEventArgs e)
        {
            DoctorDashboard ap = new DoctorDashboard();
            ap.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientFile patient = new PatientFile();
            patient.Show();
            this.Close();

        }
        private void prescription_Click(object sender, RoutedEventArgs e)
        {

        }
        private void shortcut_prescription_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string patientName = PatientNameTextBox.Text;
            string medication = MedicineComboBox.Text;
            string dosage = Dosage.Text;
            DateTime? prescribedDate = DatePicker.SelectedDate;
            string NumberofDays = NumberOfDaysComboBox.Text;



            if (string.IsNullOrEmpty(patientName) || string.IsNullOrEmpty(medication) || string.IsNullOrEmpty(dosage) || prescribedDate == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var prescriptionsCollection = _mongoDbConnection.GetCollection<BsonDocument>("Prescriptions");

                var newPrescription = new BsonDocument
        {
            { "PrescriptionId", ObjectId.GenerateNewId() },
            { "PatientName", patientName },
            { "Medicine", medication },
            { "Dosage", dosage },
            { "PrescribedDate", prescribedDate.Value},
            { "NumberOfDays" , NumberofDays},
            { "PatientID", _patientID }

        };

                prescriptionsCollection.InsertOne(newPrescription);
                MessageBox.Show("Prescription saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the input fields after saving
                PatientNameTextBox.Clear();
                MedicineComboBox.SelectedIndex = -1;
                Dosage.SelectedIndex = -1;
                DatePicker.SelectedDate = null;
                NumberOfDaysComboBox.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save prescription: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}