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