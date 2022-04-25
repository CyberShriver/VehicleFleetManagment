﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Repair_Interface
    {


        //Add method
        int Add(Repair_Class Re);

        //Update Method
        int Update(Repair_Class Re, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Repair_Class Re, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

        //DropDown All Vehicle 
        void DisplayAllVehicle(DropDownList drop);

        //DropDown All Crash 
        void DisplayAllCrash(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop);

        //DropDown Vehicle 
        void DisplayVehicle(DropDownList drop, int id);

        //DropDown Crash 
        void DisplayCarCrash(DropDownList drop, int id);

    }
}
