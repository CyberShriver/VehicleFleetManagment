using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagment.FleetClass;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetImp
{
    public interface Model_Interface
    {
        //Add method
        int Add(Model_Class Mo);

        //Update Method
        int Update(Model_Class Mo, int id);

        //Delete Method
        int Delete(int id);

        //CHANGE DELETE STATE METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Model_Class Mo, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

        //DropDown Mark 
        void DisplayMark(DropDownList drop);


    }
}
