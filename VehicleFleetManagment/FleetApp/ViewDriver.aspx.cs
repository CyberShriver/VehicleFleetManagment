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
                I.Delete(index);
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
                    Response.Write("<script> alert('The driver may be in Leave');</script>");
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

        protected void DropDown_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataGDV();
            runGrid();
        }
    }
}