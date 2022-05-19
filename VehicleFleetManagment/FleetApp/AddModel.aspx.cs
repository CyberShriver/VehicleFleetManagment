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
    public partial class AddModel : System.Web.UI.Page
    {
        Model_Class  M = new Model_Class ();
        Model_Interface I = new Model_Imp();
        int msg;
        string id;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["MODEL_ID"];
            ChargeCookies();

            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MsgInit();
                dropMark();
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
                if (txtModel.Value == "" || txtComment.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {

                    M.Model_Name = txtModel.Value;
                    M.MARK_ID =Convert.ToInt32(DropDown_Mark.SelectedValue);
                    M.Comment = txtComment.Value;

                    msg = I.Add(M);
                    if (msg > 0)
                    {
                        I.Add(M);
                        FillMsg.Visible = false;
                        FailMsg.Visible = false;
                        SuccessMsg.Visible = true;

                        txtModel.Value = "";
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
                if (txtModel.Value == "" || txtComment.Value == "")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    M.Model_Name = txtModel.Value;
                    M.MARK_ID = Convert.ToInt32(DropDown_Mark.SelectedValue);
                    M.Comment = txtComment.Value;

                    msg = I.Update(M, Convert.ToInt32(id));

                    if (msg > 0)
                    {
                        Response.Redirect("~/FleetApp/ViewModel.aspx");
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
                I.provide(M, Convert.ToInt32(id));
          
                txtModel.Value= M.Model_Name;
                DropDown_Mark.SelectedValue= M.MARK_ID.ToString();
                txtComment.Value = M.Comment;
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

        void dropMark()
        {
            I.DisplayMark(DropDown_Mark);
        }

    }
}