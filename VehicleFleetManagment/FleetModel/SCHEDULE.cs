//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleFleetManagment.FleetModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SCHEDULE
    {
        public int SCHEDULE_ID { get; set; }
        public long VEHICLE_ID { get; set; }
        public string Comment { get; set; }
        public string Saved_Date { get; set; }
        public int MINISTRY_ID { get; set; }
        public string Mission { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Deleted { get; set; }
        public string State { get; set; }
    
        public virtual VEHICLE VEHICLE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }
    }
}
