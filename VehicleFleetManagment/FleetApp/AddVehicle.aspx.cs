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

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddVehicle : System.Web.UI.Page
    {
        Vehicle_Class Veh = new Vehicle_Class();
        Vehicle_Interface I = new Vehicle_Imp();
        int msg;
        string id;
        string code;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["VEHICLE_ID"];
            if (!IsPostBack)
            {
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

                Minisrty();
               // Fuel();
                Model();
                Body();

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
                if ( txtPlate.Value == "" || txtName.Value == "" || txtColor.Value == "" || txtEngineNumber.Value == "" || txtChassis.Value == "" ||
                    txtEngineManif.Value == "" || txtEnginType.Value == "" || txtEnginSeries.Value == "" || txtEngAltern.Value == "" || txtEngineNumber.Value == "" || txtEngAlternType.Value == "" ||
                    txtEnginCylind.Value == "" || txtEnginPower.Value == "" || txtAssembly.Value == "" || txtGenerWeight.Value == "" || txtVolt.Value == "" || txtKva.Value == "" ||
                    txtEngincc.Value == "" || txtGearBox.Value == "" || txtCondition.Value == "" || txtTankTyp1.Value == "" || txtTankSze1.Value == "" || txtTankTyp2.Value == "" ||
                    txtGrossVehWeigth.Value == "" || txtKeyCode.Value == "" || txtVehiclWeight.Value == "" || txtBatteryVolt.Value == "" || txtFrontSeat.Value == "" || txtTankCapacity2.Value == "" ||
                    txtEmptyPod.Value == "" || txtRadioCode.Value == "" || txtGuaranteeCerticat.Value == "" || dateGuaranteExp.Value == "" || dateCirculationExp.Value == "" || txtStat.Value == "" 
                    || DropDown_Ministry.SelectedValue == "-1" || DropDown_Model.SelectedValue == "-1" || DropDown_Body.SelectedValue == "-1" || DropDown_fuel.SelectedValue == "-1"
                    || DropDown_Trailer.SelectedValue == "-1" || DropDown_lhd_rhd.SelectedValue == "-1" || DropDown_Belt.SelectedValue == "-1" || DropDown_Central_Locking.SelectedValue == "-1"
                    || dropDown_Rear_Lock.SelectedValue == "-1" || DropDown_Forward_Lock.SelectedValue == "-1" || DropDown_Opt_Four_Wheel.SelectedValue == "-1" || DropDown_Air_Conditioner.SelectedValue == "-1"
                    || DropDown_Additional_Heating.SelectedValue == "-1" || DropDown_Additional_Heating.SelectedValue == "-1" || DropDown_Rear_Blake.SelectedValue == "-1" || DropDown_Electronic_Logbook.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Veh.Veh_Code = VehicleCode();
                                Veh.BODY_ID = Convert.ToInt32(DropDown_Body.SelectedValue);
                                Veh.Local_Plate =txtPlate.Value;
                                Veh.MODEL_ID = Convert.ToInt32(DropDown_Model.SelectedValue);
                                Veh.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                                Veh.NameVeh = txtName.Value;
                                Veh.Color = txtColor.Value;
                                Veh.Condition = txtCondition.Value;
                                Veh.Chassis_Num = txtChassis.Value;
                                Veh.Engine_Num = txtEngineNumber.Value;
                                Veh.Engine_Manufacturer = txtEngineManif.Value;
                                Veh.Engine_Type = txtEnginType.Value;
                                Veh.Alternator_Engine_Manufacturer = txtEngAltern.Value;
                                Veh.Alternator_Engine_Type = txtEngAlternType.Value;
                                Veh.Kva =Convert.ToDouble(txtKva.Value);
                                Veh.Volt = txtVolt.Value;
                                Veh.Picture =img;
                                Veh.Generator_Weight = txtGenerWeight.Value;
                                Veh.Trailer = DropDown_Trailer.SelectedValue;
                                Veh.Assembly_Num = txtAssembly.Value;
                                Veh.lhd_rhd = DropDown_lhd_rhd.SelectedValue;
                                Veh.Safety_Belt = DropDown_Belt.SelectedValue;
                                Veh.Gearbox_Type =txtGearBox.Value;
                                Veh.Opt_Four_Wheel = DropDown_Opt_Four_Wheel.SelectedValue;
                                Veh.Central_Locking = DropDown_Central_Locking.SelectedValue;
                                Veh.Rear_Lock = dropDown_Rear_Lock.SelectedValue;
                                Veh.Engine_Series_Num = txtEnginSeries.Value;
                                Veh.Forward_Lock = DropDown_Forward_Lock.SelectedValue;
                                Veh.Engine_cylinder_Number = txtEnginCylind.Value;
                                Veh.Engine_cc = txtEngincc.Value;
                                Veh.Engine_Power =Convert.ToDouble(txtEnginPower.Value);
                                Veh.Fuel_Fype = DropDown_fuel.SelectedValue;
                                Veh.Tank_Type1 = txtTankTyp1.Value;
                                Veh.Tank_Size1 = Convert.ToInt32(txtTankSze1.Value);
                                Veh.Tank_Type2 = txtTankTyp2.Value;
                                Veh.Tank_Capacity2 =Convert.ToInt32(txtTankCapacity2.Value);
                                Veh.Front_Seats_Number =Convert.ToInt32(txtFrontSeat.Value);
                                Veh.Battery_Voltage = Convert.ToDouble(txtBatteryVolt.Value);
                                Veh.Air_Conditioner = DropDown_Air_Conditioner.SelectedValue;
                                Veh.Additional_Heating = DropDown_Additional_Heating.SelectedValue;
                                Veh.Veh_Weight =Convert.ToDouble(txtVehiclWeight.Value);
                                Veh.Gross_Veh_Weigth =Convert.ToDouble(txtGrossVehWeigth.Value);
                                Veh.Empty_Pod = Convert.ToDouble(txtEmptyPod.Value);
                                Veh.Key_Code = txtKeyCode.Value;
                                Veh.Rear_Blake = DropDown_Rear_Blake.SelectedValue;
                                Veh.Electronic_Logbook = DropDown_Electronic_Logbook.SelectedValue;
                                Veh.Radio_Code =txtRadioCode.Value;
                                Veh.Guaranteed_Expiration_Date = dateGuaranteExp.Value;
                                Veh.Guaranteed_Certificate_Num = txtGuaranteeCerticat.Value;
                                Veh.Circulation_Expiration_Date = dateCirculationExp.Value;
                                Veh.Stat = txtStat.Value;
                                msg = I.Add(Veh);
                                if (msg > 0)
                                {
                                    I.Add(Veh);
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = false;
                                    SuccessMsg.Visible = true;

                                    txtCode.Value = "";
                                    txtPlate.Value = "";
                                    txtName.Value = "";
                                    txtColor.Value = "";
                                    txtEngineNumber.Value = "";
                                    txtChassis.Value = "";
                                    txtEngineManif.Value = "";
                                    txtEnginType.Value = "";
                                    txtEnginSeries.Value = "";
                                    txtEngAltern.Value = "";
                                    txtEngineNumber.Value = "";
                                    txtEngAlternType.Value = "";
                                    txtEnginCylind.Value = "";
                                    txtEnginPower.Value = "";
                                    txtAssembly.Value = "";
                                    txtGenerWeight.Value = "";
                                    txtVolt.Value = "";
                                    txtKva.Value = "";
                                    txtEngincc.Value = "";
                                    txtGearBox.Value = "";
                                    txtCondition.Value = "";
                                    txtTankTyp1.Value = "";
                                    txtTankSze1.Value = "";
                                    txtTankTyp2.Value = "";
                                    txtGrossVehWeigth.Value = "";
                                    txtKeyCode.Value = "";
                                    txtVehiclWeight.Value = "";
                                    txtBatteryVolt.Value = "";
                                    txtFrontSeat.Value = "";
                                    txtTankCapacity2.Value = "";
                                    txtEmptyPod.Value = "";
                                    txtRadioCode.Value = "";
                                    txtGuaranteeCerticat.Value = "";
                                    dateGuaranteExp.Value = "";
                                    dateCirculationExp.Value = "";
                                    txtStat.Value = "";
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
                        Veh.Veh_Code = VehicleCode();
                        Veh.BODY_ID = Convert.ToInt32(DropDown_Body.SelectedValue);
                        Veh.Local_Plate = txtPlate.Value;
                        Veh.MODEL_ID = Convert.ToInt32(DropDown_Model.SelectedValue);
                        Veh.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Veh.NameVeh = txtName.Value;
                        Veh.Color = txtColor.Value;
                        Veh.Condition = txtCondition.Value;
                        Veh.Chassis_Num = txtChassis.Value;
                        Veh.Engine_Num = txtEngineNumber.Value;
                        Veh.Engine_Manufacturer = txtEngineManif.Value;
                        Veh.Engine_Type = txtEnginType.Value;
                        Veh.Alternator_Engine_Manufacturer = txtEngAltern.Value;
                        Veh.Alternator_Engine_Type = txtEngAlternType.Value;
                        Veh.Kva = Convert.ToDouble(txtKva.Value);
                        Veh.Volt = txtVolt.Value;
                        Veh.Picture = "No Picture";
                        Veh.Generator_Weight = txtGenerWeight.Value;
                        Veh.Trailer = DropDown_Trailer.SelectedValue;
                        Veh.Assembly_Num = txtAssembly.Value;
                        Veh.lhd_rhd = DropDown_lhd_rhd.SelectedValue;
                        Veh.Safety_Belt = DropDown_Belt.SelectedValue;
                        Veh.Gearbox_Type = txtGearBox.Value;
                        Veh.Opt_Four_Wheel = DropDown_Opt_Four_Wheel.SelectedValue;
                        Veh.Central_Locking = DropDown_Central_Locking.SelectedValue;
                        Veh.Rear_Lock = dropDown_Rear_Lock.SelectedValue;
                        Veh.Engine_Series_Num = txtEnginSeries.Value;
                        Veh.Forward_Lock = DropDown_Forward_Lock.SelectedValue;
                        Veh.Engine_cylinder_Number = txtEnginCylind.Value;
                        Veh.Engine_cc = txtEngincc.Value;
                        Veh.Engine_Power = Convert.ToDouble(txtEnginPower.Value);
                        Veh.Fuel_Fype = DropDown_fuel.SelectedValue;
                        Veh.Tank_Type1 = txtTankTyp1.Value;
                        Veh.Tank_Size1 = Convert.ToInt32(txtTankSze1.Value);
                        Veh.Tank_Type2 = txtTankTyp2.Value;
                        Veh.Tank_Capacity2 = Convert.ToInt32(txtTankCapacity2.Value);
                        Veh.Front_Seats_Number = Convert.ToInt32(txtFrontSeat.Value);
                        Veh.Battery_Voltage = Convert.ToDouble(txtBatteryVolt.Value);
                        Veh.Air_Conditioner = DropDown_Air_Conditioner.SelectedValue;
                        Veh.Additional_Heating = DropDown_Additional_Heating.SelectedValue;
                        Veh.Veh_Weight = Convert.ToDouble(txtVehiclWeight.Value);
                        Veh.Gross_Veh_Weigth = Convert.ToDouble(txtGrossVehWeigth.Value);
                        Veh.Empty_Pod = Convert.ToDouble(txtEmptyPod.Value);
                        Veh.Key_Code = txtKeyCode.Value;
                        Veh.Rear_Blake = DropDown_Rear_Blake.SelectedValue;
                        Veh.Electronic_Logbook = DropDown_Electronic_Logbook.SelectedValue;
                        Veh.Radio_Code = txtRadioCode.Value;
                        Veh.Guaranteed_Expiration_Date = dateGuaranteExp.Value;
                        Veh.Guaranteed_Certificate_Num = txtGuaranteeCerticat.Value;
                        Veh.Circulation_Expiration_Date = dateCirculationExp.Value;
                        Veh.Stat = txtStat.Value;
                        msg = I.Add(Veh);
                        if (msg > 0)
                        {
                            I.Add(Veh);
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                            txtCode.Value = "";
                            txtPlate.Value = "";
                            txtName.Value = "";
                            txtColor.Value = "";
                            txtEngineNumber.Value = "";
                            txtChassis.Value = "";
                            txtEngineManif.Value = "";
                            txtEnginType.Value = "";
                            txtEnginSeries.Value = "";
                            txtEngAltern.Value = "";
                            txtEngineNumber.Value = "";
                            txtEngAlternType.Value = "";
                            txtEnginCylind.Value = "";
                            txtEnginPower.Value = "";
                            txtAssembly.Value = "";
                            txtGenerWeight.Value = "";
                            txtVolt.Value = "";
                            txtKva.Value = "";
                            txtEngincc.Value = "";
                            txtGearBox.Value = "";
                            txtCondition.Value = "";
                            txtTankTyp1.Value = "";
                            txtTankSze1.Value = "";
                            txtTankTyp2.Value = "";
                            txtGrossVehWeigth.Value = "";
                            txtKeyCode.Value = "";
                            txtVehiclWeight.Value = "";
                            txtBatteryVolt.Value = "";
                            txtFrontSeat.Value = "";
                            txtTankCapacity2.Value = "";
                            txtEmptyPod.Value = "";
                            txtRadioCode.Value = "";
                            txtGuaranteeCerticat.Value = "";
                            dateGuaranteExp.Value = "";
                            dateCirculationExp.Value = "";
                            txtStat.Value = "";
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
                if ( txtPlate.Value == "" || txtName.Value == "" || txtColor.Value == "" || txtEngineNumber.Value == "" || txtChassis.Value == "" ||
                    txtEngineManif.Value == "" || txtEnginType.Value == "" || txtEnginSeries.Value == "" || txtEngAltern.Value == "" || txtEngineNumber.Value == "" || txtEngAlternType.Value == "" ||
                    txtEnginCylind.Value == "" || txtEnginPower.Value == "" || txtAssembly.Value == "" || txtGenerWeight.Value == "" || txtVolt.Value == "" || txtKva.Value == "" ||
                    txtEngincc.Value == "" || txtGearBox.Value == "" || txtCondition.Value == "" || txtTankTyp1.Value == "" || txtTankSze1.Value == "" || txtTankTyp2.Value == "" ||
                    txtGrossVehWeigth.Value == "" || txtKeyCode.Value == "" || txtVehiclWeight.Value == "" || txtBatteryVolt.Value == "" || txtFrontSeat.Value == "" || txtTankCapacity2.Value == "" ||
                    txtEmptyPod.Value == "" || txtRadioCode.Value == "" || txtGuaranteeCerticat.Value == "" || dateGuaranteExp.Value == "" || dateCirculationExp.Value == "" || txtStat.Value == ""
                    || DropDown_Ministry.SelectedValue == "-1" || DropDown_Model.SelectedValue == "-1" || DropDown_Body.SelectedValue == "-1" || DropDown_fuel.SelectedValue == "-1"
                    || DropDown_Trailer.SelectedValue == "-1" || DropDown_lhd_rhd.SelectedValue == "-1" || DropDown_Belt.SelectedValue == "-1" || DropDown_Central_Locking.SelectedValue == "-1"
                    || dropDown_Rear_Lock.SelectedValue == "-1" || DropDown_Forward_Lock.SelectedValue == "-1" || DropDown_Opt_Four_Wheel.SelectedValue == "-1" || DropDown_Air_Conditioner.SelectedValue == "-1"
                    || DropDown_Additional_Heating.SelectedValue == "-1" || DropDown_Additional_Heating.SelectedValue == "-1" || DropDown_Rear_Blake.SelectedValue == "-1" || DropDown_Electronic_Logbook.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Veh.Veh_Code = VehicleCode();
                                Veh.BODY_ID = Convert.ToInt32(DropDown_Body.SelectedValue);
                                Veh.Local_Plate = txtPlate.Value;
                                Veh.MODEL_ID = Convert.ToInt32(DropDown_Model.SelectedValue);
                                Veh.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                                Veh.NameVeh = txtName.Value;
                                Veh.Color = txtColor.Value;
                                Veh.Condition = txtCondition.Value;
                                Veh.Chassis_Num = txtChassis.Value;
                                Veh.Engine_Num = txtEngineNumber.Value;
                                Veh.Engine_Manufacturer = txtEngineManif.Value;
                                Veh.Engine_Type = txtEnginType.Value;
                                Veh.Alternator_Engine_Manufacturer = txtEngAltern.Value;
                                Veh.Alternator_Engine_Type = txtEngAlternType.Value;
                                Veh.Kva = Convert.ToDouble(txtKva.Value);
                                Veh.Volt = txtVolt.Value;
                                Veh.Picture = img;
                                Veh.Generator_Weight = txtGenerWeight.Value;
                                Veh.Trailer = DropDown_Trailer.SelectedValue;
                                Veh.Assembly_Num = txtAssembly.Value;
                                Veh.lhd_rhd = DropDown_lhd_rhd.SelectedValue;
                                Veh.Safety_Belt = DropDown_Belt.SelectedValue;
                                Veh.Gearbox_Type = txtGearBox.Value;
                                Veh.Opt_Four_Wheel = DropDown_Opt_Four_Wheel.SelectedValue;
                                Veh.Central_Locking = DropDown_Central_Locking.SelectedValue;
                                Veh.Rear_Lock = dropDown_Rear_Lock.SelectedValue;
                                Veh.Engine_Series_Num = txtEnginSeries.Value;
                                Veh.Forward_Lock = DropDown_Forward_Lock.SelectedValue;
                                Veh.Engine_cylinder_Number = txtEnginCylind.Value;
                                Veh.Engine_cc = txtEngincc.Value;
                                Veh.Engine_Power = Convert.ToDouble(txtEnginPower.Value);
                                Veh.Fuel_Fype = DropDown_fuel.SelectedValue;
                                Veh.Tank_Type1 = txtTankTyp1.Value;
                                Veh.Tank_Size1 = Convert.ToInt32(txtTankSze1.Value);
                                Veh.Tank_Type2 = txtTankTyp2.Value;
                                Veh.Tank_Capacity2 = Convert.ToInt32(txtTankCapacity2.Value);
                                Veh.Front_Seats_Number = Convert.ToInt32(txtFrontSeat.Value);
                                Veh.Battery_Voltage = Convert.ToDouble(txtBatteryVolt.Value);
                                Veh.Air_Conditioner = DropDown_Air_Conditioner.SelectedValue;
                                Veh.Additional_Heating = DropDown_Additional_Heating.SelectedValue;
                                Veh.Veh_Weight = Convert.ToDouble(txtVehiclWeight.Value);
                                Veh.Gross_Veh_Weigth = Convert.ToDouble(txtGrossVehWeigth.Value);
                                Veh.Empty_Pod = Convert.ToDouble(txtEmptyPod.Value);
                                Veh.Key_Code = txtKeyCode.Value;
                                Veh.Rear_Blake = DropDown_Rear_Blake.SelectedValue;
                                Veh.Electronic_Logbook = DropDown_Electronic_Logbook.SelectedValue;
                                Veh.Radio_Code = txtRadioCode.Value;
                                Veh.Guaranteed_Expiration_Date = dateGuaranteExp.Value;
                                Veh.Guaranteed_Certificate_Num = txtGuaranteeCerticat.Value;
                                Veh.Circulation_Expiration_Date = dateCirculationExp.Value;
                                Veh.Stat = txtStat.Value;
                                msg = I.Update(Veh, Convert.ToInt32(id));
                                if (msg > 0)
                                {
                                    Response.Redirect("~/FleetApp/ViewVehicle.aspx");
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
                        Veh.Veh_Code = VehicleCode();
                        Veh.BODY_ID = Convert.ToInt32(DropDown_Body.SelectedValue);
                        Veh.Local_Plate = txtPlate.Value;
                        Veh.MODEL_ID = Convert.ToInt32(DropDown_Model.SelectedValue);
                        Veh.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Veh.NameVeh = txtName.Value;
                        Veh.Color = txtColor.Value;
                        Veh.Condition = txtCondition.Value;
                        Veh.Chassis_Num = txtChassis.Value;
                        Veh.Engine_Num = txtEngineNumber.Value;
                        Veh.Engine_Manufacturer = txtEngineManif.Value;
                        Veh.Engine_Type = txtEnginType.Value;
                        Veh.Alternator_Engine_Manufacturer =txtEngAltern.Value;
                        Veh.Alternator_Engine_Type = txtEngAlternType.Value;
                        Veh.Kva = Convert.ToDouble(txtKva.Value);
                        Veh.Volt = txtVolt.Value;
                        Veh.Picture = "No Picture";
                        Veh.Generator_Weight = txtGenerWeight.Value;
                        Veh.Trailer = DropDown_Trailer.SelectedValue;
                        Veh.Assembly_Num = txtAssembly.Value;
                        Veh.lhd_rhd = DropDown_lhd_rhd.SelectedValue;
                        Veh.Safety_Belt = DropDown_Belt.SelectedValue;
                        Veh.Gearbox_Type = txtGearBox.Value;
                        Veh.Opt_Four_Wheel = DropDown_Opt_Four_Wheel.SelectedValue;
                        Veh.Central_Locking = DropDown_Central_Locking.SelectedValue;
                        Veh.Rear_Lock = dropDown_Rear_Lock.SelectedValue;
                        Veh.Engine_Series_Num = txtEnginSeries.Value;
                        Veh.Forward_Lock = DropDown_Forward_Lock.SelectedValue;
                        Veh.Engine_cylinder_Number = txtEnginCylind.Value;
                        Veh.Engine_cc = txtEngincc.Value;
                        Veh.Engine_Power = Convert.ToDouble(txtEnginPower.Value);
                        Veh.Fuel_Fype = DropDown_fuel.SelectedValue;
                        Veh.Tank_Type1 = txtTankTyp1.Value;
                        Veh.Tank_Size1 = Convert.ToInt32(txtTankSze1.Value);
                        Veh.Tank_Type2 = txtTankTyp2.Value;
                        Veh.Tank_Capacity2 = Convert.ToInt32(txtTankCapacity2.Value);
                        Veh.Front_Seats_Number = Convert.ToInt32(txtFrontSeat.Value);
                        Veh.Battery_Voltage = Convert.ToDouble(txtBatteryVolt.Value);
                        Veh.Air_Conditioner = DropDown_Air_Conditioner.SelectedValue;
                        Veh.Additional_Heating = DropDown_Additional_Heating.SelectedValue;
                        Veh.Veh_Weight = Convert.ToDouble(txtVehiclWeight.Value);
                        Veh.Gross_Veh_Weigth = Convert.ToDouble(txtGrossVehWeigth.Value);
                        Veh.Empty_Pod = Convert.ToDouble(txtEmptyPod.Value);
                        Veh.Key_Code = txtKeyCode.Value;
                        Veh.Rear_Blake = DropDown_Rear_Blake.SelectedValue;
                        Veh.Electronic_Logbook = DropDown_Electronic_Logbook.SelectedValue;
                        Veh.Radio_Code = txtRadioCode.Value;
                        Veh.Guaranteed_Expiration_Date = dateGuaranteExp.Value;
                        Veh.Guaranteed_Certificate_Num = txtGuaranteeCerticat.Value;
                        Veh.Circulation_Expiration_Date = dateCirculationExp.Value;
                        Veh.Stat = txtStat.Value;
                        msg = I.Update(Veh, Convert.ToInt32(id));
                        if (msg > 0)
                        {
                            Response.Redirect("~/FleetApp/ViewVehicle.aspx");
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
                I.provide(Veh, Convert.ToInt32(id));

                txtCode.Value = Veh.Veh_Code;
                DropDown_Body.SelectedValue = Veh.BODY_ID.ToString();
                txtPlate.Value = Veh.Local_Plate;
                DropDown_Model.SelectedValue = Veh.MODEL_ID.ToString();
                DropDown_Ministry.SelectedValue = Veh.MINISTRY_ID.ToString();
                txtName.Value = Veh.NameVeh;
                txtColor.Value = Veh.Color;
                txtCondition.Value = Veh.Condition;
                txtChassis.Value = Veh.Chassis_Num;
                txtEngineNumber.Value = Veh.Engine_Num;
                txtEngineManif.Value = Veh.Engine_Manufacturer;
                txtEnginType.Value = Veh.Engine_Type;
                txtEngineManif.Value = Veh.Alternator_Engine_Manufacturer;
                txtEngAlternType.Value = Veh.Alternator_Engine_Type;
                txtKva.Value = Veh.Kva.ToString();
                txtVolt.Value = Veh.Volt.ToString();
                // Veh.Picture = img;
                txtGenerWeight.Value = Veh.Generator_Weight;
                DropDown_Trailer.SelectedValue = Veh.Trailer;
                txtAssembly.Value = Veh.Assembly_Num;
                DropDown_lhd_rhd.SelectedValue = Veh.lhd_rhd;
                DropDown_Belt.SelectedValue = Veh.Safety_Belt;
                txtGearBox.Value = Veh.Gearbox_Type;
                DropDown_Opt_Four_Wheel.SelectedValue = Veh.Opt_Four_Wheel;
                DropDown_Central_Locking.SelectedValue = Veh.Central_Locking;
                dropDown_Rear_Lock.SelectedValue = Veh.Rear_Lock;
                txtEnginSeries.Value = Veh.Engine_Series_Num;
                DropDown_Forward_Lock.SelectedValue = Veh.Forward_Lock;
                txtEnginCylind.Value = Veh.Engine_cylinder_Number;
                txtEngincc.Value = Veh.Engine_cc;
                txtEnginPower.Value = Veh.Engine_Power.ToString();
                DropDown_fuel.SelectedValue = Veh.Fuel_Fype;
                txtTankTyp1.Value = Veh.Tank_Type1;
                txtTankSze1.Value = Veh.Tank_Size1.ToString();
                txtTankTyp2.Value = Veh.Tank_Type2;
                txtTankCapacity2.Value = Veh.Tank_Capacity2.ToString();
                txtFrontSeat.Value = Veh.Front_Seats_Number.ToString();
                txtBatteryVolt.Value = Veh.Battery_Voltage.ToString();
                DropDown_Air_Conditioner.SelectedValue = Veh.Air_Conditioner;
                DropDown_Additional_Heating.SelectedValue = Veh.Additional_Heating;
                txtVehiclWeight.Value = Veh.Veh_Weight.ToString();
                txtGrossVehWeigth.Value = Veh.Gross_Veh_Weigth.ToString();
                txtEmptyPod.Value = Veh.Empty_Pod.ToString();
                txtKeyCode.Value = Veh.Key_Code;
                DropDown_Rear_Blake.SelectedValue = Veh.Rear_Blake;
                DropDown_Electronic_Logbook.SelectedValue = Veh.Electronic_Logbook;
                txtRadioCode.Value = Veh.Radio_Code;
                dateGuaranteExp.Value = Veh.Guaranteed_Expiration_Date;
                txtGuaranteeCerticat.Value = Veh.Guaranteed_Certificate_Num;
                dateCirculationExp.Value = Veh.Circulation_Expiration_Date;
                txtStat.Value = Veh.Stat;
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

        //Genarate Code Vehicle
        string VehicleCode()
        {
            return code =DropDown_Ministry.SelectedItem.ToString().Trim()+"-Veh-"+(Convert.ToInt32(I.count() + 1)) + "/" + DateTime.Now.Year;
        }
        void Minisrty()
        {
            I.DisplayMinistry(DropDown_Ministry);
        }

        void Model()
        {
            I.DisplayModel(DropDown_Model);
        }

        void Body()
        {
            I.DisplayBodyType(DropDown_Body);
        }

       // void Fuel()
       // {
       //     I.DisplayFuel(DropDown_fuel);
        //}
    }
}