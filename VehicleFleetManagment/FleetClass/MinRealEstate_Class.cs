using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class MinRealEstate_Class
    {

        public int MIN_REAL_ESTATE_ID { get; set; }
        public int REAL_ESTATE_ID { get; set; }
        public int MINISTRY_ID { get; set; }
        public string Deleted { get; set; }
        public string Quantity { get; set; }
        public string Comment { get; set; }

        public virtual MINISTRY MINISTRY { get; set; }
        public virtual REAL_ESTATE REAL_ESTATE { get; set; }

    }
}