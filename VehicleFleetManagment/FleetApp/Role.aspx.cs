using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetImp;
using VehicleFleetManagment.FleetClass;
using System.Data.SqlClient;

namespace VehicleFleetManagment.FleetApp
{
    public partial class Role : System.Web.UI.Page
    {
        Role_Class Ro = new Role_Class();
        Role_Interface Ir = new Role_Imp();

        private int msg;
        string systemTitle, codeMin, systemName;
        string slogan;
        string id;


        protected void Page_Load(object sender, EventArgs e)
        {

            ChargeCookies();
            id = Request.QueryString["ROLE_ID"];

            if (!IsPostBack)
            {
                txtSystemTitle.Text = systemTitle;
                txtSlogan.Text = slogan;


                MsgInitRole();
                ChargeDataRole();
                getDataGDVRole();

                if (id == null)
                {
                    btnSaveRole.InnerText = "Save";
                }
                else
                {
                    btnSaveRole.InnerText = "Edit";
                    getDataGDVRole();
                }
            }
        }
            //CHARGE THE COOKIES
            void ChargeCookies()
            {


                if (Request.Cookies["Code_Min"] != null && Request.Cookies["Slogan"] != null)
                {
                    codeMin = Request.Cookies["Code_Min"].Value;
                    systemTitle = Request.Cookies["System_Title"].Value;
                    systemName = Request.Cookies["System_Name"].Value;
                    slogan = Request.Cookies["Slogan"].Value;
                }

            }
            // MESSAGES Role
            private void MsgInitRole()
            {
                successMsgRole.Visible = false;
                EmptyRoleMsg.Visible = false;
                failMsgRole.Visible = false;
            }

            public void getDataGDVRole()
            {

                Ir.Display(gdv);
                nbr.Text = Ir.count().ToString();


            }

            //Add 
            void Add_Role()
            {
                try
                {
                    if (txtRole.Value == "" || txtDescript.Value == "")
                    {
                        EmptyRoleMsg.Visible = true;
                        failMsgRole.Visible = false;
                        successMsgRole.Visible = false;
                    }
                    else
                    {

                        Ro.Role_Name = txtRole.Value;
                        Ro.Descrept = txtDescript.Value;

                        msg = Ir.Add(Ro);
                        if (msg > 0)
                        {
                            EmptyRoleMsg.Visible = false;
                            failMsgRole.Visible = false;
                            successMsgRole.Visible = true;

                            txtRole.Value = "";
                            txtDescript.Value = "";
                        }
                        else
                        {
                            EmptyRoleMsg.Visible = false;
                            failMsgRole.Visible = true;
                            successMsgRole.Visible = false;

                        }
                    }
                }
                catch (SqlException e)
                {
                    EmptyRoleMsg.Visible = false;
                    failMsgRole.Visible = true;
                    successMsgRole.Visible = false;
                }
            }

            //update
            void Update_Role()
            {
                try
                {
                    if (txtRole.Value == "" || txtDescript.Value == "")
                    {
                        EmptyRoleMsg.Visible = true;
                        failMsgRole.Visible = false;
                        successMsgRole.Visible = false;
                    }
                    else
                    {
                        Ro.Role_Name = txtRole.Value;
                        Ro.Descrept = txtDescript.Value;

                        msg = Ir.Update(Ro, Convert.ToInt32(id));

                        if (msg > 0)
                        {
                            Response.Redirect("~/FleetApp/Role.aspx");
                        }
                        else
                        {
                            EmptyRoleMsg.Visible = false;
                            failMsgRole.Visible = true;
                            successMsgRole.Visible = false;

                        }
                    }
                }
                catch (SqlException e)
                {
                    EmptyRoleMsg.Visible = false;
                    failMsgRole.Visible = true;
                    successMsgRole.Visible = false;
                }
            }

            protected void ChargeDataRole()
            {
                if (id != null)
                {
                    Ir.provide(Ro, Convert.ToInt32(id));
                    txtRole.Value = Ro.Role_Name;
                    txtDescript.Value = Ro.Descrept;
                }
            }

            protected void btn_save_role_Click(object sender, EventArgs args)
            {
                if (id == null)
                {
                    Add_Role();
                    getDataGDVRole();
                }
                else
                    Update_Role();
                getDataGDVRole();
            }

            protected void btn_srch_Click(object sender, EventArgs e)
            {
            if (txt_Search.Value == "")
            {
                getDataGDVRole();
                txtSearchResult.Text = gdv.Rows.Count.ToString();
                CountserchResult.Visible = false;
                records.Visible = true;
            }
            else
            {
                gdv.PageSize = 200;
                Ir.Research(gdv, txt_Search.Value);
                txtSearchResult.Text = gdv.Rows.Count.ToString();
                CountserchResult.Visible = true;
                records.Visible = false;
            }
        }

            protected void btnReload_click(object sender, EventArgs e)
            {
            getDataGDVRole();
            txt_Search.Value = "";
            CountserchResult.Visible = false;
            records.Visible = true;
            gdv.PageSize = 10;
        }

            protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
            {

                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "edit")
                {
                    Response.Redirect("~/FleetApp/Role.aspx?ROLE_ID=" + index);
                    getDataGDVRole();

                }
                if (e.CommandName == "delet")
                {
                    Ir.DeleteState(index);
                    Response.Redirect("~/FleetApp/Role.aspx");
                    getDataGDVRole();
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
                        Ir.DeleteState(id);
                        gdv.EditIndex = -1;
                    }
                }
                getDataGDVRole();
                DeleteAllVisibility.Visible = false;
            }

            protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                gdv.PageIndex = e.NewPageIndex;
                this.getDataGDVRole();

            }

            protected void gdv_PreRender(object sender, EventArgs e)
            {
                indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
            }

        }
    }