using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleFleetManagment.FleetClass
{
    public class Provider_Class
    {

        public long PROVIDER_ID { get; set; }
        public string Provider_Type { get; set; }
        public string Provider_Code { get; set; }
        public string Full_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Stat { get; set; }
        public string CNI { get; set; }
        public string DOB { get; set; }
        public string Deleted { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public string Contract { get; set; }
        public string Saved_Date { get; set; }
    }
}