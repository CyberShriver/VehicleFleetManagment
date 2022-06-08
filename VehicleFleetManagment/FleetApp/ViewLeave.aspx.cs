﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class ViewLeave : System.Web.UI.Page
    {
        Leave_Class Le = new Leave_Class();
        Leave_Interface I = new Leave_Imp();
        private int msg;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();

            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
                getDataGDV();
                runGrid();

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
        public void getDataGDV()
        {
            if (codeMin == "All")
            {
                I.DisplayAll(gdv);
                nbr.Text = I.countAll().ToString();
            }
            else
            {
                I.Display(gdv, codeMin);
                nbr.Text = I.count(codeMin).ToString();
            }

        }

        protected void btn_srch_Click(object sender, EventArgs e)
        {
            if (codeMin == "All")
            {
                if (txt_Search.Value == "")
                    getDataGDV();
                else I.ResearchAll(gdv, txt_Search.Value);
            }
            else
            {
                if (txt_Search.Value == "")
                    getDataGDV();
                else I.Research(gdv, codeMin, txt_Search.Value);
            }
        }
        protected void btnReload_click(object sender, EventArgs e)
        {
            getDataGDV();
            txt_Search.Value = "";
        }

         void runGrid()
        {
            foreach(GridViewRow row in this.gdv.Rows){
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btnEdit = (Button)row.FindControl("btn_Edit");
                    Button btnDelete = (Button)row.FindControl("Btn_Delete");
                    Button btnAppro = (Button)row.FindControl("Btn_Approved");
                    Button btnCancel = (Button)row.FindControl("Btn_Cancel");
                    Label state = (Label)row.FindControl("LblState");
                    Label Id = (Label)row.FindControl("lblID");
                    Label startDat = (Label)row.FindControl("LblStartDate");
                    Label EndDat = (Label)row.FindControl("LblEndDate");
                    if (state.Text == "Approved")
                    {
                        btnAppro.Visible = false;
                    }
                    else if(state.Text == "Denied")
                    {
                        btnEdit.Visible = false;
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                    }
                    else if (state.Text == "in Progress")
                    {
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                    }
                    else if (state.Text == "Approved" &&  DateTime.Now.Date >= Convert.ToDateTime(startDat).Date)
                    {
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                    }
                    else if (state.Text == "Approved" && DateTime.Now.Date == Convert.ToDateTime(EndDat).Date)
                    {
                        //I.UpdateStateFinished(Convert.ToInt64(Id));
                        btnEdit.Visible = false;
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;

                    }                    
                    else if (state.Text == "Finished")
                    {
                        btnEdit.Visible = false;
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                    }
                    else
                    {
                        btnEdit.Visible = true;
                        btnAppro.Visible = true;
                        btnCancel.Visible = true;
                        btnDelete.Visible = true;
                    }
                }
            }
        }

        protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/FleetApp/AddLeave.aspx?LEAVE_ID=" + index);

            }
            if (e.CommandName == "delet")
            {
                I.Delete(index);
                Response.Redirect("~/FleetApp/ViewLeave.aspx");


            }
            if (e.CommandName == "Approv")
            {
                I.UpdateStateApproved(index, codeMin);
                Response.Redirect("~/FleetApp/ViewLeave.aspx");


            }
            if (e.CommandName == "cancel")
            {
                I.UpdateStateDeny(index);
                Response.Redirect("~/FleetApp/ViewLeave.aspx");


            }


        }

        protected void DeleteCheck_Click(object sender, EventArgs e)
        {

        }

        protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdv.PageIndex = e.NewPageIndex;
            this.getDataGDV();

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
        }
    }
}