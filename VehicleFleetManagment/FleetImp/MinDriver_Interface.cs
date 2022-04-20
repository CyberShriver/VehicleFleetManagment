using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface MinDriver_Interface
    {


        //Add method
        int Add(MinDriver_Class Md);

        //Update Method
        int Update(MinDriver_Class Md, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(MinDriver_Class Md, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop);

        //DropDown Driver 
        void DisplayDriver(DropDownList drop);

        //DropDown Vehicle 
        void DisplayVehicle(DropDownList drop, int id);

        //DropDown All Vehicle 
        void DisplayAllVehicle(DropDownList drop);

    }
}
