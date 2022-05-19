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
    public partial class AddAssurance : System.Web.UI.Page
    {
        Assurance_Class  As = new Assurance_Class ();
        Assurance_Interface I = new Assurance_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["ASSURANCE_ID"];
            ChargeCookies();

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
                    // Response.Redirect("~/sima/province.aspx/");
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

        void Add()
        {
            try
            {
                if (txtMaintenance.Value == "" || txtInsurancePolicy.Value == "" || txtInsuranceCompany.Value == "" || txtAmount.Value == "" || txtComment.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    As.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    As.Maintenance_Type  = txtMaintenance.Value;
                    As.Insurance_Policy  = txtInsurancePolicy.Value;
                    As.Amount  = Convert.ToInt64(txtAmount.Value);
                    As.Insurance_Company  = txtInsuranceCompany.Value;
                    As.Comment  = txtComment.Value;
                    As.Insurance_Start_Date  = dateStart.Value.ToString();
                    As.Local_Insurance_Exp_Date  = dateExp.Value.ToString();
                    As.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);
                    As.Insurance_State = dropDown_AssuranceStatus.SelectedValue;

                    msg = I.Add(As);
                    if (msg > 0)
                    {
                        I.Add(As);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtMaintenance.Value = "";
                        txtInsurancePolicy.Value = "";
                        txtAmount.Value = "";
                        txtInsuranceCompany.Value = "";
                        dateStart.Value = "";
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
                if (txtMaintenance.Value == "" || txtInsurancePolicy.Value == "" || txtInsuranceCompany.Value == "" || txtAmount.Value == "" || txtComment.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    As.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    As.Maintenance_Type = txtMaintenance.Value;
                    As.Insurance_Policy = txtInsurancePolicy.Value;
                    As.Amount = Convert.ToInt64(txtAmount.Value);
                    As.Insurance_Company = txtInsuranceCompany.Value;
                    As.Comment = txtComment.Value;
                    As.Insurance_Start_Date = dateStart.Value.ToString();
                    As.Local_Insurance_Exp_Date = dateExp.Value.ToString();
                    As.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);
                    As.Insurance_State = dropDown_AssuranceStatus.SelectedValue;

                    msg = I.Update(As, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewAssurance.aspx");
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
                I.provide(As, Convert.ToInt32(id));

                DropDown_Ministry.SelectedValue = As.MINISTRY_ID.ToString();
                txtMaintenance.Value = As.Maintenance_Type ;
                txtInsurancePolicy.Value = As.Insurance_Policy ;
                txtComment.Value = As.Comment ;
                txtInsuranceCompany.Value = As.Insurance_Company ;
                txtAmount.Value = As.Amount.ToString() ;
                dateStart.Value = As.Insurance_Start_Date ;
                dateExp.Value = As.Local_Insurance_Exp_Date ;
                DropDown_Plate.SelectedItem.Value = As.VEHICLE_ID.ToString();
                dropDown_AssuranceStatus.SelectedItem.Value = As.Insurance_State;
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