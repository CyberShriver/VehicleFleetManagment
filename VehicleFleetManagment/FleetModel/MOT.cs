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
    
    public partial class MOT
    {
        public int MOT_ID { get; set; }
        public string MOT_Number { get; set; }
        public string MOT_Agency_Name { get; set; }
        public string Visit_Dte { get; set; }
        public string Validity_End_Dte { get; set; }
        public long VEHICLE_ID { get; set; }
        public int MINISTRY_ID { get; set; }
    
        public virtual VEHICLE VEHICLE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }
    }
}
