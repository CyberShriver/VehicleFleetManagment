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
    public partial class AddVehicleFuel : System.Web.UI.Page
    {
        VehicleFuelSup_Class Ve = new VehicleFuelSup_Class();
        VehicleFuelSupp_Interface I = new VehicleFuelSupp_Imp();
        int msg;
        string id, codeMin, slogan, sytemTitle, fileImage;
        public string ImgView;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["VEHICLE_FUEL_ID"];
            ChargeCookies();
            file_upd.Attributes["onchange"] = "UploadFile(this)";
            scannedPic.Visible = false;
            checkApprove.Visible = false;
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
                MsgInit();
                Ministry();
                Vehicle();
                fuel();
                Provider();
                GetIpAddress();
                VehicleCategory();
                MaxLiter.Text = returnFuel();
                Session["img"] = null;

                if (id == null)
                {
                    btnSave.InnerText = "Save";
                }
                else

                {
                    btnSave.InnerText = "Edit";
                    ChargeData();
                    Vehicle();
                    VehicleCategory();
                    controlImageIP();
                }              
            }
            else
            {
                if (Session["img"] != null)
                {
                    HttpPostedFile file = (Session["img"] as HttpPostedFile);
                    fileImage = file.FileName;
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
            FuelMsg.Visible = false;
            FailMsg.Visible = false;
            exceedFuelLimit.Visible = false;
            MaxLiterMsg.Visible = false;
        }

        //Add 
        void Add()
        {
            try
            {
                if ( txtFuelUsed.Value == "" || txtOdometer.Value == "" || txtInitQ.Value == "" || txtUnit.Value == "" ||
                     DropDown_Ministry.SelectedValue == "-1" || DropDown_Vehicle.SelectedValue == "-1" ||
                    DropDown_ProviderCode.SelectedValue == "-1" || DropDown_TankType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FuelMsg.Visible = false;
                    FailMsg.Visible = false;
                    exceedFuelLimit.Visible = false;
                    MaxLiterMsg.Visible = false;
                }
               
                    else
                    {
                        Ve.Tank_Code = txtTankCode.Value;
                        Ve.Odometer =Convert.ToDouble(txtOdometer.Value);
                        Ve.Initial_Qty = Convert.ToDouble(txtInitQ.Value);
                        Ve.Consumed_Qty = fuelConsumption();
                        Ve.United_Price = Convert.ToDouble(txtUnit.Value);
                        Ve.Fuel_Used = Convert.ToDouble(txtFuelUsed.Value);
                        Ve.Total_Price = total();
                        Ve.Provider_Code = DropDown_ProviderCode.SelectedValue;
                        Ve.Fuel_Type = DropDown_fuel.SelectedValue;
                        Ve.Liter_100_km = fuelConsumption100Km();
                        Ve.Comment = txtComment.Value;
                        Ve.User_IP_Address =GetIpAddress();
                        Ve.Permission = fileImage;
                        Ve.MINISTRY_ID =Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Ve.Tank_Type = DropDown_TankType.SelectedValue;
                        Ve.Saved_Date = DateTime.Now.Date.ToString();
                        Ve.VEHICLE_ID =Convert.ToInt32(DropDown_Vehicle.SelectedValue);
                        msg = I.Add(Ve);
                        if (msg > 0)
                        {
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        FuelMsg.Visible = false;
                        exceedFuelLimit.Visible = false;
                        SuccessMsg.Visible = true;
                        MaxLiterMsg.Visible = false;

                        txtTankCode.Value = "";
                        txtFuelUsed.Value = "";
                        txtOdometer.Value = "";
                        txtInitQ.Value = "";
                        txtConsumeQ.Value = "";
                        txtUnit.Value = "";
                        txtLiter_100_km.Value = "";
                        txtComment.Value = "";
                        }
                        else
                        {
                        SuccessMsg.Visible = false;
                        FillMsg.Visible = false;
                        FuelMsg.Visible = false;
                        exceedFuelLimit.Visible = false;
                        FailMsg.Visible = true;
                        MaxLiterMsg.Visible = false;

                    }
                    }               
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FuelMsg.Visible = false;
                FailMsg.Visible = true;
                MaxLiterMsg.Visible = false;
            }
        }

        //update
        void Update()
        {
            try
            {
                if (txtFuelUsed.Value == "" || txtOdometer.Value == "" || txtInitQ.Value == "" || txtUnit.Value == "" || 
                     DropDown_Ministry.SelectedValue == "-1" || DropDown_Vehicle.SelectedValue == "-1" ||
                    DropDown_ProviderCode.SelectedValue == "-1" || DropDown_TankType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                    FuelMsg.Visible = false;
                    exceedFuelLimit.Visible = false;
                    MaxLiterMsg.Visible = false;
                }

                else
                {
                    Ve.Tank_Code = txtTankCode.Value;
                    Ve.Odometer = Convert.ToDouble(txtOdometer.Value);
                    Ve.Initial_Qty = Convert.ToDouble(txtInitQ.Value);
                    Ve.Consumed_Qty = fuelConsumption();
                    Ve.United_Price = Convert.ToDouble(txtUnit.Value);
                    Ve.Fuel_Used = Convert.ToDouble(txtFuelUsed.Value);
                    Ve.Total_Price = total();
                    Ve.Provider_Code = DropDown_ProviderCode.SelectedValue;
                    Ve.Fuel_Type = DropDown_fuel.SelectedValue;
                    Ve.Liter_100_km = fuelConsumption100Km();
                    Ve.Comment = txtComment.Value;
                    Ve.User_IP_Address =GetIpAddress();
                    if (Approve.Checked == true) { Ve.Permission = fileImage; } else { Ve.Permission =null; }
                    Ve.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    Ve.Tank_Type = DropDown_TankType.SelectedValue;
                    Ve.Saved_Date = DateTime.Now.Date.ToString();
                    Ve.VEHICLE_ID = Convert.ToInt32(DropDown_Vehicle.SelectedValue);

                    msg = I.Update(Ve,Convert.ToInt32(id));
                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewVehicleFuel.aspx");
                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FillMsg.Visible = false;
                        FuelMsg.Visible = false;
                        exceedFuelLimit.Visible = false;
                        FailMsg.Visible = true;
                        MaxLiterMsg.Visible = false;

                    }
                }
            }
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FuelMsg.Visible = false;
                exceedFuelLimit.Visible = false;
                FailMsg.Visible = true;
                MaxLiterMsg.Visible = false;
            }

        }

        protected void ChargeData()
        {
            if (id != null)
            {
                I.provide(Ve, Convert.ToInt32(id));

                txtTankCode.Value=Ve.Tank_Code ;
                txtOdometer.Value=Ve.Odometer.ToString();
                txtInitQ.Value= Ve.Initial_Qty.ToString();
                txtUnit.Value= Ve.United_Price.ToString();
                txtFuelUsed.Value= Ve.Fuel_Used.ToString();
                DropDown_ProviderCode.SelectedValue= Ve.Provider_Code;
                txtComment.Value= Ve.Comment ;
                clientAddress.Text = Ve.User_IP_Address;
                ImgView = "assets/images/File_Permission/" + Ve.Permission;
                DropDown_Ministry.SelectedValue= Ve.MINISTRY_ID.ToString();
                DropDown_TankType.SelectedValue= Ve.Tank_Type;
                DropDown_fuel.SelectedValue= Ve.Fuel_Type;
                dateSave.Value=DateTime.Now.Date.ToString();
                DropDown_Vehicle.SelectedValue= Ve.VEHICLE_ID.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            if (Convert.ToDouble(txtFuelUsed.Value) >= Convert.ToDouble(txtInitQ.Value))
            {
                if (Convert.ToDouble(txtFuelUsed.Value) <= Convert.ToDouble(returnFuel())) {
                        if (Convert.ToDouble(txtFuelUsed.Value) > 100 && Approve.Checked == true)
                        {
                            if (id == null)
                            {
                                Add();
                            }
                            else
                            {
                            displayPermission.Visible = false;
                            Update();
                            }
                        }
                        else if (Convert.ToDouble(txtFuelUsed.Value) > 100 && Approve.Checked == false)
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            exceedFuelLimit.Visible = true;
                            MaxLiterMsg.Visible = false;
                            FuelMsg.Visible = false;
                            displayPermission.Visible = false;

                            scannedPic.Visible = true;
                            checkApprove.Visible = false;
                        }
                        else
                        {
                            if (id == null)
                            {
                                Add();

                            }
                            else
                            {
                            displayPermission.Visible = false;
                                Update();
                            }
                        }
                    displayPermission.Visible = false;
                }
                else
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = false;
                    FailMsg.Visible = false;
                    exceedFuelLimit.Visible = false;
                    FuelMsg.Visible = false;
                    MaxLiterMsg.Visible = true;
                }
               
            }            
            else
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = false;
                exceedFuelLimit.Visible = false;
                FuelMsg.Visible = true;
                MaxLiterMsg.Visible = false;
            }
           
        }

        // consumed Quantity
        double  fuelConsumption()
        {
            double c = 0;           
            return c = (Convert.ToDouble(txtFuelUsed.Value) - Convert.ToDouble(txtInitQ.Value)); 
        }

        // consumed L/100Km
        double fuelConsumption100Km()
        {
            double c = 0;
            double a = fuelConsumption();
            double b = Convert.ToDouble(txtOdometer.Value);
            return c = Math.Round( (a/b *100),2);
        }

        //Total function
        double total()
        {
            double tot=0;
            if (Convert.ToDouble(txtFuelUsed.Value) >= Convert.ToDouble(txtInitQ.Value))
            {
                double a = fuelConsumption();
                double b = Convert.ToDouble(txtUnit.Value);
                double t = a*b;
                tot = t;
            }
            else
            {
                txtInitQ.Value = "";
                txtConsumeQ.Value = "";
                txtUnit.Value = "";
               
            }
            return tot;
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
            if (codeMin == "All")
            {
                I.DisplayAllVehicle(DropDown_Vehicle);
            }
            else
            {
                I.DisplayVehicle(DropDown_Vehicle,codeMin);
            }
            
        }

        //Add dropDawn Vehicle
        void Provider()
        {
            I.DisplayProvider(DropDown_ProviderCode);
        }

        void fuel()
        {
            I.DisplayFuelType(DropDown_fuel, DropDown_Vehicle.SelectedItem.Text);
        }
        void VehicleCategory()
        {
            I.DisplayVehicleCategory(DropDown_Category, DropDown_Vehicle.SelectedItem.Text);
        }
        protected void DropDown_Vehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            fuel();
            VehicleCategory();
            MaxLiter.Text = returnFuel();
        }

        //limit fuel based on categories
        string returnFuel()
        {
            string categ;
            if (DropDown_Category.SelectedItem.Text=="Compact Car")
            {
                categ = "30";
            }else if (DropDown_Category.SelectedItem.Text == "small lorry truck")
            {
                categ = "40";
            }
            else if(DropDown_Category.SelectedItem.Text == "Van")
            {
                categ = "50";
            }
            else if (DropDown_Category.SelectedItem.Text == "Bus")
            {
                categ = "60";
            }
            else if (DropDown_Category.SelectedItem.Text == "Trailer")
            {
                categ = "150";
            }
            else 
            {
                categ = "200";
            }
            return categ;
        }

        //control check when file is uploaded
        protected void OnCheckedChangedApprove(object sender, EventArgs args)
        {
            
            if (Approve.Checked == true)
            {
                checkApprove.Visible = true;

            }
            else if(Approve.Checked == false && Convert.ToDouble(txtFuelUsed.Value) <= 100)
            {
                checkApprove.Visible = false;
                scannedPic.Visible = false;
            }
            else
            {
                checkApprove.Visible = false;
                scannedPic.Visible = true;
            }
        }

        //upload permission file
        protected void Upload(object sender, EventArgs args)
        {
            if (file_upd.HasFile)
            {
                if (file_upd.PostedFile.ContentLength < 104857600)
                {
                    Session["img"] = file_upd.PostedFile;
                    fileImage = file_upd.PostedFile.FileName;
                    file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/File_Permission/") + Path.GetFileName(file_upd.FileName));
                    Approve.Checked = true;
                    scannedPic.Visible = false;
                    checkApprove.Visible = true;
                    exceedFuelLimit.Visible = false;
                    MaxLiterMsg.Visible = false;
                    InvalidLenght.Visible = false;
                    MaxLiter.Text = returnFuel();
                }
                else
                {
                    InvalidLenght.Visible = true;
                }
            }
            else
            {
                MaxLiter.Text = returnFuel();
                Session["img"] = null;
                fileImage = "";
            }
        }

        //Get Ip  Address of client
        private string GetIpAddress()
        {
            string userip;
            userip = Request.UserHostAddress;
            if (Request.UserHostAddress != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if (macSrc == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                        userip = "Localhost(127.0.0.1)";
                    }
                   return userip;
                }
            }

            return userip;
        }

        void controlImageIP()
        {
            if(id!= null && Ve.User_IP_Address!=null && Ve.Permission !=null)
            {
                displayPermission.Visible = true;
            }
        }


    }
}