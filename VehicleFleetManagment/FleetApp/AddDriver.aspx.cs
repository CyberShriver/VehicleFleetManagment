using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class AddDriver : System.Web.UI.Page
    {
        Driver_Class Dr = new Driver_Class();
        Driver_Interface I = new Driver_Imp();
        int msg;
        string code;
        string id;
        string codeMin;
        string sytemTitle;
        string slogan;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            id = Request.QueryString["DRIVER_ID"];
            if (!IsPostBack)
            {
                MsgInit();
                Ministry();
                MultiView.ActiveViewIndex = 0;
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;
                if (id == null)
                {
                    btnSave.InnerText = "Save";
                }
                else if (id != null && Dr.Ministry_Work == null)

                {
                   
                    btnSave.InnerText = "Save";
                    ChargeData();
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

        }
        private void MsgInit()
        {
            SuccessMsg.Visible = false;
            FillMsg.Visible = false;
            FailMsg.Visible = false;
        }

        //Add 
        void Add()
        {
            try
            {
                if ( txtFullName.Value == "" || txtTel.Value == "" || dateBirth.Value == "" || txtNationality.Value == "" || txtCNI.Value == "" || txtAddress1.Value == "" 
                    || DropDown_language.SelectedValue == "-1" || DropDown_Gender.SelectedValue == "-1" || DropDown_Marital.SelectedValue == "-1" || DropDownList_DriverType.SelectedValue == "-1")
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images/Drivers/") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Dr.Driver_Code = DriverCode();
                                Dr.Ministry_Work = DropDown_Ministry.SelectedValue;
                                Dr.Full_Name = txtFullName.Value;
                                Dr.CNI = txtCNI.Value;
                                Dr.Address1 = txtAddress1.Value;
                                Dr.Address2 = txtAddress2.Value;
                                Dr.Address3 = txtAddress3.Value;
                                Dr.Driver_Type = DropDownList_DriverType.SelectedValue;
                                Dr.Postal_code = txtPostal.Value;
                                Dr.Email = txtMail.Value;
                                Dr.Nationality = txtNationality.Value;
                                Dr.Gender = DropDown_Gender.SelectedValue;
                                Dr.Marital_Status = DropDown_Marital.SelectedValue;
                                Dr.DOB = dateBirth.Value;
                                Dr.Mother_Language = DropDown_language.SelectedValue;
                                Dr.Office_Phone = txtTelOffice.Value;
                                Dr.Personnal_Phone = txtTel.Value;
                                Dr.State = state();
                                Dr.Picture = img;
                                msg = I.Add(Dr);
                                if (msg > 0)
                                {
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = false;
                                    SuccessMsg.Visible = true;

                                    txtCode.Value = "";
                                    txtFullName.Value = "";
                                    txtTel.Value = "";
                                    txtMail.Value = "";
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Dr.Driver_Code = DriverCode();
                        Dr.Ministry_Work = DropDown_Ministry.SelectedValue;
                        Dr.Full_Name = txtFullName.Value;
                        Dr.CNI = txtCNI.Value;
                        Dr.Address1 = txtAddress1.Value;
                        Dr.Address2 = txtAddress2.Value;
                        Dr.Address3 = txtAddress3.Value;
                        Dr.Driver_Type = DropDownList_DriverType.SelectedValue;
                        Dr.Postal_code = txtPostal.Value;
                        Dr.Email = txtMail.Value;
                        Dr.Nationality = txtNationality.Value;
                        Dr.Gender = DropDown_Gender.SelectedValue;
                        Dr.Marital_Status = DropDown_Marital.SelectedValue;
                        Dr.DOB = dateBirth.Value;
                        Dr.Mother_Language = DropDown_language.SelectedValue;
                        Dr.Office_Phone = txtTelOffice.Value;
                        Dr.Personnal_Phone = txtTel.Value;
                        Dr.State = state();
                        Dr.Picture = "unkownDriver.jpg";
                        msg = I.Add(Dr);
                        if (msg > 0)
                        {
                            FillMsg.Visible = false;
                            FailMsg.Visible = false;
                            SuccessMsg.Visible = true;

                            txtCode.Value = "";
                            txtFullName.Value = "";
                            txtTel.Value = "";
                            txtMail.Value = "";
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
                if (txtCode.Value == "" || txtFullName.Value == "" || txtTel.Value == "" || txtMail.Value == "" || dateBirth.Value == "" || txtNationality.Value == "" ||
                    txtCNI.Value == "" || txtAddress1.Value == "" || txtAddress1.Value == "" ||txtTelOffice.Value == "" || txtPostal.Value == ""
                    || DropDown_language.SelectedValue == "-1" || DropDown_Gender.SelectedValue == "-1" || DropDown_Marital.SelectedValue == "-1" || DropDownList_DriverType.SelectedValue == "-1" )
                {
                    SuccessMsg.Visible = false;
                    FillMsg.Visible = true;
                    FailMsg.Visible = false;
                }
                else
                {
                    if (file_upd.HasFile)
                    {
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Dr.Driver_Code = txtCode.Value;
                                Dr.Ministry_Work = DropDown_Ministry.SelectedValue;
                                Dr.Full_Name = txtFullName.Value;
                                Dr.CNI = txtCNI.Value;
                                Dr.Address1 = txtAddress1.Value;
                                Dr.Address2 = txtAddress2.Value;
                                Dr.Address3 = txtAddress3.Value;
                                Dr.Driver_Type = DropDownList_DriverType.SelectedValue;
                                Dr.Postal_code = txtPostal.Value;
                                Dr.Email = txtMail.Value;
                                Dr.Nationality = txtNationality.Value;
                                Dr.Gender = DropDown_Gender.SelectedValue;
                                Dr.Marital_Status = DropDown_Marital.SelectedValue;
                                Dr.DOB = dateBirth.Value;
                                Dr.Mother_Language = DropDown_language.SelectedValue;
                                Dr.Office_Phone = txtTelOffice.Value;
                                Dr.Personnal_Phone = txtTel.Value;
                                Dr.State = state();
                                Dr.Picture = img;
                                msg = I.Update(Dr, Convert.ToInt32(id));
                                if (msg > 0)
                                {
                                    Response.Redirect("~/FleetApp/ViewDriver.aspx");
                                }
                                else
                                {
                                    SuccessMsg.Visible = false;
                                    FillMsg.Visible = false;
                                    FailMsg.Visible = true;

                                }
                            }
                            else
                            {
                                SuccessMsg.Visible = false;
                                FillMsg.Visible = false;
                                FailMsg.Visible = true;
                            }
                        }
                        else
                        {
                            SuccessMsg.Visible = false;
                            FillMsg.Visible = false;
                            FailMsg.Visible = true;
                        }
                    }
                    else
                    {
                        Dr.Driver_Code = txtCode.Value;
                        Dr.Ministry_Work = DropDown_Ministry.SelectedValue;
                        Dr.Full_Name = txtFullName.Value;
                        Dr.CNI = txtCNI.Value;
                        Dr.Address1 = txtAddress1.Value;
                        Dr.Address2 = txtAddress2.Value;
                        Dr.Address3 = txtAddress3.Value;
                        Dr.Driver_Type = DropDownList_DriverType.SelectedValue;
                        Dr.Postal_code = txtPostal.Value;
                        Dr.Email = txtMail.Value;
                        Dr.Nationality = txtNationality.Value;
                        Dr.Gender = DropDown_Gender.SelectedValue;
                        Dr.Marital_Status = DropDown_Marital.SelectedValue;
                        Dr.DOB = dateBirth.Value;
                        Dr.Mother_Language = DropDown_language.SelectedValue;
                        Dr.Office_Phone = txtTelOffice.Value;
                        Dr.Personnal_Phone = txtTel.Value;
                        Dr.State = state();
                        Dr.Picture = "No Picture";
                        msg=I.Update(Dr, Convert.ToInt32(id));
                        if (msg > 0)
                        {
                            Response.Redirect("~/FleetApp/ViewDriver.aspx");
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
            catch (SqlException e)
            {
                SuccessMsg.Visible = false;
                FillMsg.Visible = false;
                FailMsg.Visible = true;
            }
        }

        //State Method
        String state()
        {
            string stat;
            if (codeMin != "All")
            {
                stat = "Work";
            }
            else
            {
                stat = "Free";
            }
            return stat;
        }

        protected void ChargeData()
        {
            if (id != null)
            {
                I.provide(Dr, Convert.ToInt32(id));

                txtCode.Value = Dr.Driver_Code;
                DropDown_Ministry.SelectedValue= Dr.Ministry_Work ;
                txtFullName.Value = Dr.Full_Name;
                txtCNI.Value = Dr.CNI;
                txtAddress1.Value = Dr.Address1;
                txtAddress2.Value = Dr.Address2;
                txtAddress3.Value = Dr.Address3;
                DropDownList_DriverType.SelectedValue = Dr.Driver_Type;
                txtPostal.Value = Dr.Postal_code;
                txtMail.Value = Dr.Email;
                txtNationality.Value = Dr.Nationality;
                DropDown_Gender.SelectedValue = Dr.Gender;
                DropDown_Marital.SelectedValue = Dr.Marital_Status;
                dateBirth.Value = Dr.DOB;
                DropDown_language.SelectedValue = Dr.Mother_Language;
                txtTelOffice.Value = Dr.Office_Phone;
                txtTel.Value = Dr.Personnal_Phone;
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            if (id == null)
            {
                Add();
            }
            else {

                Update();
            }
        }

        protected void ActiveGen_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 0;
            MsgInit();
            
            tabProfessional.Attributes.Remove("class");
            tabProfessional.Attributes.Add("class", "nav-link");

            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link active");
        }
        protected void ActiveProf_click(object sender, EventArgs args)
        {
            MultiView.ActiveViewIndex = 1;
            MsgInit();
            tabGen.Attributes.Remove("class");
            tabGen.Attributes.Add("class", "nav-link");

            tabProfessional.Attributes.Remove("class");
            tabProfessional.Attributes.Add("class", "nav-link active");
        }

        //Driver code auto generate 
        string DriverCode()
        {

            if (codeMin == "All")
            {
                return code = txtCNI.Value.Trim().Substring(0, 2) + (Convert.ToInt32(I.countAll() + 1)) + DateTime.Today.ToString("ddMMyyyy");
            }
            else
            {
                return code = txtCNI.Value.Trim().Substring(0, 2) + (Convert.ToInt32(I.count() + 1)) + DateTime.Today.ToString("ddMMyyyy");
            }
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
    }
}