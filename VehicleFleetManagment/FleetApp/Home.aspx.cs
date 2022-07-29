using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class Home : System.Web.UI.Page
    {
        Leave_Interface Il = new Leave_Imp();
        Driver_Interface Id = new Driver_Imp();
        Vehicle_Interface Iv = new Vehicle_Imp();
        Crash_Interface Ic = new Crash_Imp();
        MinDriver_Interface IMd = new MinDriver_Imp();

        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
                driverNumber.Text = Id.countMinistryDrivers(codeMin).ToString();
                VehicleNumber.Text = Iv.count(codeMin).ToString();
                CrashNumber.Text = Ic.count(codeMin).ToString();
                ActiveLeave.Text = Il.countActive(codeMin).ToString();
                countDriverOnPost.Text = IMd.countOnPost(codeMin).ToString();
                countDrivLeave.Text= Il.countActive(codeMin).ToString();
                countVehAvail.Text = Iv.countAvailable(codeMin).ToString();
                countVehUnvail.Text = Iv.countUnavailable(codeMin).ToString();      
                countLeavePending.Text= Il.countPending(codeMin).ToString();
                countLeaveDueSoon.Text= Il.countDueSoon(codeMin).ToString();
              //  countLeaveSoonFinish.Text= Il.countFinishSoon(codeMin).ToString();
                Id.DriverDashboard(ListView1, codeMin);
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
            else
            {
                Response.Redirect("~/FleetApp/Login.aspx");
            }

        }
    }
}