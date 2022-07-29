using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;


namespace VehicleFleetManagment.FleetClass
{
    public class Users_Class
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

        public virtual MINISTRY MINISTRY { get; set; }
        public virtual ROLE ROLE { get; set; }

    }
}