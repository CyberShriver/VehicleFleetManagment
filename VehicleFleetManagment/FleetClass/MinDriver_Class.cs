using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class MinDriver_Class
    {

        public long MIN_DRIVER_ID { get; set; }
        public string Min_Driver_RegNumber { get; set; }
        public long DRIVER_ID { get; set; }
        public int MINISTRY_ID { get; set; }
        public string Position_Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public virtual DRIVER DRIVER { get; set; }
        public virtual ICollection<LEAVE> LEAVEs { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }
        public virtual ICollection<LICENSE> LICENSEs { get; set; }
        public virtual ICollection<CAR_CRASH> CAR_CRASH { get; set; }


    }
}