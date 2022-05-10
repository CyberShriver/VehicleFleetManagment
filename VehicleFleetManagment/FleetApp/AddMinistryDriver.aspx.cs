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
    public partial class AddMinistryDriver : System.Web.UI.Page
    {
        MinDriver_Class  Md = new MinDriver_Class ();
        MinDriver_Interface I = new MinDriver_Imp();
        int msg;
        string id;
        string codeMin = "Min-1/2022";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["MIN_DRIVER_ID"];
            if (!IsPostBack)
            {
                Ministry();
                MsgInit();
                Vehicle();
                Driver();
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
                if (DropDown_Vehicle.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" || DropDown_Status.SelectedValue == "-1" || DropDown_Ministry.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Md.Min_Driver_RegNumber  = DropDown_Vehicle.SelectedItem.Value;
                    Md.DRIVER_ID  = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Md.Position_Status  = DropDown_Status.SelectedValue;
                    Md.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedItem.Value);

                    msg = I.Add(Md);
                    if (msg > 0)
                    {
                        I.Add(Md);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;



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
                if (DropDown_Driver.SelectedValue == "" || DropDown_Status.SelectedValue == "" || DropDown_Vehicle.SelectedValue == "-1" || DropDown_Ministry.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    Md.Min_Driver_RegNumber  = DropDown_Vehicle.SelectedItem.Value;
                    Md.DRIVER_ID  = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Md.Position_Status  = DropDown_Status.SelectedValue;
                    Md.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedItem.Value);

                    msg = I.Update(Md, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewMinistryDriver.aspx");
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
                I.provide(Md, Convert.ToInt32(id));

                DropDown_Vehicle.SelectedValue = Md.Min_Driver_RegNumber.ToString();
                DropDown_Status.SelectedValue = Md.Position_Status ;
                DropDown_Ministry.SelectedValue = Md.MINISTRY_ID.ToString();
                DropDown_Driver.SelectedValue = Md.DRIVER_ID.ToString();
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
        void Driver()
        {
            I.DisplayDriver(DropDown_Driver);
        }

        //Add dropDawn Vehicle
        void AllVehicle()
        {
            I.DisplayAllVehicle(DropDown_Vehicle);
        }

        //Add dropDawn Vehicle
        void Vehicle()
        {
            I.DisplayVehicle(DropDown_Vehicle,Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle();
        }
    }
}