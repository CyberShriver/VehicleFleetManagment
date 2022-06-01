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
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            id = Request.QueryString["MOT_ID"];
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MsgInit();
                Ministry();
                Vehicle();
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
            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
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
            if (codeMin == "All")
            {
                DMinistry.Visible = true;
                I.DisplayMinistryAll(DropDown_Ministry);
            }
            else
            {
                I.DisplayMinistry(DropDown_Ministry, codeMin);
                DMinistry.Visible = false;
            }
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