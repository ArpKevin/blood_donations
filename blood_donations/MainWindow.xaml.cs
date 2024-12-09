using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace blood_donations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            donorNameTextbox.Text = string.Empty;
            donorAgeTextbox.Text = string.Empty;
            bloodTypeComboBox.SelectedItem = null;
            lastDonationDatePicker.SelectedDate = null;
        }
    }
}