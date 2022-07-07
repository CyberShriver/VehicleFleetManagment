using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagment.FleetClass;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetImp
{
    public interface LeaveType_Interface
    {
        //Add method
        int Add(LeaveType_Class Le);

        //Update Method
        int Update(LeaveType_Class Le, int id);

        //Delete Method
        int Delete(int id);

        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(LeaveType_Class Le, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

    }
}
