using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;


namespace VehicleFleetManagment.FleetImp
{
   public interface MinRealEstate_Interface
    {

        //Add method
        int Add(MinRealEstate_Class Mr);

        //Update Method
        int Update(MinRealEstate_Class Mr, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(MinRealEstate_Class Mr, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop);

        //DropDown REAL_ESTATE 
        void DisplayREAL_ESTATE(DropDownList drop);

    }
}
