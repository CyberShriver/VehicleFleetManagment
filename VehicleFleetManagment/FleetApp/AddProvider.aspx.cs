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
    public partial class AddProvider : System.Web.UI.Page
    {
        Provider_Class  Pr = new Provider_Class ();
        Provider_Interface I = new Provider_Imp();
        int msg;
        string id;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["PROVIDER_ID"];
            ChargeCookies();

            if (!IsPostBack)
            {
                MsgInit();
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

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

        void ChargeCookies()
        {
            if ( Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
            {
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
            }

        }
        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
        }

        //Add 
        void Add()
        {
            try
            {
                if (txtCode.Value == "" || txtFullName.Value == "" || txtTel.Value=="" || txtMail.Value=="" )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Pr.Provider_Type = DropDown_ProviderType.SelectedItem.Value;
                    Pr.Provider_Code = txtCode.Value;
                    Pr.Full_Name = txtFullName.Value;
                    Pr.Phone = txtTel.Value;
                    Pr.Email = txtMail.Value;
                    Pr.Stat = DropDown_Status.SelectedItem.Value;

                    msg = I.Add(Pr);
                    if (msg > 0)
                    {
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtCode.Value = "";
                        txtFullName.Value = "";
                        txtTel.Value = "";
                        txtMail.Value = "";
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
                if (txtCode.Value == "" || txtFullName.Value == "" || txtTel.Value == "" || txtMail.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    Pr.Provider_Type = DropDown_ProviderType.SelectedItem.Value;
                    Pr.Provider_Code = txtCode.Value;
                    Pr.Full_Name = txtFullName.Value;
                    Pr.Phone = txtTel.Value;
                    Pr.Email = txtMail.Value;
                    Pr.Stat = DropDown_Status.SelectedItem.Value;

                    msg = I.Update(Pr, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewProvider.aspx");
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
                I.provide(Pr, Convert.ToInt32(id));

                 DropDown_ProviderType.SelectedItem.Value= Pr.Provider_Type;
                 txtCode.Value = Pr.Provider_Code;
                 txtFullName.Value= Pr.Full_Name;
                 txtTel.Value = Pr.Phone;
                 txtMail.Value= Pr.Email;
                 DropDown_Status.SelectedItem.Value= Pr.Stat;
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