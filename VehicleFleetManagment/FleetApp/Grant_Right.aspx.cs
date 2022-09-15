using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class Grant_Right : System.Web.UI.Page
    {
        Grant_Class Gr = new Grant_Class();
        Grant_Class Gra = new Grant_Class();
        Grant_Interface IG = new Grant_Imp();

        Leave_Class Le = new Leave_Class();
        Leave_Interface I = new Leave_Imp();

        Menu_Class M = new Menu_Class();
        Menu_Interface IM = new Menu_Imp();

        Role_Interface IR = new Role_Imp();
        
        private int msg;
        string codeMin;
        string sytemTitle;
        string slogan;

        int info; static int id, idpers, idmenu;
        static int n;
        static string nme;
        string nm, usrnm, IdMin,rol;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();

            if (!IsPostBack)
            {
                Ministry();
                role();
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
                getDataGDV();
                MsgInit();

            }
        }

        void ChargeCookies()
        {
            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null || Request.Cookies["MINISTRY_ID"] != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
                IdMin = Request.Cookies["MINISTRY_ID"].Value;
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
            }     
        
        }

        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
            ExistMsg.Visible = false;
        }

        public void getDataGDV()
        {
           
            IM.Display(gdv);
            nbr.Text = IG.count().ToString();
            IR.DropdownRole(DropDown_Role);
            MsgInit();

        }

        protected void btn_srch_Click(object sender, EventArgs e)
        {
            if (txt_Search.Value == "")
            {
                getDataGDV();

            }
            else { 
                IG.Research(gdv, txt_Search.Value);
                MsgInit();
            }
        }

        protected void gdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            if (e.CommandName == "updat")
            {
                if (DropDown_Role.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    ExistMsg.Visible = false;
                    FailMsg.Visible = false;

                }
                else
                {
                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                    Label MenuName = (Label)row.FindControl("Label2");
                    CheckBox chkb = (CheckBox)row.FindControl("checkSel");

                    IM.DisplayDetails(MenuName.Text, M);

                    idmenu = Convert.ToInt32(M.Menu_Code);

                    IG.DisplayDetails(Convert.ToInt32(DropDown_Role.SelectedValue), Convert.ToInt32(M.Menu_Code), Convert.ToInt32(DropDown_Ministry.SelectedValue), Gr);
                    if (Gr.Menu_Code > 0)
                    {
                        //if this line already exist ,update it
                        if (chkb.Checked == true)
                            Gra.Access = "ON";
                        else Gra.Access = "OFF";

                        info = IG.UPDATE(Convert.ToInt32(DropDown_Role.SelectedValue), Convert.ToInt32(M.Menu_Code), Convert.ToInt32(DropDown_Ministry.SelectedValue), Gra);
                        if (info == 1)
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;
                            ExistMsg.Visible = false;

                        }
                        else
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = false;
                            ExistMsg.Visible = true;

                        }
                    }
                    else
                    {
                        //If not exist,grant it
                        Gra.Menu_Code = Convert.ToInt64(idmenu);
                        //Gra.MINISTRY_ID = Convert.ToInt32(IdMin);
                        Gra.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                        Gra.ROLE_ID = Convert.ToInt64(DropDown_Role.SelectedValue);

                        if (chkb.Checked == true)
                            Gra.Access = "ON";
                        else Gra.Access = "OFF";

                        info = IG.Add(Gra);

                        if (info == 1)
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;
                            ExistMsg.Visible = false;

                        }
                        else
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = false;
                            ExistMsg.Visible = true;

                        }

                    }


                }

            }

        }
  
        protected void gdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdv.PageIndex = e.NewPageIndex;
            this.getDataGDV();
            role();
            MsgInit();

        }

        protected void gdv_PreRender(object sender, EventArgs e)
        {
            indexFooter.Text = "Page " + (gdv.PageIndex + 1).ToString() + " of " + gdv.PageCount.ToString();
        }

        void Ministry()
        {
            if (codeMin == "Min-7/2022")
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
        void role()
        {
            IG.DisplayMinistryRole(DropDown_Role,Convert.ToInt32(DropDown_Ministry.SelectedValue));
        }
        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {

            role();
        }
    }
}