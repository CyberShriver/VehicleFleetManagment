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
    public partial class AddVehicleFuel : System.Web.UI.Page
    {
        VehicleFuelSup_Class Ve = new VehicleFuelSup_Class();
        VehicleFuelSupp_Interface I = new VehicleFuelSupp_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["VEHICLE_FUEL_ID"];
            ChargeCookies();

            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
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
                Ministry();
                Vehicle();
                Provider();

            }

        }

        void ChargeCookies()
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");
            HttpCookie MINISTRY_ID = new HttpCookie("MINISTRY_ID");
            HttpCookie Phone = new HttpCookie("Phone");
            HttpCookie Ministry_Name = new HttpCookie("Ministry_Name");
            HttpCookie Address = new HttpCookie("Address");
            HttpCookie Postal_code = new HttpCookie("Postal_code");
            HttpCookie User_Nme = new HttpCookie("User_Nme");
            HttpCookie Fax = new HttpCookie("Fax");
            HttpCookie System_Name = new HttpCookie("System_Name");
            HttpCookie System_Title = new HttpCookie("System_Title");
            HttpCookie System_Email = new HttpCookie("System_Email");
            HttpCookie Password = new HttpCookie("Password");
            HttpCookie Logo = new HttpCookie("Logo");
            HttpCookie Picture = new HttpCookie("Picture");
            HttpCookie Slogan = new HttpCookie("Slogan");
            HttpCookie Theme = new HttpCookie("Theme");

            if (Request.Cookies["Code_Min"].Value != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
            }
            else
            {
                Response.Redirect("~/FleetApp/Login.aspx");
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
                if (txtTankCode.Value == "" || txtOdometer.Value == "" || txtInitQ.Value == "" || txtConsumeQ.Value == "" || txtUnit.Value == "" || 
                    txtLiter_100_km.Value == "" || txtComment.Value == "" || DropDown_Ministry.SelectedValue == "-1" || DropDown_Vehicle.SelectedValue == "-1" ||
                    DropDown_ProviderCode.SelectedValue == "-1" || DropDown_TankType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
               
                    else
                    {
                        Ve.Tank_Code = txtTankCode.Value;
                        Ve.Odometer =Convert.ToDouble(txtOdometer.Value);
                        Ve.Initial_Qty = Convert.ToDouble(txtInitQ.Value);
                        Ve.Consumed_Qty = Convert.ToDouble(txtConsumeQ.Value);
                        Ve.United_Price = Convert.ToDouble(txtUnit.Value);
                        Ve.Total_Price = total();
                        Ve.Provider_Code = DropDown_ProviderCode.SelectedValue;
                        Ve.Fuel_Type = DropDown_fuel.SelectedValue;
                        Ve.Liter_100_km = Convert.ToDouble(txtLiter_100_km.Value);
                        Ve.Comment = txtComment.Value;
                        Ve.MINISTRY_ID =Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Ve.Tank_Type = DropDown_TankType.SelectedValue;
                        Ve.Saved_Date = DateTime.Now.Date.ToString();
                        Ve.VEHICLE_ID =Convert.ToInt32(DropDown_Vehicle.SelectedValue);
                        msg = I.Add(Ve);
                        if (msg > 0)
                        {
                            I.Add(Ve);
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                        txtTankCode.Value = "";
                        txtOdometer.Value = "";
                        txtInitQ.Value = "";
                        txtConsumeQ.Value = "";
                        txtUnit.Value = "";
                        txtLiter_100_km.Value = "";
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
                if (txtTankCode.Value == "" || txtOdometer.Value == "" || txtInitQ.Value == "" || txtConsumeQ.Value == "" || txtUnit.Value == "" || 
                    txtLiter_100_km.Value == "" || txtComment.Value == "" || DropDown_Ministry.SelectedValue == "-1" || DropDown_Vehicle.SelectedValue == "-1" ||
                    DropDown_ProviderCode.SelectedValue == "-1" || DropDown_TankType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }

                else
                {
                    Ve.Tank_Code = txtTankCode.Value;
                    Ve.Odometer = Convert.ToDouble(txtOdometer.Value);
                    Ve.Initial_Qty = Convert.ToDouble(txtInitQ.Value);
                    Ve.Consumed_Qty = Convert.ToDouble(txtConsumeQ.Value);
                    Ve.United_Price = Convert.ToDouble(txtUnit.Value);
                    Ve.Total_Price = total();
                    Ve.Provider_Code = DropDown_ProviderCode.SelectedValue;
                    Ve.Fuel_Type = DropDown_fuel.SelectedValue;
                    Ve.Liter_100_km = Convert.ToDouble(txtLiter_100_km.Value);
                    Ve.Comment = txtComment.Value;
                    Ve.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Ve.Tank_Type = DropDown_TankType.SelectedValue;
                    Ve.Saved_Date = DateTime.Now.Date.ToString();
                    Ve.VEHICLE_ID = Convert.ToInt32(DropDown_Vehicle.SelectedValue);

                    msg = I.Update(Ve,Convert.ToInt32(id));
                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewVehicleFuel.aspx");
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
                I.provide(Ve, Convert.ToInt32(id));

                txtTankCode.Value=Ve.Tank_Code ;
                txtOdometer.Value=Ve.Odometer.ToString();
                txtInitQ.Value= Ve.Initial_Qty.ToString();
                txtConsumeQ.Value= Ve.Consumed_Qty.ToString();
                txtUnit.Value= Ve.United_Price.ToString();
                DropDown_ProviderCode.SelectedValue= Ve.Provider_Code;
                txtLiter_100_km.Value= Ve.Liter_100_km.ToString();
                txtComment.Value= Ve.Comment ;
                DropDown_Ministry.SelectedValue= Ve.MINISTRY_ID.ToString();
                DropDown_TankType.SelectedValue= Ve.Tank_Type;
                DropDown_fuel.SelectedValue= Ve.Fuel_Type;
                dateSave.Value=DateTime.Now.Date.ToString();
                DropDown_Vehicle.SelectedValue= Ve.VEHICLE_ID.ToString();
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

        //Total function

        int total()
        {
            int tot=0;
            if (Convert.ToInt32(txtInitQ.Value)>= Convert.ToInt32(txtConsumeQ.Value))
            {

                int t=(Convert.ToInt32(txtInitQ.Value) - Convert.ToInt32(txtConsumeQ.Value)) * Convert.ToInt32(txtUnit.Value);
                tot = t;
            }
            else
            {
                txtInitQ.Value = "";
                txtConsumeQ.Value = "";
                txtUnit.Value = "";
               
            }
            return tot;
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
            I.DisplayVehicle(DropDown_Vehicle);
        }

        //Add dropDawn Vehicle
        void Provider()
        {
            I.DisplayProvider(DropDown_ProviderCode);
        }
    }
}