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

        Vehicle_Class Veh = new Vehicle_Class();
        Vehicle_Interface Iveh = new  Vehicle_Imp();

        Driver_Class Dr = new Driver_Class();
        Driver_Interface Idr = new Driver_Imp();

        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            id = Request.QueryString["MIN_DRIVER_ID"];

            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                Ministry();
                MsgInit();
                Vehicle();
                Driver();
                if (id == null)
                {
                    btnSave.InnerText = "Save";
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    //ChargeData();
                    //swap();
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
            FailLicence.Visible = false;
        }

        //Add 
        void Add()
        {
            try
            {
                if (DropDown_Vehicle.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1" ||  DropDown_Ministry.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                    FailLicence.Visible = false;
                }
                else
                {

                    Md.Min_Driver_RegNumber  = DropDown_Vehicle.SelectedItem.Value;
                    Md.DRIVER_ID  = Convert.ToInt32(DropDown_Driver.SelectedValue);
                    Md.Position_Status  = "On Post";
                    Md.StartDate  = DateTime.Today.ToShortDateString();
                    Md.EndDate  = "-";
                    Md.Swaped_Vehicle  = "-";
                    Md.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedItem.Value);

                    msg = I.Add(Md);
                    if (msg > 0)
                    {
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;
                        FailLicence.Visible = false;



                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FillMsg.Visible = false;
                        FailMsg.Visible = true;
                        FailLicence.Visible = false;

                    }
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
                FailLicence.Visible = false;
            }
        }

        //update
        //void Update()
        //{
        //    try
        //    {
        //        if (DropDown_Driver.SelectedValue == "" || DropDown_Status.SelectedValue == "" || DropDown_Vehicle.SelectedValue == "-1" || DropDown_Ministry.SelectedValue == "-1")
        //        {
        //            SuccessMsg.Visible = false;
        //            FillMsg.Visible = true;
        //            FailMsg.Visible = false;
        //        }
        //        else
        //        {
        //            Md.Min_Driver_RegNumber  = DropDown_Vehicle.SelectedItem.Value;
        //            Md.DRIVER_ID  = Convert.ToInt32(DropDown_Driver.SelectedValue);
        //            Md.Position_Status  = DropDown_Status.SelectedValue;
        //            Md.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedItem.Value);

        //            msg = I.Update(Md, Convert.ToInt32(id));

        //            if (msg > 0)
        //            {
        //                Response.Redirect("~/FleetApp/ViewMinistryDriver.aspx");
        //            }
        //            else
        //            {
        //                SuccessMsg.Visible = false;
        //                FillMsg.Visible = false;
        //                FailMsg.Visible = true;

        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        SuccessMsg.Visible = false;
        //        FillMsg.Visible = false;
        //        FailMsg.Visible = true;
        //    }
        //}

        //update vehicle vailability 

        //void vehicleDriverState()
        //{
        //    if(DropDown_Status.SelectedValue== "On Post")
        //    {
        //        Iveh.UpdateVehUnavailable(Veh, DropDown_Vehicle.SelectedItem.Value);
        //        Idr.UpdateMinistryWorkState(Dr, Convert.ToInt32(DropDown_Driver.SelectedItem.Value),codeMin);
        //        Idr.UpdateWorkState(Dr, Convert.ToInt32(DropDown_Driver.SelectedItem.Value));

        //    }
        //    else if(DropDown_Status.SelectedValue == "Swaped to another")
        //    {
        //        Iveh.UpdateVehAvailable(Veh, DropDown_Vehicle.SelectedItem.Value);
        //        Idr.UpdateWorkState(Dr, Convert.ToInt32(DropDown_Driver.SelectedItem.Value));
        //    }
        //    else if (DropDown_Status.SelectedValue == "Leave")
        //    {
        //        Iveh.UpdateVehAvailable(Veh, DropDown_Vehicle.SelectedItem.Value);
        //        Idr.UpdateWorkState(Dr, Convert.ToInt32(DropDown_Driver.SelectedItem.Value));
        //    }
        //    else
        //    {
        //        Iveh.UpdateVehAvailable(Veh, DropDown_Vehicle.SelectedItem.Value);
        //        Idr.UpdateFreeState(Dr, Convert.ToInt32(DropDown_Driver.SelectedItem.Value));
        //        Idr.UpdateMinistryWorkStateEmpty(Dr, Convert.ToInt32(DropDown_Driver.SelectedItem.Value));
        //    }
        //}

        //protected void ChargeData()
        //{
        //    if (id != null)
        //    {
        //        I.provide(Md, Convert.ToInt32(id));

        //        DropDown_Vehicle.SelectedValue = Md.Min_Driver_RegNumber.ToString();
        //        DropDown_Status.SelectedValue = Md.Position_Status ;
        //        DropDown_Ministry.SelectedValue = Md.MINISTRY_ID.ToString();
        //        DropDown_Driver.SelectedValue = Md.DRIVER_ID.ToString();
        //    }
        //}

        protected void btn_save_Click(object sender, EventArgs args)
        {
            msg = I.DrivingLicenceValidation(Convert.ToInt32(DropDown_Driver.SelectedValue), DropDown_Vehicle.SelectedValue);
            if (msg == 1)
            {
                if (id == null)
                {
                    verification();
                }
                
                else
                {
                    verification();
                    Response.Redirect("~/FleetApp/ViewMinistryDriver.aspx");
                }
               
            }
            else
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = false;
                FailLicence.Visible = true;
            }


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

        //Verification

        void verification()
        {
            
               msg= I.LastSaved(Md, Convert.ToInt32(DropDown_Driver.SelectedValue), DropDown_Vehicle.SelectedItem.Value);
            if (msg==1)
            {
                Add();
                I.UpdateVehUnavailable(DropDown_Vehicle.SelectedItem.Value);
            }
            else
            {
                Add();
                I.UpdateVehUnavailable( DropDown_Vehicle.SelectedItem.Value);
            }
        }

        //control swap button
        //void swap()
        //{
        //    if(DropDown_Status.SelectedValue=="Swaped to another")
        //    {
        //        btnSave.Visible = false;
        //    }
        //    else
        //    {
        //        btnSave.Visible = true;
        //    }
        //}
        // DropDawn Driver
        void Driver()
        {
            if (id != null && codeMin!="All")
            {
            I.DisplayDriverMinAll(DropDown_Driver,codeMin, Convert.ToInt32(id));
            }
            else if(id != null && codeMin == "All")
            {
                I.DisplayDriverAll(DropDown_Driver);

            }
            else
            {
                I.DisplayDriver(DropDown_Driver,codeMin);
            }
        }


        // dropDown Vehicle
        void Vehicle()
        {
            if (id != null && codeMin != "All")
            {
                I.DisplayVehicle(DropDown_Vehicle, Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
            }
            else if (id != null && codeMin == "All")
            {
                I.DisplayAllVehicle(DropDown_Vehicle);

            }
            else
            {
                I.DisplayVehicle(DropDown_Vehicle, Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
            }

        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dropdown all vehicles
            I.DisplayAllVehicle(DropDown_Vehicle);
        }
    }
}