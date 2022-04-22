using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class Leave_Class
    {

        public long LEAVE_ID { get; set; }
        public string Leave_Code { get; set; }
        public long MIN_DRIVER_ID { get; set; }
        public string Carpooling { get; set; }
        public Nullable<int> LEAVE_TYPE_ID { get; set; }
        public string Start_Dte { get; set; }
        public string End_Dte { get; set; }
        public string Demand_Dte { get; set; }
        public string Approved_By { get; set; }
        public string Approved_Dte { get; set; }
        public string Comment { get; set; }
        public string Saved_Date { get; set; }
        public int MINISTRY_ID { get; set; }

        public virtual LEAVE_TYPE LEAVE_TYPE { get; set; }
        public virtual MINISTRY_DRIVER MINISTRY_DRIVER { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }

    }
}