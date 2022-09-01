using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment
{
    public partial class liveDataCrash : System.Web.UI.Page
    {
        public string CrashAnalys;
        string codeMin, sytemTitle, slogan;

        Crash_Interface I = new Crash_Imp();
        protected void Page_Load(object sender, EventArgs e)
        {
                ChargeCookies();
            if (!IsPostBack)
            {
                CrashAnalys = I.DisplayJson(codeMin);
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