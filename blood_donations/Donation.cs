namespace blood_donations
{
    public class Donation
    {
        public int DonationID { get; set; }
        public int DonorID { get; set; }
        public int StationID { get; set; }
        public DateTime DonationDate { get; set; }
        public int AmountDonated { get; set; }

        public Donation(string sor)
        {
            var values = sor.Split(';').Select(x => x.Replace("\"", "")).ToList();
            DonationID = Convert.ToInt32(values[0]);
            DonorID = Convert.ToInt32(values[1]);
            StationID = Convert.ToInt32(values[2]);
            DonationDate = DateTime.Parse(values[3]);
            AmountDonated = Convert.ToInt32(values[4]);
        }

        public override string ToString()
        {
            return $"Donation ID: {DonationID}, Donor ID: {DonorID}, Station ID: {StationID}, Date: {DonationDate}, Amount: {AmountDonated}ml";
        }
    }
}