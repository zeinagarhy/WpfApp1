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
    /// Interaction logic for VideoCall.xaml
    /// </summary>
    public partial class VideoCall : Window
    {

        public VideoCall()
        {
            InitializeComponent();

        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DoctorDashboard patient = new DoctorDashboard();
            patient.Show();
            this.Close();

        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            DoctorDashboard ap = new DoctorDashboard();
            ap.Show();
            this.Close();
        }
        private void AssessBtn_Click(object sender, RoutedEventArgs e)
        {
            Assessment assessmentPage = new Assessment();

            // Create a new window to host the Assessment page
            Window assessmentWindow = new Window
            {
                Title = "Assessment",
                Content = assessmentPage,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Owner = Application.Current.MainWindow, // Set VideoCall window as owner
                ShowInTaskbar = false,
                WindowStyle = WindowStyle.ToolWindow,
            };

            // Show the assessment window as a modal dialog
            assessmentWindow.ShowDialog();
        }
    }
}