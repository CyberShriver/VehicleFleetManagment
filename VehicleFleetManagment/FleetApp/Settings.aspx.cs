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
        Role_Class Ro = new Role_Class();
        Role_Interface Ir = new Role_Imp();

        private int msg;
        string codeMin;
        int id;
        string ID_Role;
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
            ChargeCookies();
                MultiView.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                txtSystemTitle.Text = systemTitle;
                HeaderSlogan.Text = slogan;

                MsgInit();
                ChargeData();
                //confirm();
            }
        }

        //SAVED COOKIES METHODE
        void ChargeCookies()
        {


            if (Request.Cookies["Code_Min"] != null && Request.Cookies["Ministry_Name"] != null && Request.Cookies["System_Email"] != null && Request.Cookies["MINISTRY_ID"] != null && Request.Cookies["Slogan"] != null && Request.Cookies["System_Title"] != null && Request.Cookies["Logo"] != null && Request.Cookies["System_Name"] != null && Request.Cookies["Picture"] != null && Request.Cookies["Theme"] != null)
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

        }

        //=========================================== Settings =============================

        //MANAGE BUTTON ACTIVATION
        void buttonState()
        {
            if (txtSysTitle.Value == "" && txtSysName.Value == "" && txtSysMaile.Value == "" && txtTheme.Value == "" && txtSlogan.Value == "" && file_updLogo.HasFile==false)
            {
                btnSave.Disabled=true;
                btnCancel.Disabled=true;
            }
            else
            {
                btnSave.Disabled = false;
                btnCancel.Disabled = false;
            }

        }
       
     
        //MANAGE CONFIRM BUTTON ON SUBMIT CHANGES
        void confirm()
        {         
                string message = "Logout to apply the Changes!!";
                ClientScript.RegisterOnSubmitStatement(this.GetType(), "confirm", "return confirm('" + message + "');");                
        }
      
        //STATE MESSAGES
        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
        }

        //UPDATE SETTINGS 
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

                    SuccessMsg.Visible = false;
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
                                    Response.Redirect("~/FleetApp/Login.aspx");
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
                            Response.Redirect("~/FleetApp/Login.aspx");
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

        //SAVE CHANGES BUTTON
        protected void btn_save_Click(object sender, EventArgs args)
        {
            
            Update();
        }


        //=========================================== Profile =============================

        //CHARGE PROFILE DATA
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
                Image1.ImageUrl = "~/FleetApp/assets/images/Users/" + Min.Picture;
            }
        }



        protected void ActiveSettings_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 0;
            MsgInit();

            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link active");

            tabProfile.Attributes.Remove("class");
            tabProfile.Attributes.Add("class", "nav-link");

        }
        protected void ActiveProfile_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 1;
            MsgInit();

            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link");

            tabProfile.Attributes.Remove("class");
            tabProfile.Attributes.Add("class", "nav-link active");

        }

    }
}