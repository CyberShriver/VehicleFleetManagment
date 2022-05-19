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
                if (txtWork.Value == "" || txtLocationCode.Value == "" || dateStart.Value == "" || dateEnd.Value == "" || txtOdomOUT.Value == ""
                    || txtComment.Value == "" || txtReason.Value == "" || txtWorkStatus.Value == "" || txtOdomIN.Value == ""
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
                        I.Add(Re);
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
                      || txtComment.Value == "" || txtReason.Value == "" || txtWorkStatus.Value == "" || txtOdomIN.Value == ""
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
            if (id == null)
            {
                Add();
            }
            else
                Update();
        }

        //Add dropDawn all Vehicle
        void AllVehicle()
        {
            I.DisplayAllVehicle(DropDown_Plate);
        }

        //Add dropDawn all crash
        void AllCrash()
        {
            I.DisplayAllCrash(DropDown_Crash);
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

        //Add dropDawn crash
        void Crash()
        {
            I.DisplayCarCrash(DropDown_Crash, Convert.ToInt32(DropDown_Plate.SelectedItem.Value));
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