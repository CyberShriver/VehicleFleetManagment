using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Crash_Interface
    {

        //Add method
        int Add(CarCrash_Class Cr);

        //Update Method
        int Update(CarCrash_Class Cr, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd,string codeMin);

        //Display All Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(CarCrash_Class Cr, int id);

        //count
        int count(string codeMin);

        //count All
        int countAll();

        //Research Method
        void Research(GridView gd,string codeMin, string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);

        //DropDown All Driver 
        void DisplayAllDriver(DropDownList drop);

        //DropDown patricular Driver 
        void DisplayDriver(DropDownList drop,string plat);

        //DISPLAY METHOD paticular Vehicle
        void DisplayVehicle(DropDownList drop, int id);

        //DropDown All Vehicle 
        void DisplayAllVehicle(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop,string codeMin);

        //DropDown AllMinistry 
        void DisplayMinistryAll(DropDownList drop);

        // DISPLAY DRIVER FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD(In case of Edit) WHEN DRIVER AND VEH NOT ON POST
         void DisplaySelectedDriver(DropDownList drop, string codeMin, int id);

        //DISPLAY VEHICLE FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD ( In case of Edit) WHEN DRIVER AND VEH NOT ON POST
        void DisplaySelectedVehicle(DropDownList drop, string codeMin, int id);



    }
}
