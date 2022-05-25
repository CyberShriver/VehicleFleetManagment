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
    public partial class AddLeave : System.Web.UI.Page
    {
        Leave_Class  Le = new Leave_Class ();
        Leave_Interface I = new Leave_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["LEAVE_ID"];
            ChargeCookies();
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MsgInit();
                Ministry();
                Driver();
                LeaveType();
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
                if (txtLeaveCode.Value == "" || txtCarpooling.Value == "" || dateStart.Value == "" || dateEnd.Value == ""
                    || txtComment.Value == "" || txtApproved.Value == "" || dateDemand.Value == "" || dateApproved.Value == ""
                    || DropDown_Ministry.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" || DropDown_LeaveType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Le.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Le.Leave_Code = txtLeaveCode.Value;
                    Le.Carpooling = txtCarpooling.Value;
                    Le.End_Dte = dateEnd.Value;
                    Le.Start_Dte = dateStart.Value;
                    Le.Comment = txtComment.Value;
                    Le.Saved_Date = DateTime.Now.ToString();
                    Le.Approved_By = txtApproved.Value;
                    Le.Demand_Dte =  dateDemand.Value ;
                    Le.Approved_Dte =dateApproved.Value;
                    Le.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Le.LEAVE_TYPE_ID = Convert.ToInt32(DropDown_LeaveType.SelectedValue);

                    msg = I.Add(Le);
                    if (msg > 0)
                    {
                        I.Add(Le);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtLeaveCode.Value = "";
                        txtCarpooling.Value = "";
                        txtApproved.Value = "";
                        dateEnd.Value = "";
                        dateStart.Value = "";
                        dateStart.Value = "";
                        dateDemand.Value = "";
                        dateApproved.Value = "";

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
                if (txtLeaveCode.Value == "" || txtCarpooling.Value == "" || dateStart.Value == "" || dateEnd.Value == ""
                   || txtComment.Value == "" || txtApproved.Value == "" || dateDemand.Value == "" || dateApproved.Value == ""
                   || DropDown_Ministry.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" || DropDown_LeaveType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Le.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Le.Leave_Code = txtLeaveCode.Value;
                    Le.Carpooling = txtCarpooling.Value;
                    Le.End_Dte = dateEnd.Value;
                    Le.Start_Dte = dateStart.Value;
                    Le.Comment = txtComment.Value;
                    Le.Saved_Date = DateTime.Now.ToString();
                    Le.Approved_By = txtApproved.Value;
                    Le.Demand_Dte = dateDemand.Value;
                    Le.Approved_Dte = dateApproved.Value;
                    Le.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Le.LEAVE_TYPE_ID = Convert.ToInt32(DropDown_LeaveType.SelectedValue);

                    msg = I.Update(Le, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewLeave.aspx");
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
                I.provide(Le, Convert.ToInt32(id));

                DropDown_Ministry.SelectedValue = Le.MINISTRY_ID.ToString();
                txtLeaveCode.Value = Le.Leave_Code;
                txtCarpooling.Value = Le.Carpooling;
                txtComment.Value = Le.Comment;
                txtApproved.Value = Le.Approved_By;
                dateStart.Value = Le.Start_Dte;
                dateEnd.Value = Le.End_Dte;
                dateDemand.Value = Le.Demand_Dte;
                dateApproved.Value = Le.Approved_Dte;
                DropDown_Driver.SelectedItem.Value = Le.MIN_DRIVER_ID.ToString();
                DropDown_LeaveType.SelectedItem.Value = Le.LEAVE_TYPE_ID.ToString();
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

        //Add dropDown LeaveType
        void LeaveType()
        {
            I.DisplayLeaveType(DropDown_LeaveType);
        }
        //Add dropDown Minisrty
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
        //Add dropDown driver
        void Driver()
        {
            I.DisplayDriver(DropDown_Driver, Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver();
        }
    }
}