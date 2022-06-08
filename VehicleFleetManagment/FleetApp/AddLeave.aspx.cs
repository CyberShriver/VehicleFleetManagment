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

        Vehicle_Class Ve = new Vehicle_Class();
        Vehicle_Interface Iv = new Vehicle_Imp();

        MinDriver_Class Md = new MinDriver_Class();
        MinDriver_Interface Imd = new MinDriver_Imp();

        int msg;
        string code;
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
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    VisApprovedBy.Visible = true;
                    VisApprovedBy.Disabled = true;
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
            DateFailed.Visible = false;
        }

        void Add()
        {
            try
            {
                if (txtCarpooling.Value == "" || dateStart.Value == "" || dateEnd.Value == "" || dateDemand.Value == "" 
                    || DropDown_Ministry.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" || DropDown_LeaveType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                    DateFailed.Visible = false;
                }
                else
                {

                    Le.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Le.Leave_Code = LeaveCode();
                    Le.Carpooling = txtCarpooling.Value;
                    Le.End_Dte = dateEnd.Value;
                    Le.Start_Dte = dateStart.Value;
                    Le.Comment = txtComment.Value;
                    Le.Saved_Date = DateTime.Now.ToString();
                    Le.Approved_By = "";
                    Le.Demand_Dte =  dateDemand.Value ;
                    Le.State = "Pending..." ;
                    Le.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Le.LEAVE_TYPE_ID = Convert.ToInt32(DropDown_LeaveType.SelectedValue);


                        msg = I.Add(Le);
                        if (msg > 0)
                        {
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

                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                            DateFailed.Visible = false;

                        }
                    
                                       
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
                DateFailed.Visible = false;
            }
        }

        //update
        void Update()
        {
            try
            {
                if (txtCarpooling.Value == "" || dateStart.Value == "" || dateEnd.Value == "" || dateDemand.Value == ""
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
                    Le.Saved_Date = DateTime.Now.Date.ToString();
                    Le.Approved_By = txtApproved.Value;
                    Le.Demand_Dte = dateDemand.Value;
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

        string LeaveCode()
        {

            if (codeMin == "All")
            {
                return code = "Leave-" + DropDown_Ministry.SelectedItem.ToString().Trim().Substring(0, 3) + (Convert.ToInt32(I.countAll() + 1)) + "/" + DateTime.Now.Date;
            }
            else
            {
                return code = "Leave-" + DropDown_Ministry.SelectedItem.ToString().Trim().Substring(0, 3) + (Convert.ToInt32(I.count(codeMin) + 1)) + "/" + DateTime.Now.Date;
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
                DropDown_Driver.SelectedItem.Value = Le.MIN_DRIVER_ID.ToString();
                DropDown_LeaveType.SelectedItem.Value = Le.LEAVE_TYPE_ID.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            if (Convert.ToDateTime(dateStart.Value).Date < Convert.ToDateTime(dateEnd.Value).Date &&
               Convert.ToDateTime(dateDemand.Value).Date < Convert.ToDateTime(dateStart.Value).Date )
            {
                if (id == null)
                {

                    Add();
                   // I.UpdatePositionState(Convert.ToInt32(DropDown_Driver.SelectedValue));
                }
                else
                    Update();
            }
            else
            {
                DateFailed.Visible = true;
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = false;
            }
            
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
        //change Mininstr draver position state and vehicle state

        void state()
        {
            
        }

    protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver();
        }
    }
}