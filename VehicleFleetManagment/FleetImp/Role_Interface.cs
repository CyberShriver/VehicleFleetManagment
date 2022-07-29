using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    interface Role_Interface
    {

          //Add method
         int Add( Role_Class Ro);

        //Update Method
         int Update( Role_Class Ro, int id);

        //Delete Method
         int Delete(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
         void provide( Role_Class Ro, int id);

        //count
        int count();

        //Research Method
         void Research(GridView gd, string SearchText);

        //DROPDOWN ROLE
        void DropdownRole(DropDownList drop);

        // DISPLAY ROLE NAME FOR MINISTRY TABLE
        void DropdownRoleName(DropDownList drop);

    }
}
