﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetClass
{
    public class Schedule_Class
    {
        public int SCHEDULE_ID { get; set; }
        public long VEHICLE_ID { get; set; }
        public string Comment { get; set; }
        public string Saved_Date { get; set; }
        public int MINISTRY_ID { get; set; }
        public string Mission { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string State { get; set; }
        public string Deleted { get; set; }
        public virtual VEHICLE VEHICLE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }

    }
}