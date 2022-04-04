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
    public partial class AddRealEstate : System.Web.UI.Page
    {
        RealEstate_Class Re = new RealEstate_Class();
        RealEstate_Interface I = new RealEstate_Imp();
        int msg;
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["REAL_ESTATE_ID"];
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
                if (txtName.Value == "" || txtComment.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Re.RealEstate_Name = txtName.Value;
                    Re.Comment = txtComment.Value;

                    msg = I.Add(Re);
                    if (msg > 0)
                    {
                        I.Add(Re);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtName.Value = "";
                        txtComment.Value = "";
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
                if (txtName.Value == "" || txtComment.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    Re.RealEstate_Name = txtName.Value;
                    Re.Comment = txtComment.Value;

                    msg = I.Update(Re, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewRealEstate.aspx");
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
                I.provide(Re, Convert.ToInt32(id));
                txtName.Value = Re.RealEstate_Name;
                txtComment.Value = Re.Comment;
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