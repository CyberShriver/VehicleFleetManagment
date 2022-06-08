using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Leave_Interface
    {


        //Add method
        int Add(Leave_Class Le);

        //Update Method
        int Update(Leave_Class Le, int id);

        //Delete Method
        int Delete(int id);

        //Delete Method
        int DeleteCheck(GridView gd, CheckBox chk, int id);

        //Display Method
        void Display(GridView gd,string codeMin);

        //Display ALL Method
        void DisplayAll(GridView gd);

        //Provide Method
        void provide(Leave_Class Le, int id);

        //count
        int count(string codeMin);

        //count All
        int countAll();


        //Research Method
        void Research(GridView gd,string codeMin, string SearchText);

        //Research All Method
        void ResearchAll(GridView gd, string SearchText);

        //DropDown All Vehicle 
        void DisplayAllDriver(DropDownList drop);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop,string codeMin);

        //DropDown All Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //DropDown Vehicle 
        void DisplayDriver(DropDownList drop, int id);

        //DropDown Vehicle 
        void DisplayLeaveType(DropDownList drop);

        //UPDATE Position
        long UpdatePositionState(long id);

        //UPDATE STATE WHEN ITS APPROVED
        int UpdateStateApproved(long id, string approvBy);

        //UPDATE STATE WHEN ITS DENY   
         int UpdateStateDeny(long id);

        //AUTO CHANGE PENDING WHEN START DATE IS OVERAL
        int UpdateAutoStateDenied();

        //AUTO UPDATE FINISH  STATE METHOD WHEN LEAVE OVER
        int UpdateStateFinished();

        //AUTO SWITCH  THE STATE AND POSITION WHEN APPROVED AND START LEAVE
        void AutoSwitch();
    }
}
