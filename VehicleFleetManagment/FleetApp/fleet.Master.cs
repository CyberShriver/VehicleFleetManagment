using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetApp
{
    public partial class fleet : System.Web.UI.MasterPage
    {
        string codeMin;
        string name;
        string sytemTitle;
        string logo;
        string systemName;
        string pic;
        string slogan;
        string theme;

        protected void Page_Load(object sender, EventArgs e)
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

            if (Request.Cookies["Code_Min"].Value != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
                name = Request.Cookies["Ministry_Name"].Value;
                sytemTitle = Request.Cookies["System_Title"].Value;
                logo = Request.Cookies["Logo"].Value;
                systemName = Request.Cookies["System_Name"].Value;
                pic = Request.Cookies["Picture"].Value;
                slogan = Request.Cookies["Slogan"].Value;
                theme = Request.Cookies["Theme"].Value;
            }
            txtProfileName.Text = name;
            txtSideProfile.Text = name;
            HeaderProfile.ImageUrl = "~/FleetApp/assets/images/" + pic;
            SideProfile.ImageUrl = "~/FleetApp/assets/images/" + pic;
            LogoPic.ImageUrl = "~/FleetApp/assets/images/" + logo;
        }


        protected void LogoutLink(object sender, EventArgs args)
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");
            Code_Min.Expires = DateTime.Now.AddMilliseconds(-10);
            Response.Cookies.Add(Code_Min);
            Response.Redirect("~/FleetApp/Login.aspx");
        }

        protected void SideLogout_ServerClick(object sender, EventArgs e)
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");
            Code_Min.Expires = DateTime.Now.AddMilliseconds(-10);
            Response.Cookies.Add(Code_Min);
            Response.Redirect("~/FleetApp/Login.aspx");
        }
    }
}