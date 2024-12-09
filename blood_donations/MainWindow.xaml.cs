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
        private List<BloodType> bloodTypes = new List<BloodType>
        {
            new BloodType { BloodTypeID = 1, BloodTypeName = "A+" },
            new BloodType { BloodTypeID = 2, BloodTypeName = "A-" },
            new BloodType { BloodTypeID = 3, BloodTypeName = "B+" },
            new BloodType { BloodTypeID = 4, BloodTypeName = "B-" },
            new BloodType { BloodTypeID = 5, BloodTypeName = "O+" },
            new BloodType { BloodTypeID = 6, BloodTypeName = "O-" },
            new BloodType { BloodTypeID = 7, BloodTypeName = "AB+" },
            new BloodType { BloodTypeID = 8, BloodTypeName = "AB-" }
        };
        public MainWindow()
        {
            InitializeComponent();

            bloodTypeComboBox.ItemsSource = bloodTypes;
            bloodTypeComboBox.DisplayMemberPath = "BloodTypeName";
            bloodTypeComboBox.SelectedValuePath = "BloodTypeID";

            stockBloodTypeComboBox.ItemsSource = bloodTypes;
            stockBloodTypeComboBox.DisplayMemberPath = "BloodTypeName";
            stockBloodTypeComboBox.SelectedValuePath = "BloodTypeID";
        }

        private void ComboBoxStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isStockStationSelected = stockStatinComboBox.SelectedItem != null;
            bool isBloodTypeSelected = stockBloodTypeComboBox.SelectedItem != null;

            requestStockButton.IsEnabled = isStockStationSelected && isBloodTypeSelected;
        }

        private void EligibilityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            donorNameTextbox.Text = string.Empty;
            donorAgeTextbox.Text = string.Empty;
            donorPhoneNumberTextbox.Text = string.Empty;
            bloodTypeComboBox.SelectedIndex = -1;
            lastDonationDatePicker.SelectedDate = null;
        }
    }
}