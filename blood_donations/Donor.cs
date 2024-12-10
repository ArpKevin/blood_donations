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
        public int BloodTypeID { get; set; }
        public bool Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsEligible { get; set; }
        public string? DisqualifyingFactors { get; set; }

        public Donor(string sor)
        {
            var values = sor.Split(';').Select(x => x.Replace("\"", "")).ToList();
            DonorID = Convert.ToInt32(values[0]);
            ID_card = values[1];
            Name = values[2];
            Age = Convert.ToInt32(values[3]);
            BloodTypeID = Convert.ToInt32(values[4]);
            Gender = values[5] == "1";
            RegistrationDate = DateTime.Parse(values[6]);
            IsEligible = values[7] == "1";
            DisqualifyingFactors = values[8] != "" ? values[8] : null;
        }

        public override string ToString()
        {
            return $"Donor ID: {DonorID}, ID Card: {ID_card}, Name: {Name}, Age: {Age}, BloodTypeID: {BloodTypeID}, Gender: {(Gender ? "Male" : "Female")}, Registration Date: {RegistrationDate}, Is Eligible: {IsEligible}, Disqualifying Factors: {DisqualifyingFactors}";
        }
    }
}