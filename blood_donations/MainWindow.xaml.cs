using System.IO;
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
        public string csvFolderPath = @"..\..\..\src\exported_tables\";
        public MainWindow()
        {
            InitializeComponent();

            
            List<BloodType> bloodTypes = new();
            foreach (var item in File.ReadLines(csvFolderPath + "blood_types.csv").Skip(1))
            {
                bloodTypes.Add(new(item));
            }

            bloodTypeComboBox.ItemsSource = bloodTypes;
            bloodTypeComboBox.DisplayMemberPath = "BloodTypeName";
            bloodTypeComboBox.SelectedValuePath = "BloodTypeID";

            stockBloodTypeComboBox.ItemsSource = bloodTypes;
            stockBloodTypeComboBox.DisplayMemberPath = "BloodTypeName";
            stockBloodTypeComboBox.SelectedValuePath = "BloodTypeID";

            List<BloodStation> bloodStations = new();
            foreach (var item in File.ReadLines(csvFolderPath + "blood_stations.csv").Skip(1))
            {
                bloodStations.Add(new(item));
            }

            stockStationComboBox.ItemsSource = bloodStations;
            stockStationComboBox.DisplayMemberPath = "StationName";
            stockStationComboBox.SelectedValuePath = "StationID";

            List<Donor> donors = new();
            foreach (var item in File.ReadLines(csvFolderPath + "donors.csv").Skip(1))
            {
                donors.Add(new(item));
            }

            eligibilityComboBox.ItemsSource = donors;
            eligibilityComboBox.DisplayMemberPath = "Name";
            eligibilityComboBox.SelectedValuePath = "DonorID";

        }

        private void ComboBoxStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isStockStationSelected = stockStationComboBox.SelectedItem != null;
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
            bloodTypeComboBox.SelectedIndex = -1;
            lastDonationDatePicker.SelectedDate = null;
        }
    }
}