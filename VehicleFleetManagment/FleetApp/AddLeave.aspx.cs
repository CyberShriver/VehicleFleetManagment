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

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["LEAVE_ID"];
            if (!IsPostBack)
            {
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

        //Add dropDawn LeaveType
        void LeaveType()
        {
            I.DisplayLeaveType(DropDown_LeaveType);
        }
        //Add dropDawn Minisrty
        void Ministry()
        {
            I.DisplayMinistry(DropDown_Ministry);
        }
        //Add dropDawn Vehicle
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