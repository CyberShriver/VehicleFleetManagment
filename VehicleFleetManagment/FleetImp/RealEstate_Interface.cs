using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
   public interface RealEstate_Interface
    {

        //Add method
        int Add(RealEstate_Class Re);

        //Update Method
        int Update(RealEstate_Class Re, int id);

        //Delete Method
        int Delete(int id);

        //CHANGE DELETE STATE METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(RealEstate_Class Re, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);


    }
}
