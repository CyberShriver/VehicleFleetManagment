using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Mark_Interface
    {

        //Add method
         int Add(Mark_Class Ma);

        //Update Method
         int Update(Mark_Class Ma, int id);

        //Delete Method
         int Delete(int id);

        //DELETE STATE METHOD
        int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
         void provide(Mark_Class Ma, int id);

        //count
        int count();

        //Research Method
         void Research(GridView gd, string SearchText);

    }
}
