using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class MOT_Class
    {
        public int MOT_ID { get; set; }
        public string MOT_Number { get; set; }
        public string MOT_Agency_Name { get; set; }
        public string Visit_Dte { get; set; }
        public string Validity_End_Dte { get; set; }
        public long VEHICLE_ID { get; set; }
        public string Deleted { get; set; }
        public int MINISTRY_ID { get; set; }

        public virtual VEHICLE VEHICLE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }

    }
}