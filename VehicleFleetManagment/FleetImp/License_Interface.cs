using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    interface License_Interface
    {

        //Add method
        int Add(License_Class Li);

        //Update Method
        int Update(License_Class Li, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(License_Class Li, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);
        //DropDown All Driver 
        void DisplayAllDriver(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop);

        //DropDown Driver 
        void DisplayDriver(DropDownList drop, int id);




    }
}
