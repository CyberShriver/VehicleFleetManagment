using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class VehicleFuelSup_Class
    {
        public long VEHICLE_FUEL_ID { get; set; }
        public long VEHICLE_ID { get; set; }
        public Nullable<int> MINISTRY_ID { get; set; }
        public string Fuel_Type { get; set; }
        public string Tank_Type { get; set; }
        public string Tank_Code { get; set; }
        public string Provider_Code { get; set; }
        public double Odometer { get; set; }
        public double Initial_Qty { get; set; }
        public double Consumed_Qty { get; set; }
        public double United_Price { get; set; }
        public double Total_Price { get; set; }
        public double Liter_100_km { get; set; }
        public string Comment { get; set; }
        public string Saved_Date { get; set; }

        public virtual MINISTRY MINISTRY { get; set; }
        public virtual VEHICLE VEHICLE { get; set; }

    }
}