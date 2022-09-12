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
    public partial class AllMinistries: System.Web.UI.Page
    {
        Vehicle_Interface Iv = new Vehicle_Imp();
        Crash_Interface Ic = new Crash_Imp();
        MinRealEstate_Interface Ir = new MinRealEstate_Imp();
        Ministry_Interface IM = new Ministry_Imp();

        string codeMin,ministry, sytemTitle, slogan;       
        public string LeaveAnalys, CrashAnalyse, LeaveStatistic, CrashStatistic;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();           
            if (!IsPostBack)
            {
                MinistryView();               
                ministry = DropDown_Ministry.SelectedValue;
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
                GetDataRealEstate();
                GetDataVehicle();

                DashBoard();


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

        void GetDataRealEstate()
        {
            Ir.Display(GridViewReal, ministry);
        }

        void GetDataVehicle()
        {
            Iv.Display(gdv, ministry);
        }


        void MinistryView()
        {
            IM.DisplayMinistryAll(DropDown_Ministry);
        }

        void DashBoard()
        {
            VehicleNumber.Text = Iv.count(ministry).ToString();
            CrashNumber.Text = Ic.count(ministry).ToString();
            RealEstateNumber.Text = Ir.count(ministry).ToString();
            this.CrashAnalyse = Ic.DisplayJson(ministry);
            Iv.Display(gdv, ministry);
            Ir.Display(GridViewReal, ministry);
        }
        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ministry = DropDown_Ministry.SelectedValue;
            DashBoard();
            GetDataVehicle();
            GetDataRealEstate();
        }

        protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdv.PageIndex = e.NewPageIndex;
            this.GetDataVehicle();

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
        }

        protected void gdv_PageIndexChangingRealEstate(object sender, GridViewPageEventArgs e)
        {
            GridViewReal.PageIndex = e.NewPageIndex;
            this.GetDataRealEstate();

        }

        protected void gdv_PreRenderRealEstate(object sender, EventArgs e)
        {
            indexFooterReal.Text = "Page " + (GridViewReal.PageIndex + 1).ToString() + " of " + GridViewReal.PageCount.ToString();
        }

    }
}