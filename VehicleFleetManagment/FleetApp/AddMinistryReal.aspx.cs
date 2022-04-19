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
    public partial class AddMinistryReal : System.Web.UI.Page
    {

        MinRealEstate_Class  Mr = new MinRealEstate_Class ();
        MinRealEstate_Interface I = new MinRealEstate_Imp();
        int msg;
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["MIN_REAL_ESTATE_ID"];
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
                RealEstate();
                Ministry();

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
                if (txtQuantity.Value == "" || txtComment.Value == "" || DropDown_RealEstate.SelectedValue == "-1" || DropDown_Ministry.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Mr.REAL_ESTATE_ID  = Convert.ToInt32(DropDown_RealEstate.SelectedItem.Value);
                    Mr.Quantity  = txtQuantity.Value;
                    Mr.Comment  = txtComment.Value;
                    Mr.MINISTRY_ID  = Convert.ToInt32(DropDown_Ministry.SelectedItem.Value);

                    msg = I.Add(Mr);
                    if (msg > 0)
                    {
                        I.Add(Mr);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtQuantity.Value = "";
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
                if (txtQuantity.Value == "" || txtComment.Value == "" || DropDown_RealEstate.SelectedValue == "-1" || DropDown_Ministry.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    Mr.REAL_ESTATE_ID = Convert.ToInt32(DropDown_RealEstate.SelectedItem.Value);
                    Mr.Quantity = txtQuantity.Value;
                    Mr.Comment = txtComment.Value;
                    Mr.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedItem.Value);

                    msg = I.Update(Mr, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewMinistryReal.aspx");
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
                I.provide(Mr, Convert.ToInt32(id));

                DropDown_RealEstate.SelectedItem.Value = Mr.REAL_ESTATE_ID.ToString() ;
                txtQuantity.Value = Mr.Quantity ;
                txtComment.Value = Mr.Comment ;
                DropDown_Ministry.SelectedItem.Value = Mr.MINISTRY_ID.ToString();
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

        //Add dropDawn Minisrty
        void Ministry()
        {
            I.DisplayMinistry(DropDown_Ministry);
        }

        //Add dropDawn Vehicle
        void RealEstate()
        {
            I.DisplayREAL_ESTATE(DropDown_RealEstate);
        }

    }
}