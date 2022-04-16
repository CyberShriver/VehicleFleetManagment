using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddMinistry : System.Web.UI.Page
    {

        Ministry_Class  Min = new Ministry_Class ();
        Ministry_Interface I = new Ministry_Imp();
        int msg;
        string id;
        string code;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["MINISTRY_ID"];
            if (!IsPostBack)
            {
                MsgInit();
                if (id == null)
                {
                    btnSave.InnerText = "Save";
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    ChargeData();
                }

            }

        }

        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
        }

        //Code Generate
        string MinistryCode()
        {
            return code = "Min-" + (Convert.ToInt32(I.count() + 1)) + "/" + DateTime.Now.Year;
        }

        //Add 
        void Add()
        {
            try
            {
                if (txtName.Value == "" || txtAddress.Value == "" || txtTel.Value == "" || txtMail.Value == "" || txtPassword.Value == "" || txtSysTitle.Value == "" ||
                    txtFax.Value == "" || txtPostal.Value == "" || txtSysName.Value == ""  || txtSysMaile.Value == "" )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
               
                    else
                    {
                        Min.Code_Min = MinistryCode();
                        Min.Ministry_Name = txtName.Value;
                        Min.Address = txtAddress.Value;
                        Min.Phone = txtTel.Value;
                        Min.Fax = txtFax.Value;
                        Min.System_Name = txtSysName.Value;
                        Min.System_Title = txtSysTitle.Value;
                        Min.Postal_code = txtPostal.Value;
                        Min.Email = txtMail.Value;
                        Min.System_Email = txtSysMaile.Value;
                        Min.Password = txtPassword.Value;
          
                        msg = I.Add(Min);
                        if (msg > 0)
                        {
                            I.Add(Min);
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                        txtPostal.Value = "";
                        txtTel.Value = "";
                        txtSysTitle.Value = "";
                        txtSysName.Value = "";
                        txtPassword.Value = "";
                        txtName.Value = "";
                        txtTel.Value = "";
                        txtAddress.Value = "";
                        txtMail.Value = "";
                        txtSysName.Value = "";

                    }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;

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

        //update
        void Update()
        {

            try
            {
                if (txtName.Value == "" || txtAddress.Value == "" || txtTel.Value == "" || txtMail.Value == "" || txtPassword.Value == "" || txtSysTitle.Value == "" ||
                   txtFax.Value == "" || txtPostal.Value == "" || txtSysName.Value == "" || txtSysMaile.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }

                else
                {
                   // Min.Code_Min = txtCode.Value;
                    Min.Ministry_Name = txtName.Value;
                    Min.Address = txtAddress.Value;
                    Min.Phone = txtTel.Value;
                    Min.Fax = txtFax.Value;
                    Min.System_Name = txtSysName.Value;
                    Min.System_Title = txtSysTitle.Value;
                    Min.Postal_code = txtPostal.Value;
                    Min.Email = txtMail.Value;
                    Min.System_Email = txtSysMaile.Value;
                    Min.Password = txtPassword.Value;
                    msg = I.Update(Min, Convert.ToInt32(id));
                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewMinistry.aspx");
                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FillMsg.Visible = false;
                        FailMsg.Visible = true;

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

        protected void ChargeData()
        {
            if (id != null)
            {
                I.provide(Min, Convert.ToInt32(id));

                txtCode.Value = Min.Code_Min;
                txtName.Value = Min.Ministry_Name;
                txtAddress.Value = Min.Address;
                txtTel.Value = Min.Phone;
                txtFax.Value = Min.Fax;
                txtSysName.Value = Min.System_Name;
                txtSysTitle.Value= Min.System_Title;
                txtPostal.Value = Min.Postal_code;
                txtMail.Value = Min.Email;
                txtPassword.Value = Min.Password;
                txtSysMaile.Value = Min.System_Email;
               
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            if (id == null)
            {
                Add();
            }
            else
                Update();
        }


    }
}