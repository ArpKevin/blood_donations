using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_donations
{
    public class Donor
    {
        public int DonorID { get; set; }
        public string ID_card { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int BloodTypeID { get; set; }
        public string Phone_no { get; set; }
        public string Gender { get; set; }
        public DateTime Registration_date { get; set; }

        public BloodType BloodType { get; set; }
        public List<Donation> Donations { get; set; }
    }

    public class BloodStation
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string Address { get; set; }
        public string Phone_no { get; set; }

        public List<Donation> Donations { get; set; }
    }

    public class Donation
    {
        public int DonationID { get; set; }
        public int DonorID { get; set; }
        public int StationID { get; set; }
        public DateTime DonationDate { get; set; }
        public int AmountDonated { get; set; }

        public Donor Donor { get; set; }
        public BloodStation Station { get; set; }
    }

    public class BloodType
    {
        public int BloodTypeID { get; set; }
        public string BloodGroup { get; set; }
        public string RhFactor { get; set; }

        public List<Donor> Donors { get; set; }
    }
}
