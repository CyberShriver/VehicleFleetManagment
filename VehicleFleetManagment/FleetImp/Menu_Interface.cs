using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Menu_Interface
    {

        //Add method
        int Add(Menu_Class Me);

        //Update Method
        int Update(Menu_Class Me, int id);

        //Delete Method
        int Delete(int id);

        //DELETE STATE METHOD
        int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //DISPLAY DETAILS METHOD OF ROLE
         void DisplayDetails(string menu, Menu_Class Me);

        //Provide Method
        void provide(Menu_Class Me, int id);

        //count
        int count();

        //Research Method
        void Research(GridView gd, string SearchText);

    }
}
