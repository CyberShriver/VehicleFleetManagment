using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class License_Class
    {
        public long LICENSE_ID { get; set; }
        public long DRIVER_ID { get; set; }
        public string Exp_Date { get; set; }
        public string International_License_Code { get; set; }
        public string Inter_License_Code_Exp_Date { get; set; }
        public string License_Code_Mission { get; set; }
        public string License_Code_Mission_Exp_Dte { get; set; }
        public string License_State { get; set; }
        public Nullable<int> MINISTRY_ID { get; set; }
        public string Saved_Dte { get; set; }
        public string License_Number { get; set; }
        public string Issued_On { get; set; }
        public string Issued_At { get; set; }
        public string Issued_Authority { get; set; }
        public string Card_Number { get; set; }
        public string Category_A { get; set; }
        public string Category_B { get; set; }
        public string Category_C { get; set; }
        public string Category_D1 { get; set; }
        public string Category_D2 { get; set; }
        public string Category_E { get; set; }
        public string Category_F { get; set; }
        public string Scanned_Picture { get; set; }

        public virtual MINISTRY MINISTRY { get; set; }
        public virtual MINISTRY_DRIVER MINISTRY_DRIVER { get; set; }

    }
}