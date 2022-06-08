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
    public partial class fleet : System.Web.UI.MasterPage
    {
        Ministry_Class Min = new Ministry_Class();
        Ministry_Interface I = new Ministry_Imp();

        Leave_Interface Il = new Leave_Imp();
        MinDriver_Interface IMd = new MinDriver_Imp();

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
            ChargeCookies();
            Il.AutoSwitch();
            Il.UpdateStateFinished();
            Il.UpdateAutoStateDenied();
            IMd.AutoSwap();

            if (codeMin == "All")
            {
                MinistryTable.Visible = true;
            }
            else
            {
                MinistryTable.Visible = false;
            }
            
        }

        //Charge Cookies
        void ChargeCookies()
        {
           

            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Ministry_Name"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null || Request.Cookies["Logo"] != null || Request.Cookies["System_Name"] != null || Request.Cookies["Picture"] != null || Request.Cookies["Theme"] != null)
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
            else
            {
                Response.Redirect("~/FleetApp/Login.aspx");
            }

            txtProfileName.Text = name;
            txtSideProfile.Text = name;
            HeaderProfile.ImageUrl = "~/FleetApp/assets/images/Users/" + pic;
            SideProfile.ImageUrl = "~/FleetApp/assets/images/Users/" + pic;
            LogoPic.ImageUrl = "~/FleetApp/assets/images/Logo/" + logo;
        }

        //protected void UpdateCookies()
        //{
            
        //    Code_Min.Value = Min.Code_Min.ToString().Trim();
        //    Code_Min.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(Code_Min);

        //    Ministry_Name.Value = Min.Ministry_Name.ToString().Trim();
        //    Ministry_Name.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(Ministry_Name);

        //    System_Name.Value = Min.System_Name.ToString().Trim();
        //    System_Name.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(System_Name);

        //    System_Title.Value = Min.System_Title.ToString().Trim();
        //    System_Title.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(System_Title);

        //    Logo.Value = Min.Logo.ToString().Trim();
        //    Logo.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(Logo);

        //    User_Nme.Value = Min.User_Nme.ToString().Trim();
        //    User_Nme.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(User_Nme);

        //    MINISTRY_ID.Value = Min.MINISTRY_ID.ToString().Trim();
        //    MINISTRY_ID.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(MINISTRY_ID);

        //    System_Email.Value = Min.System_Email.ToString().Trim();
        //    System_Email.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(System_Email);

        //    Picture.Value = Min.Picture.ToString().Trim();
        //    Picture.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(Picture);

        //    Slogan.Value = Min.Slogan.ToString().Trim();
        //    Slogan.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(Slogan);

        //    Theme.Value = Min.Theme.ToString().Trim();
        //    Theme.Expires.Add(new TimeSpan(1, 0, 0));
        //    Response.Cookies.Add(Theme);

        //}

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