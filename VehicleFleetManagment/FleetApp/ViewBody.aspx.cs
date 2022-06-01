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
    public partial class ViewBody : System.Web.UI.Page
    {
        BodyType_Class Bo = new BodyType_Class();
        BodyType_Interface I = new BodyType_Imp();
        private int msg;
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
        public void getDataGDV()
        {
            I.Display(gdv);
            nbr.Text = I.count().ToString();

        }

        protected void btn_srch_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnReload_click(object sender, EventArgs e)
        {
            getDataGDV();
            txt_Search.Text = "";
        }

        protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/FleetApp/AddBody.aspx?BODY_ID=" + index);

            }
            if (e.CommandName == "delet")
            {
                I.Delete(index);
                Response.Redirect("~/FleetApp/ViewBody.aspx");


            }


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


        protected void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text == "")
                getDataGDV();
            else I.Research(gdv, txt_Search.Text);
        }

        protected void checkSel_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkStatus = (CheckBox)sender;
            GridView row = (GridView)chkStatus.NamingContainer;
        }

        protected void checkSelHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeader = (CheckBox)gdv.HeaderRow.FindControl("checkSelHeader");
            foreach(GridViewRow row in gdv.Rows)
            {
                CheckBox chkrow=(CheckBox)row.FindControl("checkSel");
                if (chkHeader.Checked==true)
                {
                    chkrow.Checked = true;
                }
                else
                {
                    chkrow.Checked= false;
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
                   int id = Convert.ToInt32(gdv.Rows[i].Cells[1].Text);
                    I.DeleteCheck(id);
                    gdv.EditIndex = -1;
                }
            }
        }
    }
}