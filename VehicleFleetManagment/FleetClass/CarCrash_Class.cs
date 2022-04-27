using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class CarCrash_Class
    {
        public long CAR_CRASH_ID { get; set; }
        public string Crash_Code { get; set; }
        public Nullable<long> VEHICLE_ID { get; set; }
        public string Crash_Date { get; set; }
        public string Crash_Time { get; set; }
        public Nullable<double> Crash_Mileage { get; set; }
        public Nullable<long> MIN_DRIVER_ID { get; set; }
        public string Compensation_Rule_Dte { get; set; }
        public string Circumstance { get; set; }
        public string Passenger_Comment { get; set; }
        public string Crash_Place { get; set; }
        public string Full_Crash_Address { get; set; }
        public string Crash_Info { get; set; }
        public string Responsible { get; set; }
        public string Crash_Reason { get; set; }
        public string Weather { get; set; }
        public double Estimated_Speed { get; set; }
        public string Condition_After_Crash { get; set; }
        public string Driver_Age { get; set; }
        public int Tot_Number_Driver_drives { get; set; }
        public string Crash_Damage { get; set; }
        public string Insurance_Declaration_Dte { get; set; }
        public string Report_Dte { get; set; }
        public string Final_Report_Dte { get; set; }
        public string Damage_Description { get; set; }
        public string Damage_Third_Party { get; set; }
        public Nullable<double> Claim_Compensation_Amount { get; set; }
        public string Damaged_Vehicle { get; set; }
        public double Legal_Cost { get; set; }
        public string Third_Party_Injures { get; set; }
        public string Injures_Employee { get; set; }
        public Nullable<double> Local_Insurance_Compensation_Amount { get; set; }
        public string Payed_Employee { get; set; }
        public Nullable<double> Employee_Amount_Recovered { get; set; }
        public Nullable<double> ThirdParty_Amount_Recovered { get; set; }
        public string Crash_Pic { get; set; }
        public string Saved_Date { get; set; }
        public string Stat { get; set; }
        public Nullable<int> MINISTRY_ID { get; set; }

        public virtual MINISTRY MINISTRY { get; set; }
        public virtual VEHICLE VEHICLE { get; set; }
        public virtual MINISTRY_DRIVER MINISTRY_DRIVER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPAIR> REPAIRs { get; set; }

    }
}