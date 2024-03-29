﻿using System;
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
    public partial class AddRepair : System.Web.UI.Page
    {
        Repair_Class  Re = new Repair_Class ();
        Repair_Interface I = new Repair_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;


        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();

            id = Request.QueryString["REPAIR_ID"];
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MsgInit();
                Ministry();
                Vehicle();
                Crash();
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
                if (txtWork.Value == "" || txtLocationCode.Value == "" || dateStart.Value == "" || dateEnd.Value == "" || txtOdomOUT.Value == ""
                    ||  txtReason.Value == "" || txtWorkStatus.Value == "" || txtOdomIN.Value == ""
                    || txtOffService.Value == "" || TimeStartRepair.Value == "" || TimeEndRepair.Value == ""|| txtParticiEmp.Value == "" 
                    || DropDown_Ministry.SelectedValue == "-1" || DropDown_Plate.SelectedValue == "-1" || DropDown_Crash.SelectedValue == "-1" || DropDown_InterOrExt.SelectedValue == "-1"
                    )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Re.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Re.Work_Number = txtWork.Value;
                    Re.Location_Code = txtLocationCode.Value;
                    Re.End_Dte = dateEnd.Value;
                    Re.Start_Dte = dateStart.Value;
                    Re.Comment = txtComment.Value;
                    Re.Work_Status = txtWorkStatus.Value;
                    Re.Participant_Emp_Code = txtParticiEmp.Value;
                    Re.Odometer_IN =Convert.ToInt32(txtOdomIN.Value);
                    Re.Odometer_OUT = Convert.ToInt32(txtOdomOUT.Value);
                    Re.Off_Service_Days_Number = Convert.ToInt32(txtOffService.Value);
                    Re.Internal_External =DropDown_InterOrExt.SelectedValue;
                    Re.Saved_Date = DateTime.Now.ToString();
                    Re.Reason = txtReason.Value;
                    Re.Start_Work_Time = TimeStartRepair.Value;
                    Re.End_Work_Time = TimeEndRepair.Value;
                    Re.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);
                    Re.CAR_CRASH_ID = Convert.ToInt32(DropDown_Crash.SelectedValue);

                    msg = I.Add(Re);
                    if (msg > 0)
                    {
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtWork.Value = "";
                        txtLocationCode.Value = "";
                        txtReason.Value = "";
                        dateEnd.Value = "";
                        dateStart.Value = "";
                        dateStart.Value = "";
                        TimeStartRepair.Value = "";
                        TimeEndRepair.Value = "";

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
                if (txtWork.Value == "" || txtLocationCode.Value == "" || dateStart.Value == "" || dateEnd.Value == "" || txtOdomOUT.Value == ""
                      || txtReason.Value == "" || txtWorkStatus.Value == "" || txtOdomIN.Value == ""
                      || txtOffService.Value == "" || TimeStartRepair.Value == "" || TimeEndRepair.Value == "" || txtParticiEmp.Value == ""
                      || DropDown_Ministry.SelectedValue == "-1" || DropDown_Plate.SelectedValue == "-1" || DropDown_Crash.SelectedValue == "-1" || DropDown_InterOrExt.SelectedValue == "-1"
                      )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    Re.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Re.Work_Number = txtWork.Value;
                    Re.Location_Code = txtLocationCode.Value;
                    Re.End_Dte = dateEnd.Value;
                    Re.Start_Dte = dateStart.Value;
                    Re.Comment = txtComment.Value;
                    Re.Work_Status = txtWorkStatus.Value;
                    Re.Participant_Emp_Code = txtParticiEmp.Value;
                    Re.Odometer_IN = Convert.ToInt32(txtOdomIN.Value);
                    Re.Odometer_OUT = Convert.ToInt32(txtOdomOUT.Value);
                    Re.Off_Service_Days_Number = Convert.ToInt32(txtOffService.Value);
                    Re.Internal_External = DropDown_InterOrExt.SelectedValue;
                    Re.Saved_Date = DateTime.Now.ToString();
                    Re.Reason = txtReason.Value;
                    Re.Start_Work_Time = TimeStartRepair.Value;
                    Re.End_Work_Time = TimeEndRepair.Value;
                    Re.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);
                    Re.CAR_CRASH_ID = Convert.ToInt32(DropDown_Crash.SelectedValue);

                    msg = I.Update(Re, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewRepair.aspx");
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
                I.provide(Re, Convert.ToInt32(id));

                DropDown_Ministry.SelectedValue = Re.MINISTRY_ID.ToString();
                txtWork.Value = Re.Work_Number;
                txtLocationCode.Value = Re.Location_Code;
                txtComment.Value = Re.Comment;
                txtReason.Value = Re.Reason;
                dateStart.Value = Re.Start_Dte;
                dateEnd.Value = Re.End_Dte;
                TimeStartRepair.Value = Re.Start_Work_Time;
                TimeEndRepair.Value = Re.End_Work_Time;
                DropDown_Plate.SelectedItem.Value = Re.VEHICLE_ID.ToString();
                DropDown_Crash.SelectedItem.Value = Re.CAR_CRASH_ID.ToString();
                txtWorkStatus.Value = Re.Work_Status;
                txtParticiEmp.Value = Re.Participant_Emp_Code;
                DropDown_InterOrExt.SelectedValue = Re.Internal_External;
                txtOdomIN.Value = Re.Odometer_IN.ToString();
                txtOdomOUT.Value = Re.Odometer_OUT.ToString();
                txtOffService.Value = Re.Off_Service_Days_Number.ToString();

                
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
          
            try
            {
                if (id == null)
                {
                    Add();
                }
                else
                    Update();
            }

            catch ( SqlException e )
            {
                FailMsg.Visible = true;
            }
        }


        //Add dropDawn all Vehicle
        void AllVehicle()
        {
            try
            {
                I.DisplayAllVehicle(DropDown_Plate);
            }

            catch (NullReferenceException e)
            {
                FailMsg.Visible = true;
            }

           
        }

        //Add dropDawn all crash
        void AllCrash()
        {
            try
            {
                I.DisplayAllCrash(DropDown_Crash);
            }

            catch (NullReferenceException e)
            {
                FailMsg.Visible = true;
            }
           
        }
        //Add dropDawn Minisrty
        void Ministry()
        {
            try
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

            catch (NullReferenceException e)
            {
                FailMsg.Visible = true;
            }
          
        }
        //Add dropDawn Vehicle
        void Vehicle()
        {
            try
            {
                I.DisplayVehicle(DropDown_Plate, Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
            }

            catch (NullReferenceException e)
            {
                FailMsg.Visible = true;
            }

           
        }

        //Add dropDawn crash
        void Crash()
        {
            try
            {
                I.DisplayCarCrash(DropDown_Crash, DropDown_Plate.SelectedItem.Text);
            }

            catch (NullReferenceException e)
            {
                FailMsg.Visible = true;
            }

            
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle();
            Crash();
        }

        protected void dropDown_Plate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crash();
        }
    }
}