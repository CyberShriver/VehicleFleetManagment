using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetImp;
using Newtonsoft.Json;

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
        public string LeaveAnalys, CrashAnalys, LeaveStatistic, CrashStatistic;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            if (!IsPostBack)
            {
                MultiView.ActiveViewIndex = 0;
                MultiView1.ActiveViewIndex = 0;
                FetchStatistcGridView();
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
                countLeaveSoonFinish.Text= Il.countFinishSoon(codeMin).ToString();
                Id.DriverDashboard(ListView1, codeMin);

                this.CrashAnalys = Ic.DisplayJson(codeMin);



            }

}       
        //void donult()
        //{
        //    if (CrashAnalys == "" && LeaveAnalys=="")
        //    {
        //        MultiView.ActiveViewIndex = 1;
        //        MultiView1.ActiveViewIndex = 1;
        //    }else if(CrashAnalys == "")
        //    {
        //        MultiView.ActiveViewIndex = 1;
        //    }
        //    else
        //    {
        //        MultiView.ActiveViewIndex = 1;
        //    }
        //}

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

        void FetchStatistcGridView()
        {
            // For Leave
            LeaveStatistic = Il.DisplayJson(codeMin);
            var countSat = JsonConvert.DeserializeObject(LeaveStatistic);
            gdv.DataSource = countSat;
            gdv.DataBind();
            totalFinishedLeave.Text = Il.countFinishedLeave(codeMin).ToString();

            //For crash
            CrashStatistic = Ic.DisplayJson(codeMin);
            var countCrash = JsonConvert.DeserializeObject(CrashStatistic);
            gdvCrash.DataSource = countCrash;
            gdvCrash.DataBind();
            TotalNumberCrash.Text = Ic.count(codeMin).ToString();


        }

        protected void ActiveAnalys_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 0;
            this.CrashAnalys = Ic.DisplayJson(codeMin);

            tabStat.Attributes.Remove("class");
            tabStat.Attributes.Add("class", "nav-link");

            tabAnalysis.Attributes.Remove("class");
            tabAnalysis.Attributes.Add("class", "nav-link active");

        }
        protected void ActiveStat_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 1;
            this.CrashAnalys = Ic.DisplayJson(codeMin);

            tabStat.Attributes.Remove("class");
            tabStat.Attributes.Add("class", "nav-link active");

            tabAnalysis.Attributes.Remove("class");
            tabAnalysis.Attributes.Add("class", "nav-link");

        }

        protected void ActiveCrashAnalys_click(object sender, EventArgs args)
        {
            MultiView1.ActiveViewIndex = 0;
            this.CrashAnalys = Ic.DisplayJson(codeMin);

            tabCrashStat.Attributes.Remove("class");
            tabCrashStat.Attributes.Add("class", "nav-link");

            tabCrashAnaly.Attributes.Remove("class");
            tabCrashAnaly.Attributes.Add("class", "nav-link active");

        }
        protected void ActiveCrashStat_click(object sender, EventArgs args)
        {
            MultiView1.ActiveViewIndex = 1;
            this.CrashAnalys = Ic.DisplayJson(codeMin);

            tabCrashStat.Attributes.Remove("class");
            tabCrashStat.Attributes.Add("class", "nav-link active");

            tabCrashAnaly.Attributes.Remove("class");
            tabCrashAnaly.Attributes.Add("class", "nav-link");

        }

    }
}