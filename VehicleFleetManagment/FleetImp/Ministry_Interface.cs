﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
   public interface Ministry_Interface
    {

        //Add method
        int Add(Ministry_Class Min);

        //Update Method
        int Update(Ministry_Class Min, int id);

        //Update settings Method
        int UpdateSettings(Ministry_Class Min, int id);

        //Delete Method
        int Delete(int id);

        //CHANGE DELETE STATE METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //DISPLAY  All MINISTRY DROPDOWN METHOD
        void DisplayMinistryAll(DropDownList drop);

        //Provide Method
        void provide(Ministry_Class Min, int id);

        //Profile Methode
        void Profile(Ministry_Class Min, string codeMin);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);
    }
}
