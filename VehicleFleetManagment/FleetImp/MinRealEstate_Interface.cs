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

        //CHANGE DELETE STATE METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd,string codeMin);

        //Display all Method
        void DisplayAll(GridView gd);
        //Provide Method
        void provide(MinRealEstate_Class Mr, int id);

        //count
        int count(string codeMin);

        //count all
        int countAll();

        //Research Method
        void Research(GridView gd, string codeMin,string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);
        //DropDown All Ministry 
        void DisplayMinistryAll(DropDownList drop);
        //DropDown  Ministry 
        void DisplayMinistry(DropDownList drop, string codeMin);
        //DropDown REAL_ESTATE 
        void DisplayREAL_ESTATE(DropDownList drop);

    }
}
