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

        //Modify Method
         int Modify(Mark_Class Ma, int id);

        //Delete Method
         int Delete(int id);

        //Display Method
         void Display(GridView gd);

        //Provide Method
         void provide(Mark_Class Ma, int id);

        //Research Method
         void Research(GridView gd, string SearchText);

    }
}
