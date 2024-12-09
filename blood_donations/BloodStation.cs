using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_donations
{
    public class BloodStation
    {
        public int StationID { get; set; }  // Primary Key
        public string StationName { get; set; }
        public string Address { get; set; }
        public string Phone_no { get; set; }
    }

}
