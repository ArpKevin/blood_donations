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
        private const string csvFolderPath = @"..\..\..\src\exported_tables\";
        private readonly List<Donor> donors = new();
        private readonly List<Donation> donations = new();
        private readonly List<BloodType> bloodTypes = new();
        private readonly List<BloodStation> bloodStations = new();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            ConfigureComboBoxes();

            //foreach (var item in File.ReadLines(csvFolderPath + "donors.csv").Skip(1))
            //{
            //    donors.Add(new(item));
            //}

            //eligibilityComboBox.ItemsSource = donors;
            //eligibilityComboBox.DisplayMemberPath = "Name";
            //eligibilityComboBox.SelectedValuePath = "DonorID";

            //foreach (var item in File.ReadLines(csvFolderPath + "donations.csv").Skip(1))
            //{
            //    donations.Add(new(item));
            //}

            //foreach (var item in File.ReadLines(csvFolderPath + "blood_types.csv").Skip(1))
            //{
            //    bloodTypes.Add(new(item));
            //}

            //stockBloodTypeComboBox.ItemsSource = bloodTypes;
            //stockBloodTypeComboBox.DisplayMemberPath = "BloodTypeName";
            //stockBloodTypeComboBox.SelectedValuePath = "BloodTypeID";


            //foreach (var item in File.ReadLines(csvFolderPath + "blood_stations.csv").Skip(1))
            //{
            //    bloodStations.Add(new(item));
            //}

            //stockStationComboBox.ItemsSource = bloodStations;
            //stockStationComboBox.DisplayMemberPath = "StationName";
            //stockStationComboBox.SelectedValuePath = "StationID";
        }

        private void LoadData()
        {
            LoadEntities("donors.csv", donors, line => new Donor(line));
            LoadEntities("donations.csv", donations, line => new Donation(line));
            LoadEntities("blood_types.csv", bloodTypes, line => new BloodType(line));
            LoadEntities("blood_stations.csv", bloodStations, line => new BloodStation(line));
        }

        private void LoadEntities<T>(string fileName, List<T> list, Func<string, T> parseFunction)
        {
            var filePath = System.IO.Path.Combine(csvFolderPath, fileName);
            list.AddRange(File.ReadLines(filePath).Skip(1).Select(parseFunction));
        }

        private void ConfigureComboBoxes()
        {
            ConfigureComboBox(eligibilityComboBox, donors, "Name", "DonorID");
            ConfigureComboBox(stockBloodTypeComboBox, bloodTypes, "BloodTypeName", "BloodTypeID");
            ConfigureComboBox(stockStationComboBox, bloodStations, "StationName", "StationID");
        }

        private static void ConfigureComboBox<T>(ComboBox comboBox, List<T> itemsSource, string displayMemberPath, string selectedValuePath)
        {
            comboBox.ItemsSource = itemsSource;
            comboBox.DisplayMemberPath = displayMemberPath;
            comboBox.SelectedValuePath = selectedValuePath;
        }

        private void ComboBoxStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //bool isStockStationSelected = stockStationComboBox.SelectedItem != null;
            //bool isBloodTypeSelected = stockBloodTypeComboBox.SelectedItem != null;

            //bool bothStockComboboxesSelected = isStockStationSelected && isBloodTypeSelected;

            //requestStockButton.IsEnabled = bothStockComboboxesSelected;
            //stockLabel.Visibility = bothStockComboboxesSelected ? Visibility.Visible : Visibility.Collapsed;

            requestStockButton.IsEnabled = stockStationComboBox.SelectedItem != null && stockBloodTypeComboBox.SelectedItem != null;
            stockLabel.Visibility = requestStockButton.IsEnabled ? Visibility.Visible : Visibility.Collapsed;
        }

        private void EligibilityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (eligibilityComboBox.SelectedValue != null)
            {
                var selectedDonor = donors.FirstOrDefault(d => d.DonorID == (int)eligibilityComboBox.SelectedValue);

                var donationsDate = donations
                    .Where(d => d.DonorID == selectedDonor.DonorID)
                    .OrderByDescending(d => d.DonationDate);

                var lastDonationDate = donationsDate
                    .FirstOrDefault()?.DonationDate;

                var eligibilityMessage = string.Empty;
                if (!selectedDonor.IsEligible)
                {
                    eligibilityMessage = $"Not eligible - {selectedDonor.DisqualifyingFactors}";
                }
                else if (lastDonationDate != null && lastDonationDate.Value.AddMonths(3) > DateTime.Now)
                {
                    eligibilityMessage = "Not eligible - Must wait 3 months from last donation.";
                }
                else
                {
                    eligibilityMessage = "Eligible for donation.";
                }

                eligibilityInfoPanel.Text = $"{selectedDonor.Name} ({selectedDonor.ID_card})\n" +
                    $"Registration Date: {selectedDonor.RegistrationDate.ToShortDateString()}\n" +
                    (donationsDate.Any()
                        ? $"List of all previous donations:\n\t{string.Join("\n\t", donationsDate
                            .Where(d => d.DonationDate.HasValue)
                            .Select(d => d.DonationDate.Value.ToShortDateString()))}\n"
                        : string.Empty) +
                    $"Last Donation Date: {(lastDonationDate == null ? "Donor has never donated." : lastDonationDate.Value.ToShortDateString())}\n" +
                    $"Eligibility: {eligibilityMessage}";
            }
            else
            {
                eligibilityInfoPanel.Text = string.Empty;
            }

        }
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            eligibilityComboBox.SelectedItem = null;
            stockStationComboBox.SelectedItem = null;
            stockBloodTypeComboBox.SelectedItem = null;

        }

        private void requestStockButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBloodType = (BloodType)stockBloodTypeComboBox.SelectedItem;
            var selectedStation = (BloodStation)stockStationComboBox.SelectedItem;

            var totalStock = donations
                .Where(d => d.StationID == selectedStation.StationID &&
                            donors.FirstOrDefault(don => don.DonorID == d.DonorID)?.BloodTypeID == selectedBloodType.BloodTypeID)
                .Sum(d => d.AmountDonated);

            stockLabel.Text = $"The current stock of Type {selectedBloodType.BloodTypeName} blood at the following station: {selectedStation.StationName} - is {(double)totalStock / 1000} liters.";
        }
    }
}