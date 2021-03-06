using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class License_Class
    {
        public long LICENSE_ID { get; set; }
        public long MIN_DRIVER_ID { get; set; }
        public string License_Code { get; set; }
        public string Exp_Date { get; set; }
        public string International_License_Code { get; set; }
        public string Inter_License_Code_Exp_Date { get; set; }
        public string License_Code_Mission { get; set; }
        public string License_Code_Mission_Exp_Dte { get; set; }
        public string Bike { get; set; }
        public string Light_Vehicle { get; set; }
        public string Heavy_Weights { get; set; }
        public string Trailer_Weight { get; set; }
        public string FourXfour { get; set; }
        public string License_State { get; set; }
        public Nullable<int> MINISTRY_ID { get; set; }
        public string Saved_Dte { get; set; }

        public virtual MINISTRY MINISTRY { get; set; }
        public virtual MINISTRY_DRIVER MINISTRY_DRIVER { get; set; }

    }
}