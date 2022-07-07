using System;
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
                DeleteAllVisibility.Visible = false;
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
                        btnEdit.Text = "Detail"; 
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                    }
                    else if (state.Text == "in Progress")
                    {
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                        btnDelete.Enabled = false;

                    }
                    else if (state.Text == "Approved" &&  DateTime.Now.Date >= Convert.ToDateTime(startDat).Date)
                    {
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                    }
                    else if (state.Text == "Approved" && DateTime.Now.Date == Convert.ToDateTime(EndDat).Date)
                    {
                        //I.UpdateStateFinished(Convert.ToInt64(Id));
                        btnEdit.Text = "Detail";
                        btnAppro.Visible = false;
                        btnCancel.Visible = false;

                    }                    
                    else if (state.Text == "Finished")
                    {
                        btnEdit.Text = "Detail";
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
                I.UpdateStateDeny(index,codeMin);
                Response.Redirect("~/FleetApp/ViewLeave.aspx");


            }


        }

        protected void checkSel_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkStatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
            DeleteAllVisibility.Visible = true;
        }
        protected void checkSelHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeader = (CheckBox)gdv.HeaderRow.FindControl("checkSelHeader");
            foreach (GridViewRow row in gdv.Rows)
            {
                CheckBox chkrow = (CheckBox)row.FindControl("checkSel");
                Button btnEdit = (Button)row.FindControl("btn_Edit");
                Button btnDelete = (Button)row.FindControl("Btn_Delete");

                if (chkHeader.Checked == true)
                {
                    chkrow.Checked = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    DeleteAllVisibility.Visible = true;
                    chkHeader.Text = "Deselect All";

                }
                else
                {
                    chkrow.Checked = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    DeleteAllVisibility.Visible = false;
                    chkHeader.Text = " Select All";
                }

            }
        }
        protected void DeleteCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                CheckBox chkdelete = (CheckBox)gdv.Rows[i].Cells[0].FindControl("checkSel");
                if (chkdelete.Checked)
                {
                    int id = Convert.ToInt32(gdv.DataKeys[i].Value);
                    I.Delete(id);
                    gdv.EditIndex = -1;
                }
            }
            getDataGDV();
            DeleteAllVisibility.Visible = false;
        }


        protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdv.PageIndex = e.NewPageIndex;
            this.getDataGDV();
            runGrid();

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
            
        }
    }
}