using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagment.FleetClass;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetImp
{
   public interface Grant_Interface
    {
        //ADD METHOD
        int Add(Grant_Class Gr);

        //UPDATE METHOD
        int UPDATE(int code, long menu, int IdMin, Grant_Class Gr);

        //DELETE METHOD
         int DELETE(int id);

        //DISPLAY METHOD
         void Display(GridView gd);

        //DISPLAY DETAILS METHOD OF ROLE
        void DisplayDetails(int code, Grant_Class Gr);

        //DISPLAY DETAILS METHOD  OF FULL ROLE AND MENU
        void DisplayDetails(int code, long menu,int IdMin, Grant_Class Gr);

        //DISPLAY ROLE IN DROPDOWN
        void ChargeGrant(DropDownList ddw, int code);

        //COUNT ALL PERMISSION(GRANT)
        int count();

        //CHECK IF PERMISSION(GRANT) ALREADY GRANTED
        int count(int role, string menu, int idMin);

        //REASEARCH METHOD
         void Research(GridView gd, string SearchText);

        //DISPLAY   Role Of Ministry Selected
         void DisplayMinistryRole(DropDownList drop, int idMin);
    }
}
