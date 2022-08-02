using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class LeaveDonutChart : System.Web.UI.Page
    {
        Leave_Interface I = new Leave_Imp();

        private int msg;
        string codeMin;
        string sytemTitle;
        string slogan;
        public string obj;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            if (!IsPostBack)
            {
                 this.obj=I.DisplayJson(codeMin);
            }
        }
    void ChargeCookies()
    {
        if (Request.Cookies["Code_Min"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
        {
            codeMin = Request.Cookies["Code_Min"].Value;
            sytemTitle = Request.Cookies["System_Title"].Value;
            slogan = Request.Cookies["Slogan"].Value;
        }

    }

    }

}