using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class Grant_Class
    {
        public long RowId { get; set; }
        public long ROLE_ID { get; set; }
        public long Menu_Code { get; set; }
        public string Access { get; set; }
        public int MINISTRY_ID { get; set; }
        public string Deleted { get; set; }
        public virtual MENU MENU { get; set; }
        public virtual ROLE ROLE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }
    }
}