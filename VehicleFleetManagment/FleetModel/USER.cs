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
    
    public partial class USER
    {
        public long USERS_ID { get; set; }
        public Nullable<int> MINISTRY_ID { get; set; }
        public Nullable<long> ROLE_ID { get; set; }
        public string Code_Min { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string User_Nme { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string User_Code { get; set; }
        public string State { get; set; }
        public string Saved_Date { get; set; }
        public string Deleted { get; set; }
    
        public virtual MINISTRY MINISTRY { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
