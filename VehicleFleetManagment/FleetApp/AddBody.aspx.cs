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

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["BODY_ID"];
            if (!IsPostBack)
            {
                MsgInit();
                if (id == null)
                {
                    btnSave.InnerText = "Save";
                    // Response.Redirect("~/sima/province.aspx/");
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
                            I.Add(Bo);
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