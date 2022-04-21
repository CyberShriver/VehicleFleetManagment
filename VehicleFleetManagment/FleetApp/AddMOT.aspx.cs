using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;
using System.Data.SqlClient;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddMOT : System.Web.UI.Page
    {
        MOT_Class MO = new MOT_Class();
        MOT_Interface I = new MOT_Imp();
        int msg;
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["MOT_ID"];
            if (!IsPostBack)
            {
                MsgInit();
                Ministry();
                Vehicle();
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

        void Add()
        {
            try
            {
                if (txtMOT.Value == "" || txtAgency.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    MO.MINISTRY_ID =Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    MO.MOT_Number = txtMOT.Value;
                    MO.MOT_Agency_Name = txtAgency.Value;
                    MO.Visit_Dte = dateVisit.Value.ToString();
                    MO.Validity_End_Dte = dateExpValidity.Value.ToString();
                    MO.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);

                    msg = I.Add(MO);
                    if (msg > 0)
                    {
                        I.Add(MO);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtMOT.Value = "";
                        txtAgency.Value = "";
                       
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
                if (txtMOT.Value == "" || txtAgency.Value == "" )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    MO.MINISTRY_ID =Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    MO.MOT_Number = txtMOT.Value;
                    MO.MOT_Agency_Name = txtAgency.Value;
                    MO.Visit_Dte =dateVisit.Value.ToString();
                    MO.Validity_End_Dte = dateExpValidity.Value.ToString();
                    MO.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);

                    msg = I.Update(MO, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewMOT.aspx");
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
                I.provide(MO, Convert.ToInt32(id));

                DropDown_Ministry.SelectedValue = MO.MINISTRY_ID.ToString();
                txtMOT.Value = MO.MOT_Number;
                txtAgency.Value = MO.MOT_Agency_Name;
                dateVisit.Value = MO.Visit_Dte;
                dateExpValidity.Value = MO.Validity_End_Dte;
                DropDown_Plate.SelectedItem.Value = MO.VEHICLE_ID.ToString();
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

        //Add dropDawn Vehicle
        void AllVehicle()
        {
            I.DisplayAllVehicle(DropDown_Plate);
        }
        //Add dropDawn Minisrty
        void Ministry()
        {
            I.DisplayMinistry(DropDown_Ministry);
        }
        //Add dropDawn Vehicle
        void Vehicle()
        {
            I.DisplayVehicle(DropDown_Plate, Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle();
        }
    }
}