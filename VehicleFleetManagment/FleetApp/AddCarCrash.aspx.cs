using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;
using System.Data.Entity.Validation;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddCarCrash : System.Web.UI.Page
    {
        CarCrash_Class Cr = new CarCrash_Class();
        Crash_Interface I = new Crash_Imp();

        MinDriver_Interface Imd = new MinDriver_Imp();
        int msg;
        string id;
        string code;
        string codeMin;
        string sytemTitle;
        string slogan;


        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["CAR_CRASH_ID"];
            ChargeCookies();          
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MultiView.ActiveViewIndex = 0;
                Minisrty();
                Vehicle();
                Driver();
                MsgInit();
               
                if (id == null)
                {
                    btnSave.InnerText = "Save";                    
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    I.DisplaySelectedVehicle(DropDown_Plate, codeMin,Convert.ToInt32(id));
                    I.DisplaySelectedDriver(DropDown_Driver, codeMin, Convert.ToInt32(id));
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
                if (dateCrash.Value == "" || TimeCrash.Value == "" || txtCrashPlace.Value == "" || txtAddress.Value == "" ||
                    txtResponible.Value == "" || txtSpeed.Value == "" ||
                    txtPassenger.Value == "" || txtCrashInfo.Value == "" || txtReason.Value == "" ||  txtDamage.Value == "" || dateCompensation.Value == "" ||
                     dateReport.Value == "" || dateFinalReport.Value == "" || dateDeclaration.Value == "" || txtAmount.Value == "" ||
                    DropDown_Ministry.SelectedValue == "-1" || DropDown_vehicle_Damag.SelectedValue == "-1" || DropDown_Damage_thirdParty.SelectedValue == "-1" || DropDown_thirdParty_injure.SelectedValue == "-1"
                    || DropDown_Employee_injure.SelectedValue == "-1" || dropDown_Employe_Payed.SelectedValue == "-1" || DropDown_state.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1"
                    || DropDown_Plate.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Crash/") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Cr.Crash_Code = CrashCode();
                                Cr.Damage_Third_Party = DropDown_Damage_thirdParty.SelectedValue;
                                Cr.Damaged_Vehicle = DropDown_vehicle_Damag.SelectedValue;
                                Cr.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                                Cr.Crash_Date = dateCrash.Value;
                                Cr.Crash_Time = TimeCrash.Value;
                                Cr.Condition_After_Crash = txtCondition.Value;
                                Cr.Full_Crash_Address = txtAddress.Value;
                                Cr.Crash_Place = txtCrashPlace.Value;
                                Cr.Crash_Mileage = Convert.ToDouble(txtMeileage.Value);
                                Cr.Responsible = txtResponible.Value;
                                Cr.Weather = txtWeather.Value;
                                Cr.Estimated_Speed = Convert.ToDouble(txtSpeed.Value);
                                Cr.Compensation_Rule_Dte = dateCompensation.Value;
                                Cr.Crash_Damage = txtDamage.Value;
                                Cr.Crash_Pic = img;
                                Cr.Injures_Employee = DropDown_Employee_injure.SelectedValue;
                                Cr.Crash_Reason = txtReason.Value;
                                Cr.Payed_Employee = dropDown_Employe_Payed.SelectedValue;
                                Cr.Stat = DropDown_state.SelectedValue;
                                Cr.Report_Dte = dateReport.Value;
                                Cr.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                                Cr.Local_Plate = DropDown_Plate.SelectedValue;
                                Cr.Tot_Number_Driver_drives = Convert.ToInt32(txtPassenger.Value);
                                Cr.Circumstance = txtCircumstance.Value;
                                Cr.Crash_Info = txtCrashInfo.Value;
                                Cr.Third_Party_Injures = DropDown_thirdParty_injure.SelectedValue;
                                Cr.Final_Report_Dte = dateFinalReport.Value;
                                Cr.Insurance_Declaration_Dte = dateDeclaration.Value;
                                Cr.Claim_Compensation_Amount = Convert.ToDouble(txtAmount.Value);
                                Cr.ThirdParty_Amount_Recovered = Convert.ToDouble(txtThirdPartyRecov.Value);
                                Cr.Employee_Amount_Recovered = Convert.ToDouble(txtRecoverEmpl.Value);
                                Cr.Local_Insurance_Compensation_Amount = Convert.ToDouble(txtLocalComp.Value);
                                Cr.Legal_Cost = Convert.ToDouble(txtLegalCost.Value);
                                Cr.Damage_Description = txtDamageDesipt.Value;
                                Cr.Saved_Date = DateTime.Now.ToString();
                                Cr.Passenger_Comment = txtComment.Value;

                                msg = I.Add(Cr);
                                if (msg > 0)
                                {
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = false;
                                    SuccessMsg.Visible = true;

                                    dateCrash.Value = "";
                                    TimeCrash.Value = "";
                                    txtCrashPlace.Value = "";
                                    txtAddress.Value = "";
                                    txtMeileage.Value = "";
                                    txtResponible.Value = "";
                                    txtWeather.Value = "";
                                    txtCrashPlace.Value = "";
                                    txtSpeed.Value = "";
                                    txtPassenger.Value = "";
                                    txtCrashInfo.Value = "";
                                    txtReason.Value = "";
                                    txtCondition.Value = "";
                                    txtDamage.Value = "";
                                    dateCompensation.Value = "";
                                    txtCircumstance.Value = "";
                                    dateReport.Value = "";
                                    txtCondition.Value = "";
                                    dateFinalReport.Value = "";
                                    dateDeclaration.Value = "";
                                    txtAmount.Value = "";
                                    txtDamageDesipt.Value = "";
                                    txtComment.Value = "";
                                    txtLegalCost.Value = "";
                                    txtLocalComp.Value = "";
                                    txtRecoverEmpl.Value = "";
                                    txtThirdPartyRecov.Value = "";

                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Cr.Crash_Code = CrashCode();
                        Cr.Damage_Third_Party = DropDown_Damage_thirdParty.SelectedValue;
                        Cr.Damaged_Vehicle = DropDown_vehicle_Damag.SelectedValue;
                        Cr.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Cr.Crash_Date = dateCrash.Value;
                        Cr.Crash_Time = TimeCrash.Value;
                        Cr.Condition_After_Crash = txtCondition.Value;
                        Cr.Full_Crash_Address = txtAddress.Value;
                        Cr.Crash_Place = txtCrashPlace.Value;
                        Cr.Crash_Mileage = Convert.ToInt32(txtMeileage.Value);
                        Cr.Responsible = txtResponible.Value;
                        Cr.Weather = txtWeather.Value;
                        Cr.Estimated_Speed = Convert.ToInt32(txtSpeed.Value);
                        Cr.Compensation_Rule_Dte = dateCompensation.Value;
                        Cr.Crash_Damage = txtDamage.Value;
                        Cr.Crash_Pic = "No picture";
                        Cr.Injures_Employee = DropDown_Employee_injure.SelectedValue;
                        Cr.Crash_Reason = txtReason.Value;
                        Cr.Payed_Employee = dropDown_Employe_Payed.SelectedValue;
                        Cr.Stat = DropDown_state.SelectedValue;
                        Cr.Report_Dte = dateReport.Value;
                        Cr.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                        Cr.Local_Plate = DropDown_Plate.SelectedValue;
                        Cr.Tot_Number_Driver_drives = Convert.ToInt32(txtPassenger.Value);
                        Cr.Circumstance = txtCircumstance.Value;
                        Cr.Crash_Info = txtCrashInfo.Value;
                        Cr.Third_Party_Injures = DropDown_thirdParty_injure.SelectedValue;
                        Cr.Final_Report_Dte = dateFinalReport.Value;
                        Cr.Insurance_Declaration_Dte = dateDeclaration.Value;
                        Cr.Claim_Compensation_Amount = Convert.ToDouble(txtAmount.Value);
                        Cr.ThirdParty_Amount_Recovered = Convert.ToDouble(txtThirdPartyRecov.Value);
                        Cr.Employee_Amount_Recovered = Convert.ToDouble(txtRecoverEmpl.Value);
                        Cr.Local_Insurance_Compensation_Amount = Convert.ToDouble(txtLocalComp.Value);
                        Cr.Legal_Cost = Convert.ToDouble(txtLegalCost.Value);
                        Cr.Damage_Description = txtDamageDesipt.Value;
                        Cr.Saved_Date = DateTime.Now.ToString();
                        Cr.Passenger_Comment = txtComment.Value;

                        msg = I.Add(Cr);
                        if (msg > 0)
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                            dateCrash.Value = "";
                            TimeCrash.Value = "";
                            txtCrashPlace.Value = "";
                            txtAddress.Value = "";
                            txtMeileage.Value = "";
                            txtResponible.Value = "";
                            txtWeather.Value = "";
                            txtCrashPlace.Value = "";
                            txtSpeed.Value = "";
                            txtPassenger.Value = "";
                            txtCrashInfo.Value = "";
                            txtReason.Value = "";
                            txtCondition.Value = "";
                            txtDamage.Value = "";
                            dateCompensation.Value = "";
                            txtCircumstance.Value = "";
                            dateReport.Value = "";
                            txtCondition.Value = "";
                            dateFinalReport.Value = "";
                            dateDeclaration.Value = "";
                            txtAmount.Value = "";
                            txtDamageDesipt.Value = "";
                            txtComment.Value = "";
                            txtLegalCost.Value = "";
                            txtLocalComp.Value = "";
                            txtRecoverEmpl.Value = "";
                            txtThirdPartyRecov.Value = "";
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;

                        }
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
                if (dateCrash.Value == "" || TimeCrash.Value == "" || txtCrashPlace.Value == "" || txtAddress.Value == "" ||
                    txtResponible.Value == "" || txtSpeed.Value == "" ||
                    txtPassenger.Value == "" || txtCrashInfo.Value == "" || txtReason.Value == "" || txtDamage.Value == "" || dateCompensation.Value == "" ||
                     dateReport.Value == "" || dateFinalReport.Value == "" || dateDeclaration.Value == "" || txtAmount.Value == "" ||
                    DropDown_Ministry.SelectedValue == "-1" || DropDown_vehicle_Damag.SelectedValue == "-1" || DropDown_Damage_thirdParty.SelectedValue == "-1" || DropDown_thirdParty_injure.SelectedValue == "-1"
                    || DropDown_Employee_injure.SelectedValue == "-1" || dropDown_Employe_Payed.SelectedValue == "-1" || DropDown_state.SelectedValue == "-1" || DropDown_Driver.SelectedValue == "-1"
                    || DropDown_Plate.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Crash/") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Cr.Crash_Code = txtCode.Value;
                                Cr.Damage_Third_Party = DropDown_Damage_thirdParty.SelectedValue;
                                Cr.Damaged_Vehicle = DropDown_vehicle_Damag.SelectedValue;
                                Cr.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                                Cr.Crash_Date = dateCrash.Value;
                                Cr.Crash_Time = TimeCrash.Value;
                                Cr.Condition_After_Crash = txtCondition.Value;
                                Cr.Full_Crash_Address = txtAddress.Value;
                                Cr.Crash_Place = txtCrashPlace.Value;
                                Cr.Crash_Mileage = Convert.ToInt32(txtMeileage.Value);
                                Cr.Responsible = txtResponible.Value;
                                Cr.Weather = txtWeather.Value;
                                Cr.Estimated_Speed = Convert.ToInt32(txtSpeed.Value);
                                Cr.Compensation_Rule_Dte = dateCompensation.Value;
                                Cr.Crash_Damage = txtDamage.Value;
                                Cr.Crash_Pic = img;
                                Cr.Injures_Employee = DropDown_Employee_injure.SelectedValue;
                                Cr.Crash_Reason = txtReason.Value;
                                Cr.Payed_Employee = dropDown_Employe_Payed.SelectedValue;
                                Cr.Stat = DropDown_state.SelectedValue;
                                Cr.Report_Dte = dateReport.Value;
                                Cr.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                                Cr.Local_Plate = DropDown_Plate.SelectedValue;
                                Cr.Tot_Number_Driver_drives = Convert.ToInt32(txtPassenger.Value);
                                Cr.Circumstance = txtCircumstance.Value;
                                Cr.Crash_Info = txtCrashInfo.Value;
                                Cr.Third_Party_Injures = DropDown_thirdParty_injure.SelectedValue;
                                Cr.Final_Report_Dte = dateFinalReport.Value;
                                Cr.Insurance_Declaration_Dte = dateDeclaration.Value;
                                Cr.Claim_Compensation_Amount = Convert.ToDouble(txtAmount.Value);
                                Cr.ThirdParty_Amount_Recovered = Convert.ToDouble(txtThirdPartyRecov.Value);
                                Cr.Employee_Amount_Recovered = Convert.ToDouble(txtRecoverEmpl.Value);
                                Cr.Local_Insurance_Compensation_Amount = Convert.ToDouble(txtLocalComp.Value);
                                Cr.Legal_Cost = Convert.ToDouble(txtLegalCost.Value);
                                Cr.Damage_Description = txtDamageDesipt.Value;
                                Cr.Saved_Date = DateTime.Now.ToString();
                                Cr.Passenger_Comment = txtComment.Value;

                                msg = I.Update(Cr, Convert.ToInt32(id));
                                if (msg > 0)
                                {
                                    Response.Redirect("~/FleetApp/ViewCarCrash.aspx");
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Cr.Crash_Code = txtCode.Value;
                        Cr.Damage_Third_Party = DropDown_Damage_thirdParty.SelectedValue;
                        Cr.Damaged_Vehicle = DropDown_vehicle_Damag.SelectedValue;
                        Cr.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Cr.Crash_Date = dateCrash.Value;
                        Cr.Crash_Time = TimeCrash.Value;
                        Cr.Condition_After_Crash = txtCondition.Value;
                        Cr.Full_Crash_Address = txtAddress.Value;
                        Cr.Crash_Place = txtCrashPlace.Value;
                        Cr.Crash_Mileage = Convert.ToInt32(txtMeileage.Value);
                        Cr.Responsible = txtResponible.Value;
                        Cr.Weather = txtWeather.Value;
                        Cr.Estimated_Speed = Convert.ToInt32(txtSpeed.Value);
                        Cr.Compensation_Rule_Dte = dateCompensation.Value;
                        Cr.Crash_Damage = txtDamage.Value;
                        Cr.Crash_Pic = "No picture";
                        Cr.Injures_Employee = DropDown_Employee_injure.SelectedValue;
                        Cr.Crash_Reason = txtReason.Value;
                        Cr.Payed_Employee = dropDown_Employe_Payed.SelectedValue;
                        Cr.Stat = DropDown_state.SelectedValue;
                        Cr.Report_Dte = dateReport.Value;
                        Cr.MIN_DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                        Cr.Local_Plate = DropDown_Plate.SelectedValue;
                        Cr.Tot_Number_Driver_drives = Convert.ToInt32(txtPassenger.Value);
                        Cr.Circumstance = txtCircumstance.Value;
                        Cr.Crash_Info = txtCrashInfo.Value;
                        Cr.Third_Party_Injures = DropDown_thirdParty_injure.SelectedValue;
                        Cr.Final_Report_Dte = dateFinalReport.Value;
                        Cr.Insurance_Declaration_Dte = dateDeclaration.Value;
                        Cr.Claim_Compensation_Amount = Convert.ToDouble(txtAmount.Value);
                        Cr.ThirdParty_Amount_Recovered = Convert.ToDouble(txtThirdPartyRecov.Value);
                        Cr.Employee_Amount_Recovered = Convert.ToDouble(txtRecoverEmpl.Value);
                        Cr.Local_Insurance_Compensation_Amount = Convert.ToDouble(txtLocalComp.Value);
                        Cr.Legal_Cost = Convert.ToDouble(txtLegalCost.Value);
                        Cr.Damage_Description = txtDamageDesipt.Value;
                        Cr.Saved_Date = DateTime.Now.ToString();
                        Cr.Passenger_Comment = txtComment.Value;
                        msg = I.Add(Cr);

                        msg = I.Update(Cr, Convert.ToInt32(id));
                        if (msg > 0)
                        {
                            Response.Redirect("~/FleetApp/ViewCarCrash.aspx");
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;

                        }
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
                I.provide(Cr, Convert.ToInt32(id));

                DropDown_Damage_thirdParty.SelectedValue = Cr.Damage_Third_Party.ToString();
                DropDown_vehicle_Damag.SelectedValue = Cr.Damaged_Vehicle.ToString();
                DropDown_Ministry.SelectedValue = Cr.MINISTRY_ID.ToString();
                dateCrash.Value = Cr.Crash_Date;
                TimeCrash.Value = Cr.Crash_Time;
                txtCondition.Value = Cr.Condition_After_Crash;
                txtAddress.Value = Cr.Full_Crash_Address;
                txtCrashPlace.Value = Cr.Crash_Place;
                txtMeileage.Value = Cr.Crash_Mileage.ToString();
                txtResponible.Value = Cr.Responsible;
                txtWeather.Value = Cr.Weather;
                txtCode.Value = Cr.Crash_Code;
                txtSpeed.Value = Cr.Estimated_Speed.ToString();
                dateCompensation.Value = Cr.Compensation_Rule_Dte.ToString();
                txtDamage.Value = Cr.Damage_Description.ToString();
                DropDown_Employee_injure.SelectedValue = Cr.Injures_Employee;
                txtReason.Value = Cr.Crash_Reason;
                dropDown_Employe_Payed.SelectedValue = Cr.Payed_Employee;
                DropDown_state.SelectedValue = Cr.Stat;
                dateReport.Value = Cr.Report_Dte;
                DropDown_Driver.SelectedValue = Cr.MIN_DRIVER_ID.ToString();
                DropDown_Plate.SelectedValue = Cr.Local_Plate.ToString();
                txtPassenger.Value = Cr.Tot_Number_Driver_drives.ToString();
                txtCircumstance.Value = Cr.Circumstance;
                txtCrashInfo.Value = Cr.Crash_Info.ToString();
                DropDown_thirdParty_injure.SelectedValue = Cr.Third_Party_Injures;
                dateFinalReport.Value = Cr.Final_Report_Dte;
                dateDeclaration.Value = Cr.Insurance_Declaration_Dte.ToString();
                txtAmount.Value = Cr.Claim_Compensation_Amount.ToString();
                txtThirdPartyRecov.Value = Cr.ThirdParty_Amount_Recovered.ToString();
                txtRecoverEmpl.Value = Cr.Employee_Amount_Recovered.ToString();
                txtLocalComp.Value = Cr.Local_Insurance_Compensation_Amount.ToString();
                txtLegalCost.Value = Cr.Legal_Cost.ToString();
                txtDamageDesipt.Value = Cr.Damage_Description.ToString();
                txtComment.Value = Cr.Passenger_Comment;

            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            
            if (id == null)
            {
                Add();
                ChangeStateVehDemage();
            }
            else
                Update();
            ChangeStateVehDemage();
        }
        protected void ActiveGen_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 0;
            MsgInit();
            tabReport.Attributes.Remove("class");
            tabReport.Attributes.Add("class", "nav-link");

            tabSpec.Attributes.Remove("class");
            tabSpec.Attributes.Add("class", "nav-link");

            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link active");
        }
        protected void ActiveReport_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 1;
            MsgInit();
            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link");

            tabSpec.Attributes.Remove("class");
            tabSpec.Attributes.Add("class", "nav-link");

            tabReport.Attributes.Remove("class");
            tabReport.Attributes.Add("class", "nav-link active");
        }
        protected void ActiveSpecific_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 2;
            MsgInit();
            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link");

            tabReport.Attributes.Remove("class");
            tabReport.Attributes.Add("class", "nav-link");

            tabSpec.Attributes.Remove("class");
            tabSpec.Attributes.Add("class", "nav-link active");
        }

        //Genarate Code Vehicle
        string CrashCode()
        {

            if (codeMin == "All")
            {
                return code = "Crash-" + DropDown_Ministry.SelectedItem.ToString().Trim().Substring(0, 3)+(Convert.ToInt32(I.countAll() + 1)) + DateTime.Today.ToString("ddMMyyyy");
            }
            else
            {
                return code = "Crash-"+ DropDown_Ministry.SelectedItem.ToString().Trim().Substring(0, 3) + (Convert.ToInt32(I.count(codeMin) + 1)) +DateTime.Today.ToString("ddMMyyyy");
            }
        }

        //Change state of vehicle demaged when is true ()
        void ChangeStateVehDemage()
        {
            if (DropDown_vehicle_Damag.SelectedValue == "true")
            {
                Imd.UpdateVehUnavailable(DropDown_Plate.SelectedValue);
            }
        }
        void Minisrty()
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

        //Add dropDawn driver Minisrty
        void Driver()
        {
            I.DisplayDriver(DropDown_Driver,DropDown_Plate.SelectedValue);
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle();
            Driver();
        }

        protected void DropDown_Plate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver();
        }


        //Add dropDawn driver Minisrty
        void AllDriver()
        {
            I.DisplayAllDriver(DropDown_Driver);
        }

        //Add dropDawn all Vehicle
        void AllVehicle()
        {
            I.DisplayAllVehicle(DropDown_Plate);
        }
        //Add dropDawn Vehicle
        void Vehicle()
        {
            I.DisplayVehicle(DropDown_Plate, Convert.ToInt32(DropDown_Ministry.SelectedItem.Value));
        }

    }
}