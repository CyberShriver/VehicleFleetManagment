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
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["DRIVER_ID"];
            if (!IsPostBack)
            {
                MsgInit();
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
                if (txtCode.Value == "" || txtFullName.Value == "" || txtTel.Value == "" || txtMail.Value == "" || dateBirth.Value == "" || txtNationality.Value == "" ||
                    txtCNI.Value == "" || txtAddress1.Value == "" || txtAddress1.Value == "" || txtAddress2.Value == "" || txtAddress3.Value == "" || txtTelOffice.Value == "" || txtPostal.Value == ""
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
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Dr.Driver_Code = txtCode.Value;
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
                                Dr.Picture = img;
                                msg = I.Add(Dr);
                                if (msg > 0)
                                {
                                    I.Add(Dr);
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
                        Dr.Driver_Code = txtCode.Value;
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
                        Dr.Picture = "No Picture";
                        msg = I.Add(Dr);
                        if (msg > 0)
                        {
                            I.Add(Dr);
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
                    txtCNI.Value == "" || txtAddress1.Value == "" || txtAddress1.Value == "" || txtAddress2.Value == "" || txtAddress3.Value == "" || txtTelOffice.Value == "" || txtPostal.Value == ""
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
                        file_upd.SaveAs(Server.MapPath("~/FleetApp/assets/images") + Path.GetFileName(file_upd.FileName));
                        string img = Path.GetFileName(file_upd.FileName);
                        FileInfo ext = new FileInfo(img);
                        if (ext.Extension == ".ico" || ext.Extension == ".png" || ext.Extension == ".jpg" || ext.Extension == ".jpeg")
                        {
                            if (file_upd.PostedFile.ContentLength < 104857600)
                            {
                                Dr.Driver_Code = txtCode.Value;
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

        protected void ChargeData()
        {
            if (id != null)
            {
                I.provide(Dr, Convert.ToInt32(id));

                txtCode.Value = Dr.Driver_Code;
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
                //file_upd= Dr.Picture;
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
    }
}