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
    public partial class AddLicense : System.Web.UI.Page
    {
        License_Class  Li = new License_Class ();
        License_Interface I = new License_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["LICENSE_ID"];
            ChargeCookies();
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MsgInit();
                Ministry();
                Driver();
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
                if (txtLicenseCode.Value == "" || txtInterCode.Value == "" || dateExp.Value == "" || dateExpInter.Value == ""
                    || txtCodeMission.Value == "" || dateCodeMissionExp.Value == "" 
                    || DropDown_Ministry.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" || dropDown_Bike.SelectedValue == "-1"
                    || DropDown_ligthVeh.SelectedValue == "-1" || DropDown_HeavyWeight.SelectedValue == "-1" || DropDown_Trailer.SelectedValue == "-1"
                    || DropDown_4x4.SelectedValue == "-1" || DropDown_licenseState.SelectedValue == "-1" 
                    )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Li.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Li.License_Code = txtLicenseCode.Value;
                    Li.International_License_Code = txtInterCode.Value;
                    Li.Inter_License_Code_Exp_Date = dateExpInter.Value;
                    Li.License_Code_Mission = txtCodeMission.Value;
                    Li.Exp_Date = dateExp.Value;
                    Li.Saved_Dte = DateTime.Now.ToString();
                    Li.License_Code_Mission_Exp_Dte = dateCodeMissionExp.Value;
                    Li.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Li.Bike = dropDown_Bike.SelectedValue;
                    Li.Light_Vehicle = DropDown_ligthVeh.SelectedValue;
                    Li.Heavy_Weights = DropDown_HeavyWeight.SelectedValue;
                    Li.Trailer_Weight = DropDown_Trailer.SelectedValue;
                    Li.FourXfour = DropDown_4x4.SelectedValue;
                    Li.License_State = DropDown_licenseState.SelectedValue;

                    msg = I.Add(Li);
                    if (msg > 0)
                    {
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtLicenseCode.Value = "";
                        txtInterCode.Value = "";
                        txtCodeMission.Value = "";
                        dateExpInter.Value = "";
                        dateExp.Value = "";
                    

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
                if (txtLicenseCode.Value == "" || txtInterCode.Value == "" || dateExp.Value == "" || dateExpInter.Value == ""
                   || txtCodeMission.Value == "" || dateCodeMissionExp.Value == ""
                   || DropDown_Ministry.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" || dropDown_Bike.SelectedValue == "-1"
                   || DropDown_ligthVeh.SelectedValue == "-1" || DropDown_HeavyWeight.SelectedValue == "-1" || DropDown_Trailer.SelectedValue == "-1"
                   || DropDown_4x4.SelectedValue == "-1" || DropDown_licenseState.SelectedValue == "-1"
                   )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Li.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Li.License_Code = txtLicenseCode.Value;
                    Li.International_License_Code = txtInterCode.Value;
                    Li.Inter_License_Code_Exp_Date = dateExpInter.Value;
                    Li.License_Code_Mission = txtCodeMission.Value;
                    Li.Exp_Date = dateExp.Value;
                    Li.Saved_Dte = DateTime.Now.ToString();
                    Li.License_Code_Mission_Exp_Dte = dateCodeMissionExp.Value;
                    Li.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Li.Bike = dropDown_Bike.SelectedValue;
                    Li.Light_Vehicle = DropDown_ligthVeh.SelectedValue;
                    Li.Heavy_Weights = DropDown_HeavyWeight.SelectedValue;
                    Li.Trailer_Weight = DropDown_Trailer.SelectedValue;
                    Li.FourXfour = DropDown_4x4.SelectedValue;
                    Li.License_State = DropDown_licenseState.SelectedValue;

                    msg = I.Update(Li, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewLicense.aspx");
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
                I.provide(Li, Convert.ToInt32(id));

                DropDown_Ministry.SelectedValue = Li.MINISTRY_ID.ToString();
                txtLicenseCode.Value = Li.License_Code;
                txtInterCode.Value = Li.International_License_Code;
                txtCodeMission.Value = Li.License_Code_Mission;
                dateExp.Value = Li.Exp_Date;
                dateExpInter.Value = Li.Inter_License_Code_Exp_Date;
                dateCodeMissionExp.Value = Li.License_Code_Mission_Exp_Dte;
                DropDown_Driver.SelectedItem.Value = Li.MIN_DRIVER_ID.ToString();
                dropDown_Bike.SelectedItem.Value = Li.Bike.ToString();
                DropDown_ligthVeh.SelectedItem.Value = Li.Light_Vehicle.ToString();
                DropDown_HeavyWeight.SelectedItem.Value = Li.Heavy_Weights.ToString();
                DropDown_Trailer.SelectedItem.Value = Li.Trailer_Weight.ToString();
                DropDown_4x4.SelectedItem.Value = Li.FourXfour.ToString();
                DropDown_licenseState.SelectedItem.Value = Li.License_State.ToString();


    

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

        //Add dropDawn drievr Minisrty
        void AllDriver()
        {
            I.DisplayAllDriver(DropDown_Driver);
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
            I.DisplayDriver(DropDown_Driver,codeMin);
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver();
        }
    }
}