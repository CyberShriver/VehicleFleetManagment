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
    public partial class ViewAssurance : System.Web.UI.Page
    {
        Assurance_Class As = new Assurance_Class();
        Assurance_Interface I = new Assurance_Imp();
        private int msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDataGDV();

            }
        }

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
                Response.Redirect("~/FleetApp/AddAssurance.aspx?ASSURANCE_ID=" + index);

            }
            if (e.CommandName == "delet")
            {
                I.Delete(index);
                Response.Redirect("~/FleetApp/ViewAssurance.aspx");


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