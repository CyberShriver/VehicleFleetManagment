using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagment.FleetClass;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetImp
{
    public interface Driver_Interface
    {
        //Add method
        int Add(Driver_Class Dr);

        //Update Method
        int Update(Driver_Class Dr, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);
        //Display Method
        void Display(GridView gd);

        //Provide Method
        void provide(Driver_Class Dr, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

    }
}
