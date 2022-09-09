using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
   public interface BodyType_Interface
    {

        //Add method
        int Add(BodyType_Class Bo);

        //Update Method
        int Update(BodyType_Class Bo, int id);

        //Delete Method
        int Delete(int id);

        //Change Delete state METHOD
        int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(BodyType_Class Bo, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

    }
}
