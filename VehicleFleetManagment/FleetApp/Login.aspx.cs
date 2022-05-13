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

        HttpCookie MINISTRY_ID = new HttpCookie("MINISTRY_ID");
        HttpCookie Code_Min = new HttpCookie("Code_Min");
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