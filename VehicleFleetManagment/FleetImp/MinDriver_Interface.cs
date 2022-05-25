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
        void Display(GridView gd,string codeMin);

        //Display All Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(MinDriver_Class Md, int id);

        //count
        int count(string codeMin);

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

        //DropDown Driver 
        void DisplayDriver(DropDownList drop,string codeMin);

        //DISPLAY All Driver for specific Ministry  METHOD 
        void DisplayDriverMinAll(DropDownList drop, string codeMin, int idMinDr);

        //DropDown All Driver 
        void DisplayDriverAll(DropDownList drop);

        //DISPLAY VEHICLE DEPENDS ON MINISTRY CHOOSEN IN AUTOPOSTBACK METHOD
        void DisplayVehicle(DropDownList drop, int id);

        //DISPLAY  ALL VEHICLE FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD
        void DisplayAllMinVehicle(DropDownList drop, string codeMin,int idMinDr);

        //DropDown All Vehicle 
        void DisplayAllVehicle(DropDownList drop);

    
    }
}
