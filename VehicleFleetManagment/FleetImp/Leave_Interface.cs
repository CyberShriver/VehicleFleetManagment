using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Leave_Interface
    {


        //Add method
        int Add(Leave_Class Le);

        //Update Method
        int Update(Leave_Class Le, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Leave_Class Le, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);
        //DropDown All Vehicle 
        void DisplayAllDriver(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop);

        //DropDown Vehicle 
        void DisplayDriver(DropDownList drop, int id);

        //DropDown Vehicle 
        void DisplayLeaveType(DropDownList drop);

    }
}
