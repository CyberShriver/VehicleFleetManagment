using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;
namespace VehicleFleetManagment.FleetClass
{
    public class Repair_Class
    {

        public long REPAIR_ID { get; set; }
        public string Work_Number { get; set; }
        public long VEHICLE_ID { get; set; }
        public string Reason { get; set; }
        public string Internal_External { get; set; }
        public Nullable<long> CAR_CRASH_ID { get; set; }
        public string Location_Code { get; set; }
        public string Work_Status { get; set; }
        public string Start_Dte { get; set; }
        public string End_Dte { get; set; }
        public Nullable<double> Odometer_IN { get; set; }
        public Nullable<double> Odometer_OUT { get; set; }
        public string Start_Work_Time { get; set; }
        public string End_Work_Time { get; set; }
        public int Off_Service_Days_Number { get; set; }
        public string Participant_Emp_Code { get; set; }
        public string Comment { get; set; }
        public string Saved_Date { get; set; }
        public Nullable<int> MINISTRY_ID { get; set; }

        public virtual CAR_CRASH CAR_CRASH { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }
        public virtual VEHICLE VEHICLE { get; set; }

    }
}