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
        public int Name { get; set; }
        public int Age { get; set; }
        public int BloodTypeID { get; set; }
        public bool Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsEligible { get; set; }
        public string? DisqualifyingFactors { get; set; }

    }
}
