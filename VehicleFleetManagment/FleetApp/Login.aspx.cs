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
        Users_Class Us = new Users_Class();

        Ministry_Interface I = new Ministry_Imp();
        Users_Interface Iu = new Users_Imp();
        private int msg;

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
            AdmMsg.Visible = false;

        }
        protected void connect()
        {
            if (txtUserName.Value == "" || txtPassWord.Value == "")
            {
                FailMsg.Visible = true;
                SuccessMsg.Visible = false;
                AdmMsg.Visible = false;

            }
            else
            {
                msg = Iu.Connexion(Us,Min, txtUserName.Value, txtPassWord.Value);

                if (msg == 1)
                {
                    if (CheckRemember.Checked)
                    {
                        Response.Cookies["User_Nme"].Value = Us.User_Nme;
                        Response.Cookies["Password"].Value = Us.Password;
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

                    MINISTRY_ID.Value = Min.MINISTRY_ID.ToString().Trim();
                    MINISTRY_ID.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(MINISTRY_ID);

                    System_Email.Value = Min.System_Email.ToString().Trim();
                    System_Email.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(System_Email);

                    PictMin.Value = Min.Picture.ToString().Trim();
                    PictMin.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(PictMin);

                    Slogan.Value = Min.Slogan.ToString().Trim();
                    Slogan.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Slogan);

                    theme.Value = Min.Theme.ToString().Trim();
                    theme.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(theme);

                    Postal_code.Value = Min.Postal_code.ToString().Trim();
                    Postal_code.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Postal_code);

                    Fax.Value = Min.Fax.ToString().Trim();
                    Fax.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Fax);


                    User_Nme.Value = Us.User_Nme.ToString().Trim();
                    User_Nme.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(User_Nme);

                    Phone.Value = Us.Phone.ToString().Trim();
                    Phone.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Phone);

                    Address.Value = Us.Address.ToString().Trim();
                    Address.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Address);

                    Password.Value = Us.Password.ToString().Trim();
                    Password.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(Password);

                    PictureUser.Value = Us.Picture.ToString().Trim();
                    PictureUser.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(PictureUser);

                    mail.Value = Us.Email.ToString().Trim();
                    mail.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(mail);

                    FirstName.Value = Us.First_Name.ToString().Trim();
                    FirstName.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(FirstName);

                    LastName.Value = Us.Last_Name.ToString().Trim();
                    LastName.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(LastName);

                    UserCode.Value = Us.User_Code.ToString().Trim();
                    UserCode.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(UserCode);

                    birth.Value = Us.DOB.ToString().Trim();
                    birth.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(birth);

                    rol.Value = Us.ROLE_ID.ToString().Trim();
                    rol.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(rol);

                    if(Us.State == "ON")
                    {
                        if (Code_Min.Value != null)
                        {
                            Response.Redirect("~/FleetApp/Home.aspx");
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FailMsg.Visible = true;
                            AdmMsg.Visible = false;
                        }
                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FailMsg.Visible = false;
                        AdmMsg.Visible = true;
                    }
                                     
                }
                else{
                    SuccessMsg.Visible = false;
                    FailMsg.Visible = true;
                    AdmMsg.Visible = false;
                }

            }

        }

        protected void btn_connexion_ServerClick(object sender, EventArgs args)
        {
            connect();
        }
    }
}