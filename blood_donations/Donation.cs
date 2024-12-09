using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_donations
{
    public class Donation
    {
        public int DonationID { get; set; }  // Primary Key
        public int DonorID { get; set; }     // Foreign Key to Donor Table
        public int StationID { get; set; }   // Foreign Key to BloodStation Table
        public DateTime DonationDate { get; set; }
        public int AmountDonated { get; set; }  // Amount donated in milliliters (or any unit you use)
    }
}