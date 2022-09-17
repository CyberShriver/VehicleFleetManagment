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

        //CHANGE DELETE STATE METHOD
         int DeleteState(int id);

        //Display Method
        void Display(GridView gd);

        //Display All Method
        void DisplayAll(GridView gd);

        //DISPLAY Driver for specific Ministry METHOD
        void DisplayMinistryDriver(GridView gd, string codeMin);

        //Provide Method
        void provide(Driver_Class Dr, int id);

        //count
        int count();

        //COUNT Ministry drivers METHOD
        int countMinistryDrivers(string codeMin);

        //count All
        int countAll();

        //Research Method
        void Research(GridView gd, string codeMin, string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop, string codeMin);

        //DropDown All Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //UPDATE MINISTRY WORK STATE METHOD TO EMPTY
        int UpdateMinistryWorkStateEmpty( int id);

        //DISPLAY METHOD Where CNI
        int ProvideByCNI(Driver_Class Dr, string cni);

        // DISPLAY Dashboard List Driver
         void DriverDashboard(ListView listProgress, string codeMin);




    }
}
