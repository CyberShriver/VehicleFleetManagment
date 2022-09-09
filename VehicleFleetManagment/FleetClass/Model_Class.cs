using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class Model_Class
    {

        public int MODEL_ID { get; set; }
        public Nullable<int> MARK_ID { get; set; }
        public string Model_Name { get; set; }
        public string Comment { get; set; }
        public string Deleted { get; set; }

        public virtual MARK MARK { get; set; }

    }
}