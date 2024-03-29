﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagment.FleetClass;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetImp
{
   public interface Vehicle_Interface
    {
        //Add method
        int Add(Vehicle_Class Ve);

        //Update Method
        int Update(Vehicle_Class Ve, int id);

        //Delete Method
        int Delete(int id);

        //Delete State METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd, string codeMin);

        //Display All Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(Vehicle_Class Ve, int id);

        //PROVIDE METHOD by plate
        int ProvideByPlate(Vehicle_Class Veh, string plate);

        //count
        int count(string codeMin);

        //COUNT AVAILABLE METHOD
        int countAvailable(string codeMin);

        //COUNT UNAVAILABLE METHOD
        int countUnavailable(string codeMin);

        //count All
        int countAll();

        //Research Method
        void Research(GridView gd, string codeMin, string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop, string codeMin);

        //DropDown All Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //DropDown Model 
        void DisplayModel(DropDownList drop);

        //DropDown Fuel 
        void DisplayFuel(DropDownList drop);
        //DropDown BodyType 
        void DisplayBodyType(DropDownList drop);

        //Update unavailability of vahicle
        int UpdateVehUnavailable(Vehicle_Class veh, string LocalPlate);

        //Update Availability of vahicle
        int UpdateVehAvailable(Vehicle_Class veh, string LocalPlate);

        //UPDATE MINISTRY DRIVER STATE METHOD 
         int UpdateMinDriverState(string plate);

        //CHECK MINISTRY DRIVER STATE METHOD 
        int CheckMinDriverState(string plate);
    }
}
