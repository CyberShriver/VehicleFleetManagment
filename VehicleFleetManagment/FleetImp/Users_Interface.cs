using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;

namespace VehicleFleetManagment.FleetImp
{
    public interface Users_Interface
    {
        //Add method
        int Add(Users_Class Us);

        //Update Method
        int Update(Users_Class Us, int id);

        //Delete Method
        int Delete(int id);

        //Display  AllMethod
        void DisplayAll(GridView gd);

        //Display Method
        void Display(GridView gd,string codeMin);

        //Login Connexion
        int Connexion(Users_Class Us, Ministry_Class Min, string userName, string password);

        //Provide Method
        void provide(Users_Class Us, int id);

        //Profile Methode
        void Profile(Users_Class Us, string userName);

        //count All
        int countAll();

        //count
        int count(string codeMin);

        //Research Method
        void ResearchAll(GridView gd, string SearchText);

        //Research Method
        void Research(GridView gd,string codeMin, string SearchText);

        //DropDown Ministry 
        void DisplayMinistry(DropDownList drop, string codeMin);

        //DropDown All Ministry 
        void DisplayMinistryAll(DropDownList drop);

        //UPDATE  STATE METHOD
        int UpdateState(int id);

        //Check if usernane is already used METHOD
        int CheckInputUser( string userName);


    }
}
