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
using System.Xml.Linq;
using WpfApp1;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PatientFile : Window
    {
        private readonly MongoDbConnection _mongoDbConnection;
        public int PatientID { get; set; }
        public PatientFile()
        {
            InitializeComponent();
            string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
            _mongoDbConnection = new MongoDbConnection(connectionString);

            DisplaySamplePrescription();



        }
        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
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

        private void shortcut_Patients_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
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
        private void PatientFile_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }

        private void shortcut_PatientFile_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
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

        public void SetPatientID(int patientId)
        {
            PatientID = patientId;
            // You can use the PatientID value as needed in the PatientFile window
        }

        private Grid GenerateDateGrid(int day, string month)
        {
            // Create the main Grid
            Grid dateGrid = new Grid
            {
                Width = 120,
                Height = 100,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };

            // Add Rectangle to dateGrid
            dateGrid.Children.Add(new Rectangle
            {
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(242, 154, 52)),
                Opacity = 0.4,
                RadiusX = 20,
                RadiusY = 20,
                Height = 90,
                Width = 90
            });

            // Create a StackPanel for text blocks in dateGrid
            StackPanel textStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Height = 85,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            };

            // Add TextBlocks to textStackPanel
            textStackPanel.Children.Add(new TextBlock
            {
                Text = day.ToString(),
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Inter"),
                Height = 30,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            });

            textStackPanel.Children.Add(new TextBlock
            {
                Text = month,
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Inter"),
                Height = 35,
                TextAlignment = TextAlignment.Center
            });

            // Add textStackPanel to dateGrid
            dateGrid.Children.Add(textStackPanel);

            return dateGrid;
        }
        private Grid GeneratePrescriptionHeaderGrid(string prescriptionNumber)
        {

            // Create the main Grid
            Grid prescriptionHeaderGrid = new Grid
            {

                Height = 60,
                Width = 860,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right
            };
            /*
                        MessageBox.Show(PatientID.ToString());*/
            // Add TextBlock to prescriptionHeaderGrid
            prescriptionHeaderGrid.Children.Add(new TextBlock
            {
                Text = "Prescription " + prescriptionNumber,
                FontSize = 20,
                Foreground = Brushes.Gray,
                FontWeight = FontWeights.Medium,
                FontFamily = new FontFamily("Inter"),
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            });

            return prescriptionHeaderGrid;
        }
        private Grid GenerateVitalSignsGrid()
        {
            // Create the main Grid
            Grid vitalSignsGrid = new Grid
            {
                Height = 40
            };

            // Add Rectangle to vitalSignsGrid
            vitalSignsGrid.Children.Add(new Rectangle
            {
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(231, 231, 231)),
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(212, 212, 212))
            });

            // Add inner Grid to vitalSignsGrid
            Grid innerGrid = new Grid
            {
                Width = 850,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right
            };

            // Add TextBlock to innerGrid
            innerGrid.Children.Add(new TextBlock
            {
                Text = "Clinical Notes",
                FontSize = 20,
                FontWeight = FontWeights.Medium,
                FontFamily = new FontFamily("Inter"),
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            });

            // Add inner Grid to vitalSignsGrid
            vitalSignsGrid.Children.Add(innerGrid);

            return vitalSignsGrid;
        }
        public UIElement GenerateSymptomsGrid(string name)
        {
            var symptomsGrid = new Grid
            {
                Height = 40
            };

            var rectangle = new Rectangle
            {
                Fill = Brushes.Transparent,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(212, 212, 212))
            };

            var innerGrid = new Grid
            {
                Width = 850
            };

            var textBlock = new TextBlock
            {
                Text = name,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                FontSize = 17,
                FontWeight = FontWeights.Medium,
                FontFamily = new FontFamily("Inter"),
                Foreground = Brushes.Gray
            };

            // Add controls to innerGrid
            innerGrid.Children.Add(textBlock);

            // Add controls to symptomsGrid
            symptomsGrid.Children.Add(rectangle);
            symptomsGrid.Children.Add(innerGrid);

            return symptomsGrid;
        }
        public UIElement GenerateTextBlockGrid(string text)
        {
            var textBlockGrid = new Grid
            {
                Height = 80
            };

            var textBlock = new TextBlock
            {
                Text = text,
                FontSize = 15,
                FontFamily = new System.Windows.Media.FontFamily("Inter"),
                Width = 800,
                Height = 50
            };

            // Add controls to textBlockGrid
            textBlockGrid.Children.Add(textBlock);

            return textBlockGrid;
        }

        Dictionary<int, string> monthAbbreviations = new Dictionary<int, string>();
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private Button previousButton;
        private SolidColorBrush originalColor;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Prescriptions.Visibility = Visibility.Collapsed;
            Tasks.Visibility = Visibility.Collapsed;
            Assessment.Visibility = Visibility.Collapsed;
            Appointments_Fees.Visibility = Visibility.Collapsed;
            Comments.Visibility = Visibility.Collapsed;

            if (previousButton != null && previousButton != clickedButton)
            {
                // Revert previous button content color
                previousButton.Foreground = originalColor;

            }

            previousButton = clickedButton;
            originalColor = (SolidColorBrush)clickedButton.Foreground;

            // Change button content color to black
            clickedButton.Foreground = Brushes.Black;
            if (clickedButton.Content.Equals("Assessment"))
            {
                Assessment.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Prescriptions"))
            {

                //generateALLPresc(PatientID);
                Prescriptions.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Appointments and Fees"))
            {
                Appointments_Fees.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Labs"))
            {
                Tasks.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Comments"))
            {
                Comments.Visibility = Visibility.Visible;
            }

            // Create a line with the width of the button and color black
            Line line = new Line
            {
                X1 = 0,
                Y1 = clickedButton.ActualHeight / 2,
                X2 = clickedButton.ActualWidth,
                Y2 = clickedButton.ActualHeight / 2,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };


            // Find the parent grid of the button and add the line to it
            if (clickedButton.Parent is Grid grid)
            {
                grid.Children.Add(line);
                Grid.SetRow(line, Grid.GetRow(clickedButton)); // Set the line in the same row as the button
            }
        }


        public class Prescription
        {
            public int PrescriptionID { get; set; }
            public string Diagnosis { get; set; }
            public string AdditionalNotes { get; set; }
            public string MedicineName { get; set; }
            public Boolean Anxiety { get; set; }
            public Boolean Insomnia { get; set; }
            public Boolean Restlessness { get; set; }

            public DateTime DateCreated { get; set; }
        }
        Prescription samplePrescription = new Prescription
        {
            PrescriptionID = 1,
            Diagnosis = "Generalized Anxiety Disorder",
            AdditionalNotes = "Patient should attend weekly therapy sessions and practice mindfulness exercises.",
            MedicineName = "Sertraline",
            DateCreated = DateTime.Now
        };
        private void DisplaySamplePrescription()
        {
            Prescription samplePrescription = new Prescription
            {
                PrescriptionID = 1,
                Anxiety = true,
                Insomnia = true,
                Restlessness = true,

                Diagnosis = "Generalized Anxiety Disorder",
                AdditionalNotes = "Patient should attend weekly therapy sessions and practice mindfulness exercises.",
                MedicineName = "Sertraline",
                DateCreated = DateTime.Now
            };

            GeneratePresc(samplePrescription);
        }


        private void GeneratePresc(Prescription p)
        {
            StackPanel s = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Height = 500
            };

            Grid grid = new Grid
            {
                Width = 870
            };
            Rectangle r = new Rectangle
            {
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(240, 240, 240)),
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(212, 212, 212))
            };
            grid.Children.Add(r);

            StackPanel sv = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            sv.Children.Add(GeneratePrescriptionHeaderGrid("#" + p.PrescriptionID.ToString()));
            sv.Children.Add(GenerateVitalSignsGrid());
            sv.Children.Add(GenerateSymptomsGrid("Symptoms"));
            sv.Children.Add(GenerateTextBlockGrid("Anxiety, Insomnia, Restlessness"));
            sv.Children.Add(GenerateSymptomsGrid("Observations"));
            sv.Children.Add(GenerateTextBlockGrid(p.Diagnosis + ", additional note: " + p.AdditionalNotes));
            sv.Children.Add(GenerateSymptomsGrid("Medications"));
            sv.Children.Add(GenerateTextBlockGrid(p.MedicineName));

            grid.Children.Add(sv);

            // Set the month abbreviation
            Dictionary<int, string> monthAbbreviations = new Dictionary<int, string>();

            string abbreviation = monthAbbreviations.TryGetValue(p.DateCreated.Month, out var result) ? result : null;
            s.Children.Add(GenerateDateGrid(p.DateCreated.Day, abbreviation));
            s.Children.Add(grid);

            prescmain.Children.Add(s);
        }








    }
}
