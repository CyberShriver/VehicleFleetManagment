using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Assurance_Interface
    {


        //Add method
        int Add(Assurance_Class As);

        //Update Method
        int Update(Assurance_Class As, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd,string codeMin);

        //Display Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(Assurance_Class As, int id);

        //count
        int count(string codeMin);

        //count All
        int countAll();

        //Research Method
        void Research(GridView gd,string codeMin, string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);
        //DropDown All Vehicle 
        void DisplayAllVehicle(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop,string codeMin);

        //DropDown Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //DropDown Vehicle 
        void DisplayVehicle(DropDownList drop, int id);


    }
}
