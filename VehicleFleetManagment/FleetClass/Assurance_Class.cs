using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class Assurance_Class
    {

        public long ASSURANCE_ID { get; set; }
        public long VEHICLE_ID { get; set; }
        public int MINISTRY_ID { get; set; }
        public string Maintenance_Type { get; set; }
        public string Insurance_Policy { get; set; }
        public string Insurance_Start_Date { get; set; }
        public string Local_Insurance_Exp_Date { get; set; }
        public long Amount { get; set; }
        public string Insurance_Company { get; set; }
        public string Comment { get; set; }
        public string Insurance_State { get; set; }

        public virtual VEHICLE VEHICLE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }

    }
}