using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagment.FleetClass;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetImp
{
    public interface VehicleFuelSupp_Interface
    {


        //Add method
        int Add(VehicleFuelSup_Class Ve);

        //Update Method
        int Update(VehicleFuelSup_Class Ve, int id);

        //Delete Method
        int Delete(int id);

        //Delete State METHOD
         int DeleteState(int id);
        //Display Method
        void Display(GridView gd,string codeMin);

        //Display ALL Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(VehicleFuelSup_Class Ve, int id);

        //count
        int count(string codeMin);

        //count All
        int countAll();

        //Research Method
        void Research(GridView gd,string codeMin, string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop,string codeMin);

        //DropDown All Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //DropDown all Vehicl 
        void DisplayAllVehicle(DropDownList drop);

        //DropDown Vehicle for specific ministry 
        void DisplayVehicle(DropDownList drop,string codeMin);

        //DropDown Provider 
        void DisplayProvider(DropDownList drop);

        //DISPLAY  Fuel Type Consumed By This Vehicle
         void DisplayFuelType(DropDownList drop, string Plate);

        //DISPLAY  Vehicle category
        void DisplayVehicleCategory(DropDownList drop, string Plate);
    }
}
