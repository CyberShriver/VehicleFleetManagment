using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class ViewCarCrash : System.Web.UI.Page
    {
        CarCrash_Class Car = new CarCrash_Class();
        Crash_Interface I = new Crash_Imp();
        private int msg;
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
                getDataGDV();

            }
        }

        void ChargeCookies()
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");
            HttpCookie MINISTRY_ID = new HttpCookie("MINISTRY_ID");
            HttpCookie Phone = new HttpCookie("Phone");
            HttpCookie Ministry_Name = new HttpCookie("Ministry_Name");
            HttpCookie Address = new HttpCookie("Address");
            HttpCookie Postal_code = new HttpCookie("Postal_code");
            HttpCookie User_Nme = new HttpCookie("User_Nme");
            HttpCookie Fax = new HttpCookie("Fax");
            HttpCookie System_Name = new HttpCookie("System_Name");
            HttpCookie System_Title = new HttpCookie("System_Title");
            HttpCookie System_Email = new HttpCookie("System_Email");
            HttpCookie Password = new HttpCookie("Password");
            HttpCookie Logo = new HttpCookie("Logo");
            HttpCookie Picture = new HttpCookie("Picture");
            HttpCookie Slogan = new HttpCookie("Slogan");
            HttpCookie Theme = new HttpCookie("Theme");

            if (Request.Cookies["Code_Min"].Value != null)
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
        public void getDataGDV()
        {
            if (codeMin == "All")
            {
                I.DisplayAll(gdv);
                nbr.Text = I.countAll().ToString();
            }
            else
            {
                I.Display(gdv, codeMin);
                nbr.Text = I.count(codeMin).ToString();
            }

        }

        protected void btn_srch_Click(object sender, EventArgs e)
        {
            if (codeMin == "All")
            {
                if (txt_Search.Value == "")
                    getDataGDV();
                else I.ResearchAll(gdv, txt_Search.Value);
            }
            else
            {
                if (txt_Search.Value == "")
                    getDataGDV();
                else I.Research(gdv, codeMin, txt_Search.Value);
            }
        }
        protected void btnReload_click(object sender, EventArgs e)
        {
            getDataGDV();
            txt_Search.Value = "";
        }

        protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/FleetApp/AddCarCrash.aspx?CAR_CRASH_ID=" + index);

            }
            if (e.CommandName == "delet")
            {
                I.Delete(index);
                Response.Redirect("~/FleetApp/ViewCarCrash.aspx");


            }


        }

        protected void DeleteCheck_Click(object sender, EventArgs e)
        {

        }

        protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdv.PageIndex = e.NewPageIndex;
            this.getDataGDV();

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
        }
    }
}