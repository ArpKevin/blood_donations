using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_donations
{
    public class BloodStation
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string Address { get; set; }
        public string Phone_no { get; set; }

        public BloodStation(string sor)
        {
            var x = sor.Split(';');
            var values = x.Select(x => x.Replace("\"", "")).ToList();
            StationID = Convert.ToInt32(values[0]);
            StationName = values[1];
            Address = values[2];
            Phone_no = values[3];
        }

        public override string ToString()
        {
            return $"Station: {StationID}, Station name: {StationName}, Station address: {Address}, Phone number: {Phone_no}";
        }
    }

    

}
