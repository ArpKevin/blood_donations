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
        private List<Donor> donors;
        private List<Donation> donations;
        public MainWindow()
        {
            InitializeComponent();

            donations = new List<Donation>();

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

            donors = new List<Donor>();
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
            var selectedDonor = donors.FirstOrDefault(d => d.DonorID == (int)eligibilityComboBox.SelectedValue);

            var lastDonationDate = donations
                .Where(d => d.DonorID == selectedDonor.DonorID)
                .OrderByDescending(d => d.DonationDate)
                .FirstOrDefault()?.DonationDate;

            var eligibilityMessage = string.Empty;
            if (!selectedDonor.IsEligible)
            {
                eligibilityMessage = $"Not eligible - {selectedDonor.DisqualifyingFactors}";
            }
            else if (lastDonationDate != null && lastDonationDate.Value.AddMonths(3) > DateTime.Now)
            {
                eligibilityMessage = "Not eligible: Must wait 3 months from last donation.";
            }
            else
            {
                eligibilityMessage = "Eligible for donation.";
            }

            eligibilityInfoPanel.Text = $"{selectedDonor.Name} ({selectedDonor.ID_card})\n" +
                                        $"Registration Date: {selectedDonor.RegistrationDate.ToShortDateString()}\n" +
                                        $"Last donation Date: {(lastDonationDate == null ? "Donor has never donated." : lastDonationDate.Value.ToShortDateString())}\n" +
                                        $"Eligibility: {eligibilityMessage}";

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