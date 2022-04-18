using System;
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

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Vehicle_Class Ve, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop);

        //DropDown Model 
        void DisplayModel(DropDownList drop);

        //DropDown Fuel 
        void DisplayFuel(DropDownList drop);
        //DropDown BodyType 
        void DisplayBodyType(DropDownList drop);
    }
}
