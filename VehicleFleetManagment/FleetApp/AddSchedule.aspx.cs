using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddSchedule : System.Web.UI.Page
    {
        Schedule_Class  sc = new Schedule_Class ();
        Schedule_Interface I = new Schedule_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["SCHEDULE_ID"];
            ChargeCookies();

            if (!IsPostBack)
            {
                MsgInit();

                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

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

        //Add 
        void Add()
        {
            try
            {
                if (DropDown_Ministry.SelectedValue == "-1" || txtComment.Value == "" || DropDown_Plate.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    sc.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);
                    sc.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    sc.Comment = txtComment.Value;
                    sc.Saved_Date =DateTime.Now.ToString();

                    msg = I.Add(sc);
                    if (msg > 0)
                    {
                        I.Add(sc);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        //DropDown_Plate.SelectedValue= "";
                        //DropDown_Ministry.SelectedValue= "-1";
                        txtComment.Value = "";
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
                if (DropDown_Ministry.SelectedValue == "-1" || txtComment.Value == "" || DropDown_Plate.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    sc.VEHICLE_ID = Convert.ToInt32(DropDown_Plate.SelectedValue);
                    sc.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                    sc.Comment = txtComment.Value;
                    sc.Saved_Date = DateTime.Now.ToString();


                    msg = I.Update(sc, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewSchedule.aspx");
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
                I.provide(sc, Convert.ToInt32(id));

                DropDown_Plate.SelectedValue= sc.VEHICLE_ID.ToString();
                DropDown_Ministry.SelectedValue = sc.MINISTRY_ID.ToString();
                txtComment.Value = sc.Comment;
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