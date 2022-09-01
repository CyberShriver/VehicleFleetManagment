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

        Crash_Interface Icrash = new Crash_Imp();

        Grant_Class Gr = new Grant_Class();
        Grant_Interface IG = new Grant_Imp();

        static int id, n, userId, role;

        HttpCookie Code_Min = new HttpCookie("Code_Min");
        HttpCookie MINISTRY_ID = new HttpCookie("MINISTRY_ID");
        HttpCookie Ministry_Name = new HttpCookie("Ministry_Name");
        HttpCookie Postal_code = new HttpCookie("Postal_code");
        HttpCookie Fax = new HttpCookie("Fax");
        HttpCookie System_Name = new HttpCookie("System_Name");
        HttpCookie System_Title = new HttpCookie("System_Title");
        HttpCookie System_Email = new HttpCookie("System_Email");
        HttpCookie Logo = new HttpCookie("Logo");
        HttpCookie Slogan = new HttpCookie("Slogan");
        HttpCookie theme = new HttpCookie("Theme");
        HttpCookie PictMin = new HttpCookie("Picture");

        HttpCookie Phone = new HttpCookie("Phone");
        HttpCookie IdUser = new HttpCookie("USERS_ID");
        HttpCookie Address = new HttpCookie("Address");
        HttpCookie User_Nme = new HttpCookie("User_Nme");
        HttpCookie Password = new HttpCookie("Password");
        HttpCookie PictureUser = new HttpCookie("Picture");
        HttpCookie mail = new HttpCookie("Email");
        HttpCookie FirstName = new HttpCookie("First_Name");
        HttpCookie LastName = new HttpCookie("Last_Name");
        HttpCookie UserCode = new HttpCookie("User_Code");
        HttpCookie birth = new HttpCookie("DOB");
        HttpCookie rol = new HttpCookie("ROLE_ID");

        string codeMin, MinistryName, sytemTitle, MinistryMail,fax,postal, IdMin, logo, systemName, picUser, slogan, them,email,picMin,firstname,lastname,address,phon,usercod,Dob;
        public string LeaveAnalys;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            Il.AutoSwitch();
            Il.UpdateStateFinished();
            Il.UpdateAutoStateDenied(codeMin);
            IMd.AutoSwap();
            ActiveNumber.Text = Il.countNotification(codeMin).ToString();

            Il.LeaveNotification(ListView1, codeMin);
            this.LeaveAnalys = Il.DisplayJson(codeMin);
            
           
        }

        //Charge Cookies
        void ChargeCookies()
        {
           

            if (Request.Cookies["Code_Min"] != null && Request.Cookies["Ministry_Name"] != null && Request.Cookies["Slogan"] != null &&
                Request.Cookies["System_Title"] != null && Request.Cookies["Logo"] != null && Request.Cookies["System_Name"] != null &&
                Request.Cookies["Picture"] != null && Request.Cookies["Theme"] != null && Request.Cookies["MINISTRY_ID"] != null &&
                Request.Cookies["Fax"] != null && Request.Cookies["Postal_code"] != null && Request.Cookies["System_Email"] != null &&
                Request.Cookies["Phone"] != null && Request.Cookies["Address"] != null && Request.Cookies["Picture"] != null &&
                Request.Cookies["Email"] != null && Request.Cookies["First_Name"] != null && Request.Cookies["Last_Name"] != null &&
                Request.Cookies["DOB"] != null && Request.Cookies["ROLE_ID"] != null && Request.Cookies["USERS_ID"] != null)
            {       

                codeMin = Request.Cookies["Code_Min"].Value;
                MinistryMail = Request.Cookies["System_Email"].Value;
                MinistryName = Request.Cookies["Ministry_Name"].Value;
                sytemTitle = Request.Cookies["System_Title"].Value;
                logo = Request.Cookies["Logo"].Value;
                systemName = Request.Cookies["System_Name"].Value;
                picMin = Request.Cookies["Picture"].Value;
                slogan = Request.Cookies["Slogan"].Value;
                them = Request.Cookies["Theme"].Value;
                IdMin = Request.Cookies["MINISTRY_ID"].Value;
                fax = Request.Cookies["Fax"].Value;
                postal = Request.Cookies["Postal_code"].Value;

                phon = Request.Cookies["Phone"].Value;
                address = Request.Cookies["Address"].Value;
                picUser = Request.Cookies["Picture"].Value;
                email = Request.Cookies["Email"].Value;
                firstname = Request.Cookies["First_Name"].Value;
                lastname = Request.Cookies["Last_Name"].Value;
                usercod = Request.Cookies["User_Code"].Value;
                Dob = Request.Cookies["DOB"].Value;
                userId = Convert.ToInt32(IdUser.Value);
                role= Convert.ToInt32(rol.Value);
            }
            else
            {
                Response.Redirect("~/FleetApp/Login.aspx");
            }

            txtProfileName.Text = lastname+ " " + firstname;
            txtSideProfile.Text = lastname + " " + firstname;
            HeaderProfile.ImageUrl = "~/FleetApp/assets/images/Users/" + picUser;
            SideProfile.ImageUrl = "~/FleetApp/assets/images/Users/" + picUser;
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

        public bool MenuDisplay(string menuValue)
        {
            HttpCookie MINISTRY_ID = Request.Cookies["MINISTRY_ID"];
            HttpCookie rol = Request.Cookies["ROLE_ID"];

            bool rep = false;
            if ( Request.Cookies["MINISTRY_ID"] != null && Request.Cookies["ROLE_ID"] != null)
            {
                id = Convert.ToInt32(MINISTRY_ID.Value);
                role = Convert.ToInt32(rol.Value);
                userId = Convert.ToInt32(IdUser.Value);

                try
                {
                    n = Convert.ToInt32(IG.count(role, menuValue, id));
                    if (n > 0)
                        rep = true;
                    else
                        rep = false;


                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }


            }
            return rep;
        }
    }
}