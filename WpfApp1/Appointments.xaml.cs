using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Classes;

namespace WpfApp1
{
    public partial class Appointments : Window
    {
        public class AppointmentInfo
        {
            public string PatientName { get; set; }
            public string PatientID { get; set; }
            public DateTime AppointmentTime { get; set; }
        }
        private List<AppointmentInfo> appointmentsList;
        private readonly MongoDbConnection _mongoDbConnection;

        public Appointments()
        {
            InitializeComponent();
            string connectionString = "mongodb+srv://nour:nour@cluster0.dd4wfw5.mongodb.net/";
            _mongoDbConnection = new MongoDbConnection(connectionString);


            // Initialize appointments list (populate with dummy data for demonstration)
            List<AppointmentInfo> appointmentsList = new List<AppointmentInfo>
    {
        new AppointmentInfo
        {
            PatientName = "John Doe",
            PatientID = "#1234",
            AppointmentTime = DateTime.Now.AddHours(1)
        },
        new AppointmentInfo
        {
            PatientName = "Jane Smith",
            PatientID = "#5678",
            AppointmentTime = DateTime.Now.AddHours(2)
        }
        // Add more appointments as needed
    };

            // Set DataContext to the first appointment in the list
            if (appointmentsList.Count > 0)
            {
                this.DataContext = appointmentsList[0];
            }
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

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ap = new MainWindow();
            ap.Show();
            this.Close();
        }

        private void appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments ap = new Appointments();
            ap.Show();
            this.Close();
        }

       

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                DateTime selectedDateTime = (DateTime)e.AddedItems[0];
                DateTime selectedDate = selectedDateTime.Date;
                calendar.SelectedDate = selectedDate;
                string formattedDate = selectedDate.ToString("dd-MM-yyyy");
                TodayDate.Text = formattedDate;
              
            }
        }

       

        private System.Timers.Timer stopwatchTimer = new System.Timers.Timer();
        private int h, m, s, ms;

        private void initializeStopwatch()
        {
            stopwatchTimer.Interval = 1;
            stopwatchTimer.Elapsed += onTimeEvent;
        }

        private void emr_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int patientid = int.Parse(btn.Name.Split('d')[1]);
            // PatientFile pf = new PatientFile();
            // pf.SetPatientID(patientid);
            // pf.Show();
            this.Close();
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            stopwatchTimer.Start();
        }

        private void stop_button_Click(object sender, RoutedEventArgs e)
        {
            stopwatchTimer.Stop();
        }
        private void finance_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
            this.Close();
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

        private void shortcut_finance_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
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

        private void shortcut_chatbot_Click(object sender, RoutedEventArgs e)
        {
            Chatbot ap = new Chatbot();
            ap.Show();
            this.Close();

        }


        private void reset_button_Click(object sender, RoutedEventArgs e)
        {
            stopwatchTimer.Stop();
            h = m = s = ms = 0;
            stopwatch_text.Text = "00:00:00:00";
        }

        private void onTimeEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                ms += 1;

                if (ms == 100)
                {
                    ms = 0;
                    s += 1;
                }

                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }

                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                stopwatch_text.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'), ms.ToString().PadLeft(2, '0'));
            }));
        }

       

        private void AppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle appointment button click event
            Button clickedButton = sender as Button;
            MessageBox.Show($"{clickedButton.Content} clicked");
        }
    }
}
