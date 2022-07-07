using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Schedule_Interface
    {
        //Add method
        int Add(Schedule_Class sc);

        //Update Method
        int Update(Schedule_Class sc, int id);

        //Delete Method
        int Delete(int id);

        //Display Method
        void Display(GridView gd,string codeMin);

        //Display All Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(Schedule_Class sc, int id);

        //count
        int count( string codeMin);

        //count All
        int countAll();

        //Research Method
        void Research(GridView gd,string codeMin, string SearchText);

        //Research ALL Method
        void ResearchAll(GridView gd, string SearchText);

        //DropDown All Vehicle 
        void DisplayAllVehicle(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop,string codeMin);

        //DropDown ALL Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //DropDown Vehicle 
        void DisplayVehicle(DropDownList drop, int id);


    }
}
