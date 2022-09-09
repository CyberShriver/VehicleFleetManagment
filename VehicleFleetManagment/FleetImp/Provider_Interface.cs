using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Provider_Interface
    {
           //Add method
        int Add(Provider_Class Pr);

        //Update Method
        int Update(Provider_Class Pr, int id);

        //Delete Method
        int Delete(int id);

        //CHANGE DELETE STATE METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Provider_Class Pr, int id);

        //Provide CNI if user add CNI exist
        int ProvideByCNI(Provider_Class Pr, string cni);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

    }
}
