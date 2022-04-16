using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
   public interface Ministry_Interface
    {

        //Add method
        int Add(Ministry_Class Min);

        //Update Method
        int Update(Ministry_Class Min, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Ministry_Class Min, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);
    }
}
