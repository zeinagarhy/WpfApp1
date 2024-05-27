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


        public Prescriptions()
        {
            InitializeComponent();


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


    }
}