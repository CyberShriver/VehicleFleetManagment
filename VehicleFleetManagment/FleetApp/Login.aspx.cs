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
    public partial class Login : System.Web.UI.Page
    {
        
        Ministry_Class Min = new Ministry_Class();
        Ministry_Interface I = new Ministry_Imp();
        private int msg;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initial_msg();
                if (Request.Cookies["User_Nme"] != null && Request.Cookies["Password"] != null )
                {
                    txtUserName.Value = Request.Cookies["User_Nme"].Value;
                    txtPassWord.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }
        private void initial_msg()
        {
            FailMsg.Visible = false;
            SuccessMsg.Visible = false;

        }
        protected void connect()
        {
            if (txtUserName.Value == "" || txtPassWord.Value == "")
            {
                FailMsg.Visible = true;
                SuccessMsg.Visible = false;

            }
            else
            {
                msg = I.Connexion(Min, txtUserName.Value, txtPassWord.Value);

                if (msg == 1)
                {
                    if (CheckRemember.Checked)
                    {
                        Response.Cookies["User_Nme"].Value = Min.User_Nme;
                        Response.Cookies["Password"].Value = Min.Password;
                        Response.Cookies["User_Nme"].Expires = DateTime.Now.AddMinutes(5);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        Response.Cookies["User_Nme"].Expires = DateTime.Now.AddMinutes(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);
                    }


                    Code_Min.Value = Min.Code_Min.ToString().Trim();
                    Code_Min.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Code_Min);

                    Ministry_Name.Value = Min.Ministry_Name.ToString().Trim();
                    Ministry_Name.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Ministry_Name);

                    System_Name.Value = Min.System_Name.ToString().Trim();
                    System_Name.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(System_Name);

                    System_Title.Value = Min.System_Title.ToString().Trim();
                    System_Title.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(System_Title);

                    Logo.Value = Min.Logo.ToString().Trim();
                    Logo.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Logo);

                    User_Nme.Value = Min.User_Nme.ToString().Trim();
                    User_Nme.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(User_Nme);

                    MINISTRY_ID.Value = Min.MINISTRY_ID.ToString().Trim();
                    MINISTRY_ID.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(MINISTRY_ID);

                    System_Email.Value = Min.System_Email.ToString().Trim();
                    System_Email.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(System_Email);

                    Picture.Value = Min.Picture.ToString().Trim();
                    Picture.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Picture);

                    Slogan.Value = Min.Slogan.ToString().Trim();
                    Slogan.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Slogan);

                    Theme.Value = Min.Theme.ToString().Trim();
                    Theme.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Theme);

                    if (Code_Min.Value != null)
                    {
                    Response.Redirect("~/FleetApp/ViewMinistryDriver.aspx");
                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FailMsg.Visible = true;
                    }                    
                }
                else{
                    SuccessMsg.Visible = false;
                    FailMsg.Visible = true; 
                }

            }

        }

        protected void btn_connexion_ServerClick(object sender, EventArgs args)
        {
            connect();
        }
    }
}