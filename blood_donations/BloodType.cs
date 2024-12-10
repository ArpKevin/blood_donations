using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_donations
{
    
    public class BloodType
    {
        public int BloodTypeID { get; set; }
        public string BloodTypeName { get; set; }
        
        public BloodType(string sor) {
            var x = sor.Split(';');
            var values = x.Select(x => x.Replace("\"", "")).ToList();
            BloodTypeID = Convert.ToInt32(values[0]);
            BloodTypeName = values[1];
        }

        public override string ToString()
        {
            return $"Blood type id: {BloodTypeID}, Blood type name: {BloodTypeName}";
        }
    }
}