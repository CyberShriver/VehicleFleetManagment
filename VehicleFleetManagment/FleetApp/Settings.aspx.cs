using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;
using System.IO;

namespace VehicleFleetManagment.FleetApp
{
    public partial class Settings : System.Web.UI.Page
    {
        Ministry_Class Min = new Ministry_Class();
        Ministry_Interface I = new Ministry_Imp();
        private int msg;
        string codeMin;
        int id;
        string name;
        string systemTitle;
        string logo;
        string systemName;
        string systemMail;
        string pic;
        string slogan;
        string them;

      
        protected void Page_Load(object sender, EventArgs e)
        {
            //UpdateCookies();
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
            HttpCookie theme = new HttpCookie("Theme");

            if (Request.Cookies["Code_Min"].Value != null)
            {
                id = Convert.ToInt32(Request.Cookies["MINISTRY_ID"].Value);
                codeMin = Request.Cookies["Code_Min"].Value;
                name = Request.Cookies["Ministry_Name"].Value;
                systemTitle = Request.Cookies["System_Title"].Value;
                logo = Request.Cookies["Logo"].Value;
                systemName = Request.Cookies["System_Name"].Value;
                systemMail = Request.Cookies["System_Email"].Value;
                pic = Request.Cookies["Picture"].Value;
                slogan = Request.Cookies["Slogan"].Value;
                them = Request.Cookies["Theme"].Value;
            }

            if (!IsPostBack)
            {
                MsgInit();
                ChargeData();
            }
        }
        //protected void UpdateCookies()
        //{
        //    HttpCookie Code_Min = new HttpCookie("Code_Min");
        //    HttpCookie MINISTRY_ID = new HttpCookie("MINISTRY_ID");
        //    HttpCookie Phone = new HttpCookie("Phone");
        //    HttpCookie Ministry_Name = new HttpCookie("Ministry_Name");
        //    HttpCookie Address = new HttpCookie("Address");
        //    HttpCookie Postal_code = new HttpCookie("Postal_code");
        //    HttpCookie User_Nme = new HttpCookie("User_Nme");
        //    HttpCookie Fax = new HttpCookie("Fax");
        //    HttpCookie System_Name = new HttpCookie("System_Name");
        //    HttpCookie System_Title = new HttpCookie("System_Title");
        //    HttpCookie System_Email = new HttpCookie("System_Email");
        //    HttpCookie Password = new HttpCookie("Password");
        //    HttpCookie Logo = new HttpCookie("Logo");
        //    HttpCookie Picture = new HttpCookie("Picture");
        //    HttpCookie Slogan = new HttpCookie("Slogan");
        //    HttpCookie theme = new HttpCookie("Theme");

        //    Code_Min.Value = Min.Code_Min.ToString().Trim();
        //            Code_Min.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(Code_Min);

        //            Ministry_Name.Value = Min.Ministry_Name.ToString().Trim();
        //            Ministry_Name.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(Ministry_Name);

        //            System_Name.Value = Min.System_Name.ToString().Trim();
        //            System_Name.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(System_Name);

        //            System_Title.Value = Min.System_Title.ToString().Trim();
        //            System_Title.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(System_Title);

        //            Logo.Value = Min.Logo.ToString().Trim();
        //            Logo.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(Logo);

        //            User_Nme.Value = Min.User_Nme.ToString().Trim();
        //            User_Nme.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(User_Nme);

        //            MINISTRY_ID.Value = Min.MINISTRY_ID.ToString().Trim();
        //            MINISTRY_ID.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(MINISTRY_ID);

        //            System_Email.Value = Min.System_Email.ToString().Trim();
        //            System_Email.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(System_Email);

        //            Picture.Value = Min.Picture.ToString().Trim();
        //            Picture.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(Picture);

        //            Slogan.Value = Min.Slogan.ToString().Trim();
        //            Slogan.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(Slogan);

        //            theme.Value = Min.Theme.ToString().Trim();
        //            theme.Expires.Add(new TimeSpan(1, 0, 0));
        //            Response.Cookies.Add(theme);

        //}
        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
        }
        protected void ChargeData()
        {
            if (codeMin != null)
            {
                I.Profile(Min, codeMin);

                txtCode.Text = Min.Code_Min;
                txtName.Text = Min.Ministry_Name;
                txtAddress.Text = Min.Address;
                txtTel.Text = Min.Phone;
                txtFax.Text = Min.Fax;
                txtPostal.Text = Min.Postal_code;
                txtUserName.Text = Min.User_Nme;
                Image1.ImageUrl = "~/FleetApp/assets/images/" + Min.Picture;
            }
        }

        protected void settings()
        {
            txtSysName.Value = systemName;
            txtSysTitle.Value = systemTitle;
            txtSysMaile.Value =systemMail ;
            txtSlogan.Value = slogan;
            txtTheme.Value = them;
            
        }

        //update
        void Update()
        {

            try
            {
                if ( txtSysTitle.Value == "" && txtSysName.Value == "" && txtSysMaile.Value == "" && txtTheme.Value == "" && txtSlogan.Value == "")
                {                   
                    Min.System_Name =systemName;
                    Min.System_Title = systemTitle;
                    Min.System_Email = systemMail;
                    Min.Logo = logo;
                    Min.Theme = them;
                    Min.Slogan =slogan;

                    SuccessMsg.Visible = true;
                    FillMsg.Visible = false;
                    FailMsg.Visible = false;
                }
                else
                {
                    if ( file_updLogo.HasFile)
                    {
                        file_updLogo.SaveAs(Server.MapPath("~/FleetApp/assets/images") + Path.GetFileName(file_updLogo.FileName));
                        string Imglogo = Path.GetFileName(file_updLogo.FileName);
                        FileInfo ext = new FileInfo(Imglogo);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_updLogo.PostedFile.ContentLength < 104857600)
                            {
                                if (txtSysName.Value == "") { Min.System_Name = systemName; } else { Min.System_Name = txtSysName.Value; }
                                if (txtSysTitle.Value =="") { Min.System_Title = systemTitle; } else { Min.System_Title = txtSysTitle.Value; }
                                if (txtSysMaile.Value =="") { Min.System_Email = systemMail;} else { Min.System_Email = txtSysMaile.Value; }
                                if (txtTheme.Value =="") { Min.Theme = them;} else { Min.Theme = txtTheme.Value; }
                                if (txtSlogan.Value =="") { Min.Slogan = slogan;  } else { Min.Slogan = txtSlogan.Value; }                                                           
                                Min.Logo = Imglogo;

                                msg = I.UpdateSettings(Min, Convert.ToInt32(id));
                                if (msg > 0)
                                {
                                    Response.Redirect("~/FleetApp/Settings.aspx");
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        
                        Min.Logo =logo;
                        if (txtSysName.Value == "") { Min.System_Name = systemName; } else { Min.System_Name = txtSysName.Value; }
                        if (txtSysTitle.Value == "") { Min.System_Title = systemTitle; } else { Min.System_Title = txtSysTitle.Value; }
                        if (txtSysMaile.Value == "") { Min.System_Email = systemMail; } else { Min.System_Email = txtSysMaile.Value; }
                        if (txtTheme.Value == "") { Min.Theme = them; } else { Min.Theme = txtTheme.Value; }
                        if (txtSlogan.Value == "") { Min.Slogan = slogan; } else { Min.Slogan = txtSlogan.Value; }

                        msg = I.UpdateSettings(Min, Convert.ToInt32(id));
                        if (msg > 0)
                        {
                            Response.Redirect("~/FleetApp/Settings.aspx");
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;

                        }
                    }
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
            }
        }
        protected void btn_save_Click(object sender, EventArgs args)
        {
            Update();
        }
    }
}