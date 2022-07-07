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
    public partial class ViewMinistry : System.Web.UI.Page
    {
        Ministry_Class Min = new Ministry_Class();
        Ministry_Interface I = new Ministry_Imp();
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

            }
        }

        void ChargeCookies()
        {
            if ( Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
            {
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
            }

        }
        // CHARGE GRIDVIEW
        public void getDataGDV()
        {
            I.Display(gdv);
            nbr.Text = I.count().ToString();

        }

        protected void btn_srch_Click(object sender, EventArgs e)
        {
            if (txt_Search.Value == "")
                getDataGDV();
            else I.Research(gdv, txt_Search.Value);
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
                Response.Redirect("~/FleetApp/AddMinistry.aspx?MINISTRY_ID=" + index);

            }
            if (e.CommandName == "delet")
            {
                I.Delete(index);
                Response.Redirect("~/FleetApp/ViewMinistry.aspx");


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

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
        }
    }
}