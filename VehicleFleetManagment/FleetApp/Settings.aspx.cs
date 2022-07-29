﻿using System;
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
            ID_Role = Request.QueryString["ROLE_ID"];
                MultiView.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                txtSystemTitle.Text = systemTitle;
                HeaderSlogan.Text = slogan;

                MsgInit();
                ChargeData();
                //confirm();

                MsgInitRole();
                ChargeDataRole();
                getDataGDVRole();

                if (ID_Role == null)
                {
                    btnSave.InnerText = "Save";
                }                
                else
                {
                    btnSave.InnerText = "Edit";
                    getDataGDVRole();
                }
            }
        }

        //SAVED COOKIES METHODE
        void ChargeCookies()
        {


            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Ministry_Name"] != null || Request.Cookies["System_Email"] != null || Request.Cookies["MINISTRY_ID"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null || Request.Cookies["Logo"] != null || Request.Cookies["System_Name"] != null || Request.Cookies["Picture"] != null || Request.Cookies["Theme"] != null)
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


        //=========================================== ROLE =============================

        // MESSAGES Role
        private void MsgInitRole()
        {
            successMsgRole.Visible = false;
            EmptyRoleMsg.Visible = false;
            failMsgRole.Visible = false;
        }

        public void getDataGDVRole()
        {
            
                Ir.Display(gdv);
                nbr.Text = Ir.count().ToString();
            

        }

        //Add 
        void Add_Role()
        {
            try
            {
                if (txtRole.Value == "" || txtDescript.Value == "")
                {
                    EmptyRoleMsg.Visible = true;
                    failMsgRole.Visible = false;
                    successMsgRole.Visible = false;
                }
                else
                {

                    Ro.Role_Name = txtRole.Value;
                    Ro.Descrept = txtDescript.Value;

                    msg = Ir.Add(Ro);
                    if (msg > 0)
                    {
                        EmptyRoleMsg.Visible = false;
                        failMsgRole.Visible = false;
                        successMsgRole.Visible = true;

                        txtRole.Value = "";
                        txtDescript.Value = "";
                    }
                    else
                    {
                        EmptyRoleMsg.Visible = false;
                        failMsgRole.Visible = true;
                        successMsgRole.Visible = false;

                    }
                }
            }
            catch (SqlException e)
            {
                EmptyRoleMsg.Visible = false;
                failMsgRole.Visible = true;
                successMsgRole.Visible = false;
            }
        }

        //update
        void Update_Role()
        {
            try
            {
                if (txtRole.Value == "" || txtDescript.Value == "")
                {
                    EmptyRoleMsg.Visible = true;
                    failMsgRole.Visible = false;
                    successMsgRole.Visible = false;
                }
                else
                {
                    Ro.Role_Name = txtRole.Value;
                    Ro.Descrept = txtDescript.Value;

                    msg = Ir.Update(Ro, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/Settings.aspx");
                        MultiView.ActiveViewIndex = 2;
                    }
                    else
                    {
                        EmptyRoleMsg.Visible = false;
                        failMsgRole.Visible = true;
                        successMsgRole.Visible = false;

                    }
                }
            }
            catch (SqlException e)
            {
                EmptyRoleMsg.Visible = false;
                failMsgRole.Visible = true;
                successMsgRole.Visible = false;
            }
        }

        protected void ChargeDataRole()
        {
            if (ID_Role != null)
            {
                Ir.provide(Ro, Convert.ToInt32(ID_Role));
                txtRole.Value = Ro.Role_Name;
                txtDescript.Value = Ro.Descrept;
            }
        }

        protected void btn_save_role_Click(object sender, EventArgs args)
        {
            if (ID_Role == null)
            {
                Add_Role();
                getDataGDVRole();
                MultiView.ActiveViewIndex = 2;
            }
            else
                Update_Role();
            getDataGDVRole();
            MultiView.ActiveViewIndex = 2;
        }

        protected void btn_srch_Click(object sender, EventArgs e)
        {
            if (txt_Search.Value == "")
            {
                getDataGDVRole();
                MultiView.ActiveViewIndex = 2;
            }
            else {
                Ir.Research(gdv, txt_Search.Value);
                MultiView.ActiveViewIndex = 2;
            }
        }

        protected void btnReload_click(object sender, EventArgs e)
        {
            getDataGDVRole();
            txt_Search.Value = "";
        }

        protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/FleetApp/Settings.aspx?ROLE_ID=" + index);
                getDataGDVRole();
                MultiView.ActiveViewIndex = 2;

            }
            if (e.CommandName == "delet")
            {
                Ir.Delete(index);
                Response.Redirect("~/FleetApp/Settings.aspx");
                getDataGDVRole();
                MultiView.ActiveViewIndex = 2;
            }


        }

        protected void checkSel_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkStatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
            DeleteAllVisibility.Visible = true;
        }
        protected void checkSelHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeader = (CheckBox)gdv.HeaderRow.FindControl("checkSelHeader");
            foreach (GridViewRow row in gdv.Rows)
            {
                CheckBox chkrow = (CheckBox)row.FindControl("checkSel");
                Button btnEdit = (Button)row.FindControl("btn_Edit");
                Button btnDelete = (Button)row.FindControl("Btn_Delete");

                if (chkHeader.Checked == true)
                {
                    chkrow.Checked = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    DeleteAllVisibility.Visible = true;
                    chkHeader.Text = "Deselect All";

                }
                else
                {
                    chkrow.Checked = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    DeleteAllVisibility.Visible = false;
                    chkHeader.Text = " Select All";
                }

            }
        }
        protected void DeleteCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                CheckBox chkdelete = (CheckBox)gdv.Rows[i].Cells[0].FindControl("checkSel");
                if (chkdelete.Checked)
                {
                    int id = Convert.ToInt32(gdv.DataKeys[i].Value);
                    Ir.Delete(id);
                    MultiView.ActiveViewIndex = 2;
                    gdv.EditIndex = -1;
                }
            }
            getDataGDVRole();
            DeleteAllVisibility.Visible = false;
            MultiView.ActiveViewIndex = 2;
        }

        protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdv.PageIndex = e.NewPageIndex;
            this.getDataGDVRole();
            MultiView.ActiveViewIndex = 2;

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
        }

        protected void ActiveSettings_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 0;
            MsgInit();

            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link active");

            tabProfile.Attributes.Remove("class");
            tabProfile.Attributes.Add("class", "nav-link");

            tabRole.Attributes.Remove("class");
            tabRole.Attributes.Add("class", "nav-link ");
        }
        protected void ActiveProfile_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 1;
            MsgInit();

            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link");

            tabProfile.Attributes.Remove("class");
            tabProfile.Attributes.Add("class", "nav-link active");

            tabRole.Attributes.Remove("class");
            tabRole.Attributes.Add("class", "nav-link ");
        }

        protected void ActiveRole_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 2;
            MsgInit();
            tabSettings.Attributes.Remove("class");
            tabSettings.Attributes.Add("class", "nav-link");

            tabProfile.Attributes.Remove("class");
            tabProfile.Attributes.Add("class", "nav-link ");

            tabRole.Attributes.Remove("class");
            tabRole.Attributes.Add("class", "nav-link active");
        }
    }
}