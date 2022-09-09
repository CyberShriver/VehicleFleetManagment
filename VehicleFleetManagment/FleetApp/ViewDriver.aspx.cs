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
    public partial class ViewDriver : System.Web.UI.Page
    {
        Driver_Class Dr = new Driver_Class();
        Driver_Interface I = new Driver_Imp();
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
                filterVisibility.Visible = false;
              //  btn_Edit.InnerText = "Edit";



            }
            else if(codeMin!="All" && DropDown_Filter.SelectedValue== "Free Agents")
            {
                I.Display(gdv);
                nbr.Text = I.count().ToString();
                filterVisibility.Visible = true;
               // btn_Edit.InnerText = "Add";
            }
            else
            {
                I.DisplayMinistryDriver(gdv, codeMin);
                nbr.Text = I.countMinistryDrivers(codeMin).ToString();
                filterVisibility.Visible = true;
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
                else I.Research(gdv,txt_Search.Value);
            }
        }
        protected void btnReload_click(object sender, EventArgs e)
        {
            getDataGDV();
            txt_Search.Value = "";
        }

        protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int index = Convert.ToInt32(e.CommandArgument);
          
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/FleetApp/AddDriver.aspx?DRIVER_ID=" + index);               

            }
            if (e.CommandName == "delet")
            {
                I.DeleteState(index);
                Response.Redirect("~/FleetApp/ViewDriver.aspx");

            }
            if (e.CommandName == "fired")
            {
                 msg=I.UpdateMinistryWorkStateEmpty(index);
                if (msg == 1)
                {
                Response.Redirect("~/FleetApp/ViewDriver.aspx");
                }
                else
                {
                    FailMsg.Visible = true;
                }


            }


        }

        //run All gridView
        void runGrid()
        {
            foreach (GridViewRow row in this.gdv.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btnEdit = (Button)row.FindControl("btn_Edit");
                    Button btnDelete = (Button)row.FindControl("Btn_Delete");
                    Button btnFired = (Button)row.FindControl("Btn_Fired");
                    Label state = (Label)row.FindControl("Label11144");
                    Label minWork = (Label)row.FindControl("LblMinistryWork");
                    if (state.Text =="Free" && minWork.Text=="")
                    {
                        btnFired.Visible = false;
                        btnDelete.Visible = false;
                    }
               
                }
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
                    I.DeleteState(id);
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

        protected void DropDown_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataGDV();
            runGrid();
        }
    }
}