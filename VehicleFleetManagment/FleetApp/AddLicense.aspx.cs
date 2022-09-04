using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;
using System.Data.SqlClient;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddLicense : System.Web.UI.Page
    {
        License_Class Li = new License_Class();
        License_Interface I = new License_Imp();
        int msg;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["LICENSE_ID"];
            ChargeCookies();
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                MsgInit();
                Ministry();
                Driver();
                if (id == null)
                {
                    btnSave.InnerText = "Save";
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
            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
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

        void Add()
        {
            try
            {
                if (txtLicenseCode.Value == "" ||  dateExp.Value == ""  ||  category_B.Checked==false || txtIssuedAt.Value == "" || dateIssueOn.Value == ""
                    || txtCrdNum.Value == ""   || category_A.Checked==false || txtIssuedAt.Value == "" || dateIssueOn.Value == ""
                    ||  DropDown_licenseState.SelectedValue == "-1" || DropDown_IssuedAuthority.SelectedValue == "-1"
                    )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Licence/") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {

                                Li.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                                Li.License_Number = txtLicenseCode.Value;
                                Li.International_License_Code = txtInterCode.Value;
                                Li.Inter_License_Code_Exp_Date = dateExpInter.Value;
                                Li.License_Code_Mission = txtCodeMission.Value;
                                Li.Issued_At = txtIssuedAt.Value;
                                Li.Issued_Authority = DropDown_IssuedAuthority.SelectedValue;
                                Li.Issued_On = dateIssueOn.Value;
                                Li.Card_Number =txtCrdNum.Value;
                                Li.Scanned_Picture = img;
                                Li.Exp_Date = dateExp.Value;
                                Li.Saved_Dte = DateTime.Now.ToString();
                                Li.License_Code_Mission_Exp_Dte = dateCodeMissionExp.Value;
                                Li.DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                                if (category_A.Checked == true) { Li.Category_A = "Yes"; } else { Li.Category_A = "No"; }
                                if (category_B.Checked == true) { Li.Category_B = "Yes"; } else { Li.Category_B = "No"; }
                                if (category_C.Checked == true) { Li.Category_C = "Yes"; } else { Li.Category_C = "No"; }
                                if (category_D1.Checked == true) { Li.Category_D1 = "Yes";  } else { Li.Category_D1 = "No";}
                                if (category_D2.Checked == true) { Li.Category_D2 = "Yes"; } else { Li.Category_D2 = "No"; }
                                if (category_E.Checked == true) { Li.Category_E = "Yes";  } else { Li.Category_E = "No"; }
                                if (category_F.Checked == true) { Li.Category_F = "Yes"; } else { Li.Category_F = "No"; }
                                Li.License_State = DropDown_licenseState.SelectedValue;

                                msg = I.Add(Li);
                                if (msg > 0)
                                {
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = false;
                                    SuccessMsg.Visible = true;

                                    txtLicenseCode.Value = "";
                                    txtInterCode.Value = "";
                                    txtCodeMission.Value = "";
                                    txtCrdNum.Value = "";
                                    dateIssueOn.Value = "";
                                    dateExpInter.Value = "";
                                    dateExp.Value = "";


                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                        }
                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FillMsg.Visible = true;
                        FailMsg.Visible = false;
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
                if (txtLicenseCode.Value == "" || dateExp.Value == "" || category_B.Checked == false || txtIssuedAt.Value == "" || dateIssueOn.Value == ""
                    || txtCrdNum.Value == "" || category_A.Checked == false || txtIssuedAt.Value == "" || dateIssueOn.Value == ""
                    || DropDown_licenseState.SelectedValue == "-1" || DropDown_IssuedAuthority.SelectedValue == "-1"
                    )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Licence/") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {

                                Li.MINISTRY_ID = Convert.ToInt32(DropDown_Ministry.SelectedValue);
                                Li.License_Number = txtLicenseCode.Value;
                                Li.International_License_Code = txtInterCode.Value;
                                Li.Inter_License_Code_Exp_Date = dateExpInter.Value;
                                Li.License_Code_Mission = txtCodeMission.Value;
                                Li.Issued_At = txtIssuedAt.Value;
                                Li.Issued_Authority = DropDown_IssuedAuthority.SelectedValue;
                                Li.Issued_On = dateIssueOn.Value;
                                Li.Card_Number = txtCrdNum.Value;
                                Li.Scanned_Picture = img;
                                Li.Exp_Date = dateExp.Value;
                                Li.Saved_Dte = DateTime.Now.ToString();
                                Li.License_Code_Mission_Exp_Dte = dateCodeMissionExp.Value;
                                Li.DRIVER_ID = Convert.ToInt32(DropDown_Driver.SelectedValue);
                                if (category_A.Checked == true) { Li.Category_A = "Yes"; } else { Li.Category_A = "No"; }
                                if (category_B.Checked == true) { Li.Category_B = "Yes"; } else { Li.Category_B = "No"; }
                                if (category_C.Checked == true) { Li.Category_C = "Yes"; } else { Li.Category_C = "No"; }
                                if (category_D1.Checked == true) { Li.Category_D1 = "Yes"; } else { Li.Category_D1 = "No"; }
                                if (category_D2.Checked == true) { Li.Category_D2 = "Yes"; } else { Li.Category_D2 = "No"; }
                                if (category_E.Checked == true) { Li.Category_E = "Yes"; } else { Li.Category_E = "No"; }
                                if (category_F.Checked == true) { Li.Category_F = "Yes"; } else { Li.Category_F = "No"; }
                                Li.License_State = DropDown_licenseState.SelectedValue;

                                msg = I.Update(Li, Convert.ToInt32(id));

                                if (msg > 0)
                                {
                                    Response.Redirect("~/FleetApp/ViewLicense.aspx");
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                        }
                    }
                    else
                    {
                        SuccessMsg.Visible = false;
                        FillMsg.Visible = true;
                        FailMsg.Visible = false;
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
                I.provide(Li, Convert.ToInt32(id));

                DropDown_Ministry.SelectedValue = Li.MINISTRY_ID.ToString();
                txtLicenseCode.Value = Li.License_Number;
                txtInterCode.Value = Li.International_License_Code;
                txtCodeMission.Value = Li.License_Code_Mission;
                txtIssuedAt.Value = Li.Issued_At;
                txtCrdNum.Value = Li.Card_Number;
                dateIssueOn.Value = Li.Issued_On;
                DropDown_IssuedAuthority.SelectedValue = Li.Issued_Authority;
                dateExp.Value = Li.Exp_Date;
                dateExpInter.Value = Li.Inter_License_Code_Exp_Date;
                dateCodeMissionExp.Value = Li.License_Code_Mission_Exp_Dte;
                DropDown_Driver.SelectedItem.Value = Li.DRIVER_ID.ToString();
                if (Li.Category_A == "Yes") { category_A.Checked = true; } else { category_A.Checked = false; }
                if (Li.Category_B == "Yes" ) { category_B.Checked = true; } else { category_B.Checked = false; }
                if (Li.Category_C == "Yes") { category_C.Checked = true; } else { category_C.Checked = false; }
                if (Li.Category_D1 == "Yes") { category_D1.Checked = true; } else { category_D1.Checked = false; }
                if (Li.Category_D2 == "Yes") { category_D2.Checked = true;  } else { category_D2.Checked = false; }
                if (Li.Category_E == "Yes") { category_E.Checked = true; } else { category_E.Checked = false;  }
                if (Li.Category_F == "Yes") { category_F.Checked = true; } else { category_F.Checked = false; }
                DropDown_licenseState.SelectedItem.Value = Li.License_State.ToString();
                Image1.ImageUrl = "~/FleetApp/assets/images/Licence/" + Li.Scanned_Picture;

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

        protected void OnCheckedChanged_D1(object sender, EventArgs args)
        {

            if (category_D1.Checked == true)
            {
                category_A.Checked = true;
                category_B.Checked = true;
                category_C.Checked = true;

            }
            else
            {
                category_D2.Checked = false;
                category_E.Checked = false;
                category_F.Checked = false;
            }
        }
        protected void OnCheckedChanged_D2(object sender, EventArgs args)
        {
            if (category_D2.Checked == true)
            {
                category_A.Checked = true;
                category_B.Checked = true;
                category_C.Checked = true;
                category_D1.Checked = true;

            }
            else
            {
                category_E.Checked = false;
                category_F.Checked = false;
            }
        }
        protected void OnCheckedChanged_C(object sender, EventArgs args)
        {
            if (category_C.Checked == true)
            {
                category_A.Checked = true;
                category_B.Checked = true;

            }
            else
            {
                category_D1.Checked = false;
                category_D2.Checked = false;
                category_E.Checked = false;
                category_F.Checked = false;
            }
        }
        protected void OnCheckedChanged_B(object sender, EventArgs args)
        {

            if (category_B.Checked == true)
            {
                category_A.Checked = true;
            }
            else
            {
                category_C.Checked = false;
                category_D1.Checked = false;
                category_D2.Checked = false;
                category_E.Checked = false;
                category_F.Checked = false;
            }
        }
        protected void OnCheckedChanged_A(object sender, EventArgs args)
        {

            if (category_A.Checked == false)
            {
                category_B.Checked = false;
                category_C.Checked = false;
                category_D1.Checked = false;
                category_D2.Checked = false;
                category_E.Checked = false;
                category_F.Checked = false;
            }
        }
        protected void OnCheckedChanged_E(object sender, EventArgs args)
        {
            if (category_E.Checked == true)
            {
                category_A.Checked = true;
                category_B.Checked = true;
                category_C.Checked = true;
                category_D1.Checked = true;
                category_D2.Checked = true;

            }
            else
            {
                category_F.Checked = false;
            }
        }
        protected void OnCheckedChanged_F(object sender, EventArgs args)
        {
            if (category_F.Checked == true)
            {
                category_A.Checked = true;
                category_B.Checked = true;
                category_C.Checked = true;
                category_D1.Checked = true;
                category_D2.Checked = true;
                category_E.Checked = true;

            }

        }

        //Add dropDawn drievr Minisrty
        void AllDriver()
        {
            I.DisplayAllDriver(DropDown_Driver);
        }

        //Add dropDawn Minisrty
        void Ministry()
        {
            if (codeMin == "All")
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
        //Add dropDawn Vehicle
        void Driver()
        {
            I.DisplayDriver(DropDown_Driver, codeMin);
        }

        protected void dropDown_Ministry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver();
        }
    }
}