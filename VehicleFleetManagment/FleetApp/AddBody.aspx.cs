using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddBody : System.Web.UI.Page
    {
        BodyType_Class Bo = new BodyType_Class();
        BodyType_Interface I = new BodyType_Imp();
        int msg;
        string id;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["BODY_ID"];
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
                if (txtCategory.Value == "" || txtCategoryNum.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Bo.Category = txtCategory.Value;
                    Bo.Category_N_ =Convert.ToInt32(txtCategoryNum.Value);

                    msg = I.Add(Bo);                    
                        if (msg > 0)
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                            txtCategory.Value = "";
                            txtCategoryNum.Value = "";
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
               string error= e.Message;
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
                if (txtCategory.Value == "" || txtCategoryNum.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    Bo.Category = txtCategory.Value;
                    Bo.Category_N_ =Convert.ToInt32(txtCategoryNum.Value);

                    msg = I.Update(Bo, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewMark.aspx");
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
                I.provide(Bo, Convert.ToInt32(id));
                txtCategory.Value = Bo.Category;
                txtCategoryNum.Value = Bo.Category_N_.ToString();
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